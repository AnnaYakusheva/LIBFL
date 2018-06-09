﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExportBJ_XML.classes.DB;

namespace ExportBJ_XML.QueriesText
{
    public class Bibliojet
    {

        private string Fund;
        public string AFTable;
        public Bibliojet(string fund)
        {
            this.Fund = fund;
        }


        public string SELECT_RECORD_QUERY {
            get
            {
                return "select A.*,cast(A.MNFIELD as nvarchar(10))+A.MSFIELD code,A.SORT,B.PLAIN, C.IDLEVEL level_id, " +
                    " case when C.IDLEVEL = 1 then 'Монография'  " +
                    "  when C.IDLEVEL = -100 then 'Коллекция'  " +
                    "  when C.IDLEVEL = -2 then 'Сводный уровень многотомного издания'  " +
                    "  when C.IDLEVEL = 2 then 'Том (выпуск) многотомного издания'  " +
                    "  when C.IDLEVEL = -3 then 'Сводный уровень сериального издания'  " +
                    "  when C.IDLEVEL = -33 then 'Сводный уровень подсерии, входящей в серию'  " +
                    "  when C.IDLEVEL = 3 then 'Выпуск сериального издания'  " +
                    "  when C.IDLEVEL = -4 then 'Сводный уровень сборника'  " +
                    "  when C.IDLEVEL = 4 then 'Часть сборника'  " +
                    "  when C.IDLEVEL = -5 then 'Сводный уровень продолжающегося издания'  " +
                    "  when C.IDLEVEL = 5 then 'Выпуск продолжающегося издания' else '' end level " +
                    "  ,A.MNFIELD, A.MSFIELD , F.NAME RusFieldName, F.IDBLOCK, A.IDDATA" +
                    " from " + this.Fund + "..DATAEXT A" +
                    " left join " + this.Fund + "..DATAEXTPLAIN B on A.ID = B.IDDATAEXT " +
                    " left join " + this.Fund + "..MAIN C on A.IDMAIN = C.ID " +
                    " left join " + this.Fund + "..FIELDS F on A.MNFIELD = F.MNFIELD and A.MSFIELD = F.MSFIELD " +
                    " where A.IDMAIN = @idmain " +
                    " and not exists (select 1 from " + this.Fund + "..DATAEXT EXTR where EXTR.IDMAIN = @idmain and EXTR.MNFIELD = 899 and EXTR.MSFIELD = '$x' and lower(EXTR.SORT) = 'э') " +
                    " order by A.IDMAIN, A.IDDATA";
            }
        }

        public string IMPORT_CLARIFY_10a
        {
            get
            {
                return " select * from " + this.Fund + "..DATAEXT A " +
                           " left join " + this.Fund + "..DATAEXTPLAIN B on A.ID = B.IDDATAEXT " +
                           " where A.MNFIELD = 10 and A.MSFIELD = '$b' and A.IDDATA = @iddata";
            }
        }
        public string IMPORT_CLARIFY_101a
        {
            get
            {
                return " select NAME from " + this.Fund + "..LIST_1 where ID = @IDINLIST"; 
            }
        }
        public string IMPORT_CLARIFY_517a
        {
            get
            {
                return " select B.PLAIN from " + this.Fund + "..DATAEXT A " +
                                " left join " + this.Fund + "..DATAEXTPLAIN B on A.ID = B.IDDATAEXT " +
                                " where MNFIELD = 517 and MSFIELD = '$b' and A.IDDATA = @iddata";
            }
        }

        public string IMPORT_CLARIFY_205a_1
        {
            get
            {
                return " select * from " + this.Fund + "..DATAEXT A " +
                                " left join " + this.Fund + "..DATAEXTPLAIN B on A.ID = B.IDDATAEXT " +
                                " where A.MNFIELD = 205 and A.MSFIELD = '$b' and A.IDDATA = @iddata";
            }
        }

