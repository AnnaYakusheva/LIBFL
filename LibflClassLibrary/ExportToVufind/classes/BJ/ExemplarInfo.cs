﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExportBJ_XML.classes;
using ExportBJ_XML.classes.BJ;
using ExportBJ_XML.classes.DB;
using System.Data;


namespace ExportBJ_XML.ValueObjects
{
    /// <summary>
    /// Сводное описание для ExemplarInfo
    /// </summary>
    public class ExemplarInfo
    {
        public ExemplarInfo(int idData)
        {
            this._iddata = idData;
        }

        private int _iddata;
        public int IdData
        {
            get
            {
                return _iddata;
            }
        }

        public string Fund { get; set; }
        public int IDMAIN { get; set; }

        public bool IsAlligat { get; set; }
        public int ConvolutePin { get; set; }
        public int ConvoluteIdData { get; set; }

        public DateTime Created; //для новых поступлений. Дата присвоения инвентарного номера.

        public BJFields Fields = new BJFields();

        public ExemplarAccessInfo ExemplarAccess = new ExemplarAccessInfo(); 


        public static ExemplarInfo GetExemplarByInventoryNumber(string inv, string fund)
        {
            DatabaseWrapper dbw = new DatabaseWrapper(fund);
            DataTable table = dbw.GetExemplar(inv);
            if (table.Rows.Count == 0)
            {
                return null;
            }
            ExemplarInfo exemplar = ExemplarInfo.GetExemplarByIdData((int)table.Rows[0]["IDDATA"], fund);
            return exemplar;
                
            //    new ExemplarInfo((int)table.Rows[0]["IDDATA"]);
            //exemplar.IDMAIN = (int)table.Rows[0]["IDMAIN"];
            //exemplar.Fund = fund;
            //foreach (DataRow row in table.Rows)
            //{
            //    exemplar.Fields.AddField(row["PLAIN"].ToString(), (int)row["MNFIELD"], row["MSFIELD"].ToString());
            //}
            //exemplar.ExemplarAccess = ExemplarInfo.GetExemplarAccess(exemplar);
            ////exemplar.IsAlligat = dbw.IsAlligat(exemplar.IdData).Rows.Count;
            //return exemplar;
        }
        public static ExemplarInfo GetExemplarByIdData(int iddata, string fund)
        {
            DatabaseWrapper dbw = new DatabaseWrapper(fund);
            DataTable table = dbw.GetExemplar(iddata);
            ExemplarInfo exemplar = new ExemplarInfo((int)table.Rows[0]["IDDATA"]);
            exemplar.IDMAIN = (int)table.Rows[0]["IDMAIN"];
            exemplar.Fund = fund;
            foreach (DataRow row in table.Rows)
            {
                if (fund == "BJACC")
                {
                    if (row["MNFIELD"].ToString() + row["MSFIELD"].ToString() == "899$w")//в американской базе нет инвентарных номеров. берем штрихкод
                    {
                        exemplar.Created = (DateTime)row["Created"];
                    }
                }
                else
                {
                    if (row["MNFIELD"].ToString() + row["MSFIELD"].ToString() == "899$p")//в остальных есть и берём дату создания поля инвентарный номер
                    {
                        exemplar.Created = (DateTime)row["Created"];
                    }
                }
                if (row["MNFIELD"].ToString() + row["MSFIELD"].ToString() == "899$a")
                {
                    exemplar.Fields.AddField(row["NAME"].ToString(), (int)row["MNFIELD"], row["MSFIELD"].ToString()); //местонахождение берём из LIST_8, а не из DATAEXTPLAIN, потому что в поле PLAIN меняются некоторые символы
                    continue;
                }
                exemplar.Fields.AddField(row["PLAIN"].ToString(), (int)row["MNFIELD"], row["MSFIELD"].ToString());

            }
            exemplar.ExemplarAccess = ExemplarInfo.GetExemplarAccess(exemplar);

            return exemplar;
        }