        public string IMPORT_CLARIFY_205a_2
        {
            get
            {
                return " select * from " + this.Fund + "..DATAEXT A " +
                        " left join " + this.Fund + "..DATAEXTPLAIN B on A.ID = B.IDDATAEXT " +
                        " where A.MNFIELD = 205 and A.MSFIELD = '$f' and A.IDDATA = @iddata";
            }
        }

        public string IMPORT_CLARIFY_205a_3
        {
            get
            {
                return " select * from " + this.Fund + "..DATAEXT A " +
                        " left join " + this.Fund + "..DATAEXTPLAIN B on A.ID = B.IDDATAEXT " +
                        " where A.MNFIELD = 205 and A.MSFIELD = '$g' and A.IDDATA = @iddata";
            }
        }

        public string IMPORT_CLARIFY_606a
        {
            get
            {
                return "select * " +
                                " from " + this.Fund + "..TPR_CHAIN A " +
                                " left join " + this.Fund + "..TPR_TES B on A.IDTES = B.ID " +
                                " where A.IDCHAIN = @idchain" +
                                " order by IDORDER";
            }
        }

        public string GET_ALL_EXEMPLARS
        {
            get
            {
                return " select distinct A.IDMAIN, A.IDDATA from " + this.Fund + "..DATAEXT A" +
                            " left join " + this.Fund + "..DATAEXTPLAIN B on B.IDDATAEXT = A.ID " +
                            " where A.IDMAIN = @idmain and (A.MNFIELD = 899 and A.MSFIELD = '$p' or A.MNFIELD = 899 and A.MSFIELD = '$a' or A.MNFIELD = 899 and A.MSFIELD = '$w') " +
                            " and not exists (select 1 from "  +this.Fund + "..DATAEXT C where C.IDDATA = A.IDDATA and C.MNFIELD = 921 and C.MSFIELD = '$c' and C.SORT = 'Списано')";
            }
        }

        public string GET_EXEMPLAR
        {
            get
            {
                return " select * from " + this.Fund + "..DATAEXT A" +
                        " left join " + this.Fund + "..DATAEXTPLAIN B on B.IDDATAEXT = A.ID " +
                        " left join " + this.Fund + "..LIST_8 C on A.MNFIELD = 899 and A.MSFIELD = '$a' and A.IDINLIST = C.ID " +
                        " where A.IDDATA = @iddata";
            }
        }

        public string GET_EXEMPLAR_BY_INVENTORY_NUMBER
        {
            get
            {
                return " select * from " + this.Fund + "..DATAEXT A" +
                        " left join " + this.Fund + "..DATAEXT B on A.IDDATA = B.IDDATA " +
                        " left join " + this.Fund + "..DATAEXTPLAIN C on C.IDDATAEXT = B.ID " +
                        " where A.MNFIELD = 899 and A.MSFIELD = '$p' and C.PLAIN = @inv" +
                        " and not exists (select 1 from " + this.Fund + "..DATAEXT C where A.IDDATA = C.IDDATA and MNFIELD = 482 and MSFIELD = '$a')";
            }
        }


        public string GET_HYPERLINK
        {
            get
            {
                return " select * from " + this.Fund + "..DATAEXT A" +
                    " left join " + this.Fund + "..DATAEXTPLAIN B on B.IDDATAEXT = A.ID " +
                    " where A.MNFIELD = 940 and A.MSFIELD = '$a' and A.IDMAIN = @idmain";
            }
        }
        public string GET_BOOK_SCAN_INFO
        {
            get
            {
                return " select * from BookAddInf..ScanInfo A" +
                    " where A.IDBase = @idbase and A.IDBook = @idmain";
            }
        }
        public string GET_ALL_IDMAIN_WITH_IMAGES
        {
            get
            {
                return "select IDMAIN from " + this.Fund + "..IMAGES";
            }
        }

        public string GET_IMAGE
        {
            get
            {
                return "select IDMAIN, PIC from " + this.Fund + "..IMAGES where IDMAIN = @idmain";
            }
        }