        private static ExemplarAccessInfo GetExemplarAccess(ExemplarInfo exemplar)
        {

            ExemplarAccessInfo access = new ExemplarAccessInfo();
            //сначала суперусловия
            if (exemplar.Fields["899$x"].ToString().ToLower().Contains("э"))
            {
                access.Access = 1020;//такого в таблице нет. это только здесь. означает экстремистскую литературу.
                access.MethodOfAccess = 4005;
                return access;
            }

            switch (exemplar.Fund)
            {
                case "BJVVV":
                    if ((exemplar.Fields["899$b"].ToLower() == "абонемент") && (!exemplar.Fields["899$a"].ToLower().Contains("книгохране")) && (exemplar.Fields["899$a"].ToLower().Contains("абонем")))
                    {
                        access.Access = 1006;
                        access.MethodOfAccess = 4001;
                        return access;
                    }
                    else if ((exemplar.Fields["899$b"].ToLower() == "абонемент") && (exemplar.Fields["899$a"].ToLower().Contains("книгохране")) && (exemplar.Fields["899$a"].ToLower().Contains("абонем")))
                    {
                        access.Access = 1000;
                        access.MethodOfAccess = 4001;
                        return access;
                    }
                    else if ((exemplar.Fields["899$a"].ToLower().Contains("книгохране")) && (exemplar.Fields["899$a"].ToLower().Contains("абонем")))
                    {
                        access.Access = 1000;
                        access.MethodOfAccess = 4001;
                        return access;
                    }
                    else if (exemplar.Fields["899$a"].ToLower().Contains("славянс") && (exemplar.Fields["899$b"].ToLower() != "вх"))
                    {
                        access.Access = 1007;
                        access.MethodOfAccess = 4000;
                        return access;
                    }
                    else if (exemplar.Fields["899$a"].ToLower().Contains("славянс") && (exemplar.Fields["899$b"].ToLower() == "вх"))
                    {
                        access.Access = 1006;
                        access.MethodOfAccess = 4001;
                        return access;
                    }
                    else if (exemplar.Fields["921$c"].ToString() == "Для выдачи")
                    {
                        access.Access = 1005;
                        access.MethodOfAccess = 4000;
                        return access;
                    }
                    else if ((exemplar.Fields["921$c"].ToString() == "ДП")
                            && (KeyValueMapping.UnifiedLocationAccess[exemplar.Fields["899$a"].ToString()] != "Служебные подразделения"))
                    {
                        access.Access = 1007;
                        access.MethodOfAccess = 4000;
                        return access;
                    }
                    else if ((exemplar.Fields["921$c"].ToString() == "ДП")
                            && (KeyValueMapping.UnifiedLocationAccess[exemplar.Fields["899$a"].ToString()] == "Служебные подразделения"))
                    {
                        access.Access = 1013;
                        access.MethodOfAccess = 4005;
                        return access;
                    }
                    else if (exemplar.Fields["921$c"].ToString() == "Выставка")
                    {
                        access.Access = 1011;
                        access.MethodOfAccess = 4000;
                        return access;
                    }
                    else if ((exemplar.Fields["921$c"].ToString() != "Для выдачи") && 
                             (exemplar.Fields["921$c"].ToString() != "Выставка") && 
                             (exemplar.Fields["921$c"].ToString() != "Перевод в другой фонд"))
                    {
                        access.Access = 1013;
                        access.MethodOfAccess = 4005;
                        return access;
                    }
                    else if (
                                
                                    (exemplar.Fields["899$b"].ToLower() == "спв") || (!exemplar.Fields["921$a"].ToLower().Contains("бумага"))        
                                &&
                                    (exemplar.Fields["899$a"].ToLower().Contains("книгохране"))
                            )
                    {
                        access.Access = 1012;
                        access.MethodOfAccess = 4000;
                        return access;
                    }
                    //else if (exemplar.Fields["921$d"].ToString() == "Эл. свободный доступ")
                    //{
                    //    access.Access = 1001;
                    //    access.MethodOfAccess = 4002;
                    //    return access;
                    //}
                    //else if (exemplar.Fields["921$d"].ToString() == "Эл. через личный кабинет")
                    //{
                    //    access.Access = 1002;
                    //    access.MethodOfAccess = 4002;
                    //    return access;
                    //}
                    //else if (exemplar.Fields["921$d"].ToString() == "Эл. только в библиотеке")
                    //{
                    //    access.Access = 1003;
                    //    access.MethodOfAccess = 4003;
                    //    return access;
                    //}
                    //else if (exemplar.Fields["921$d"].ToString() == "На усмотрение сотрудника")
                    //{
                    //    access.Access = 1010;
                    //    access.MethodOfAccess = 4005;
                    //    return access;
                    //}
                    //else if (exemplar.Fields["921$d"].ToString() == "Ограниченный доступ")
                    //{
                    //    access.Access = 1016;
                    //    access.MethodOfAccess = 4005;
                    //    return access;
                    //}
                    else if (exemplar.Fields["482$a"].ToLower() != "")
                    {
                        ExemplarInfo Convolute = ExemplarInfo.GetExemplarByInventoryNumber(exemplar.Fields["482$a"].ToString(), exemplar.Fund);
                        if (Convolute != null)
                        {
                            access.MethodOfAccess = Convolute.ExemplarAccess.MethodOfAccess;
                            access.Access = Convolute.ExemplarAccess.Access;
                        }
                    }
                    else
                    {
                        access.Access = 1999;
                        access.MethodOfAccess = 4005;
                    }



                    break;
                case "REDKOSTJ":
                    if (exemplar.Fields["482$a"].ToLower() != "")
                    {
                        ExemplarInfo Convolute = ExemplarInfo.GetExemplarByInventoryNumber(exemplar.Fields["482$a"].ToString(), exemplar.Fund);
                        if (Convolute == null)
                        {
                            access.Access = 1999;
                            access.MethodOfAccess = 4999;
                        }
                        else
                        {
                            access.Access = Convolute.ExemplarAccess.Access;
                            access.MethodOfAccess = Convolute.ExemplarAccess.MethodOfAccess;
                        }

                    }
                    if (exemplar.Fields["899$a"].ToLower().Contains("зал"))
                    {
                        access.Access = 1007;
                        access.MethodOfAccess = 4000;
                    }
                    else if (exemplar.Fields["899$a"].ToLower().Contains("хранения"))
                    {
                        access.Access = 1014;
                        access.MethodOfAccess = 4000;
                    }
                    else if (exemplar.Fields["899$a"].ToLower().Contains("обраб"))
                    {
                        access.Access = 1013;
                        access.MethodOfAccess = 4005;
                    }
                    //else if (exemplar.Fields["921$d"].ToString() == "Эл. свободный доступ")
                    //{
                    //    access.Access = 1001;
                    //    access.MethodOfAccess = 4002;
                    //    return access;
                    //}
                    //else if (exemplar.Fields["921$d"].ToString() == "Эл. через личный кабинет")
                    //{
                    //    access.Access = 1002;
                    //    access.MethodOfAccess = 4002;
                    //    return access;
                    //}
                    //else if (exemplar.Fields["921$d"].ToString() == "Эл. только в библиотеке")
                    //{
                    //    access.Access = 1003;
                    //    access.MethodOfAccess = 4003;
                    //    return access;
                    //}
                    //else if (exemplar.Fields["921$d"].ToString() == "На усмотрение сотрудника")
                    //{
                    //    access.Access = 1010;
                    //    access.MethodOfAccess = 4005;
                    //    return access;
                    //}
                    //else if (exemplar.Fields["921$d"].ToString() == "Ограниченный доступ")
                    //{
                    //    access.Access = 1016;
                    //    access.MethodOfAccess = 4005;
                    //    return access;
                    //}
                    else if (exemplar.Fields["921$c"].ToString() == "Выставка")
                    {
                        access.Access = 1011;
                        access.MethodOfAccess = 4000;
                        return access;
                    }
                    else
                    {
                        access.Access = 1999;
                        access.MethodOfAccess = 4005;
                    }
                    break;
                case "BJACC":
                    access.Access = 1006;
                    access.MethodOfAccess = 4001;
                    break;
                case "BJFCC":
                    access.Access = 1006;
                    access.MethodOfAccess = 4001;
                    break;
                case "BJSCC":
                    //костыль временно:
                    access.Access = 1010;
                    access.MethodOfAccess = 4005;

                    //то, что должно быть
                    //access.Access = 1007;
                    //access.MethodOfAccess = 4000;
                    break;
                default:
                    access.Access = 1999;
                    access.MethodOfAccess = 4005;
                    break;
            }


           



           
            //if (f_921d == "Эл. свободный доступ")
            //{
            //    access = "1001";
            //    AddField("MethodOfAccess", "4002");
            //    return access;
            //}
            //if (f_921d == "Эл. через личный кабинет")
            //{
            //    access = "1002";
            //    AddField("MethodOfAccess", "4002");
            //    return access;
            //}
            //if (f_921d == "Эл. только в библиотеке")
            //{
            //    access = "1003";
            //    AddField("MethodOfAccess", "4003");
            //    return access;
            //}
            
            ////невозможно определить
            //access = "1010";
            //AddField("MethodOfAccess", "4999");
            return access;
        }