        public string GET_PARENT_PIN
        {
            get
            {
                return " select * from " + this.Fund + "..DATAEXT " +
                           " where MNFIELD = 225 and MSFIELD = '$a' and IDMAIN = @ParentPIN";
            }
        }

        public string GET_MAX_IDMAIN
        {
            get
            {
                return "select max(ID) from " + this.Fund + "..MAIN";
            }
        }

        public string GET_TITLE
        {
            get
            {
                return " select * from " + this.Fund + "..DATAEXT A " +
                    " left join " + this.Fund + "..DATAEXTPLAIN B on B.IDDATAEXT = A.ID " +
                    " where A.IDMAIN = @idmain and MNFIELD = 200 and MSFIELD = '$a' ";
            }
        }
        public string GET_AF_ALL_VALUES  
        {
            get
            {
                return " select PLAIN from " + this.Fund + ".." + this.AFTable + " A " +
                               " where IDAF = @AFLinkId";
            }
        }
        public string GET_RTF
        {
            get
            {
                return " select RTF from " + this.Fund + "..RTF A " +
                               " where IDMAIN = @idmain";
            }
        }

        public string IS_ALLIGAT//запрос не дописан
        {
            get
            {
                return " select * from "+this.Fund+"..DATAEXT A " +
                        " where exists (select 1 from "+this.Fund+"..DATAEXT B on)"+
                        " and A.IDDATA = @iddata and A.MNFIELD = 899 and A.MSFIELD = '$p' "+
                        ""+
                        ""+
                               " where IDDATA = @iddata";
            }
        }
        public string IS_ISSUED_OR_ORDERED_EMPLOYEE
        {
            get
            {
                return " select * from Reservation_E..Orders A " +
                               " where IDDATA = @iddata";
            }
        }
        public string IS_SELF_ISSUED_OR_ORDERED_EMPLOYEE
        {
            get
            {
                return " select * from Reservation_E..Orders A " +
                               " where ID_Book_EC = @idmain and ID_Reader = @idreader and IDDATA = @iddata";
            }
        }

        public string IS_ISSUED_TO_READER
        {
            get
            {
                return " select * from Reservation_O..Orders A " +
                               " where IDDATA = @iddata and Status not in (8,10,11)";
            }
        }

        public string GET_EMPLOYEE_STATUS
        {
            get
            {
                return  " select B.Name from Reservation_E..Orders A " +
                        " left join Reservation_E..Status B on A.Status = B.ID" +
                        " where ID_Book_EC = @idmain";
            }
        }

        public string GET_LAST_INCREMENT_DATE
        {
            get
            {
                return "select LastIncrement from EXPORTNEB..VufindIncrementUpdate where lower(BaseName) = lower(@base)";
            }
        }
        public string SET_LAST_INCREMENT_DATE
        {
            get
            {
                return "update EXPORTNEB..VufindIncrementUpdate set LastIncrement = @LastIncrement where lower(BaseName) = lower(@base)";
            }
        }
        public string GET_BUSY_ELECTRONIC_EXEMPLAR_COUNT//вся редкая книга без авторского права, но в будущем надо всё равно для всех фондов сделать BASE
        {
            get
            {
                return "select ID from Reservation_R..ELISSUED where BASE = "+((this.Fund == "BJVVV")? "1" : "2")+" and IDMAIN = @IDMAIN";
            }
        }
        public string GET_NEAREST_FREE_DATE_FOR_ELECTRONIC_ISSUE//вся редкая книга без авторского права, но в будущем надо всё равно для всех фондов сделать BASE
        {
            get
            {
                return "select min(DATERETURN) from Reservation_R..ELISSUED where BASE = " + ((this.Fund == "BJVVV") ? "1" : "2") + " and IDMAIN = @IDMAIN";
            }
        }        
        


    }

    public class Reader
    {
        public string GET_READER
        {
            get
            {
                return "select * from Readers..Main where NumberReader = @Id";
            }
        }
        public string IS_FIVE_ELBOOKS_ISSUED
        {
            get
            {
                return "select * from Reservation_R..ELISSUED where IDREADER = @Id";
            }
        }
    }

}