        public bool IsIssuedOrOrderedEmployee()
        {
            switch (this.Fund)
            {
                case "BJVVV":
                    DatabaseWrapper dbw = new DatabaseWrapper(this.Fund);
                    DataTable table = dbw.IsIssuedOrOrderedEmployee(this.IDMAIN, this.IdData);
                    return (table.Rows.Count == 0) ? false : true;
                default:
                    return false;
            }
        }

        public bool IsSelfIssuedOrOrderedEmployee(int IdReader)
        {
            switch (this.Fund)
            {
                case "BJVVV":
                    DatabaseWrapper dbw = new DatabaseWrapper(this.Fund);
                    DataTable table = dbw.IsSelfIssuedOrOrderedEmployee(this.IdData, this.IDMAIN, IdReader);
                    return (table.Rows.Count == 0) ? false : true;
                default:
                    return false;
            }
        }

        public bool IsIssuedToReader()
        {
            switch (this.Fund)
            {
                case "BJVVV":
                    DatabaseWrapper dbw = new DatabaseWrapper(this.Fund);
                    DataTable table = dbw.IsIssuedToReader(this.IdData);
                    return (table.Rows.Count == 0) ? false : true;
                default:
                    return false;
            }
        }

        public string GetEmployeeStatus()
        {
            switch (this.Fund)
            {
                case "BJVVV":
                    DatabaseWrapper dbw = new DatabaseWrapper(this.Fund);
                    DataTable table = dbw.GetEmployeeStatus(this.IDMAIN);
                    return (table.Rows.Count == 0) ? "" : table.Rows[0][0].ToString();
                default:
                    return "";
            }
        }
    }
}