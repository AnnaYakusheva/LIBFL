﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExportBJ_XML.classes.BJ
{
    public static class KeyValueMapping
    {
        

        public static readonly Dictionary<string, string> UnifiedLocation = new Dictionary<string, string> 
        { 
            { "КО обслуживания – зал абонементного обслуживания",                                   "Зал абонементного обслуживания 2 этаж" },//2006
            { "КО комплектования и ОД. Сектор комплектования – группа регистрации",                 "Отдел комплектования" },//2025
            { "КО автоматизации",                                                                   "Центр инновационных информационных технологий" },//2033
            { "Центр славянских культур",                                                           "Центр славянских культур 4 этаж" },//2036
            { "Francothèque",                                                                       "Культурный центр \"Франкотека\" 2 этаж" },//2014
            { "Франкотека",                                                                         "Культурный центр \"Франкотека\" 2 этаж" },//2014
            { "...ЗалФ... ЦМС ОР Культурный центр Франкотека",                                      "Культурный центр \"Франкотека\" 2 этаж" },//2014
            { "Выездная библиотека",                                                                "Центр американской культуры 3 этаж" },//2039
            { "American cultural center(!)",                                                        "Центр американской культуры 3 этаж" },//2039
            { "American cultural center",                                                           "Центр американской культуры 3 этаж" },//2039
            { "…Зал… КОО Группа электронного зала 2 этаж",                                          "Электронный зал 2 этаж" },//2038
            { "…Зал… КОО Группа читального зала 3 этаж",                                            "Читальный зал 3 этаж" },//2037
            { "…ЗалФ… ЦМС ОР Центр славянских культур",                                             "Центр славянских культур 4 этаж" },//2036
            { "ЦМРС - Центр межрегионального сотрудничества",                                       "Центр межрегионального сотрудничества" },//2041
            { "ЦМС Отдел международного протокола",                                                 "Центр международного сотрудничества" },//2035
            { "ЦМС ОР Отдел японской культуры",                                                     "Центр международного сотрудничества" },//2035
            { "ЦМС ОР - Отдел развития",                                                            "Центр международного сотрудничества" },//2035
            { "ЦМС - Центр международного сотрудничества",                                          "Центр международного сотрудничества" },//2035
            { "ЦКПП - Центр культурно-просветительских программ",                                   "Центр культурно-просветительских программ" },//2034
            { "ЦИИТ Группа развития",                                                               "Центр инновационных информационных технологий" },//2033
            { "ЦИИТ Группа автоматизации",                                                          "Центр инновационных информационных технологий" },//2033
            { "ЦИИТ Группа IT",                                                                     "Центр инновационных информационных технологий" },//2033
            { "ЦИИТ - Центр инновационных информационных технологий",                               "Центр инновационных информационных технологий" },//2033
            { "…ЗалФ… ЦМС ОР Центр американской культуры",                                          "Центр американской культуры 3 этаж" },//2039
            { "ЦБИД - Центр библиотечно-информационной деятельности и поддержки чтения",            "Служебные подразделения" },//2031
            { "Д УЭ Служба эксплуатации зданий и благоустройства",                                  "Служебные подразделения" },//2031
            { "Д УЭ Служба управления инженерными системами",                                       "Служебные подразделения" },//2031
            { "Д УЭ Служба материально-технического обеспечения",                                   "Служебные подразделения" },//2031
            { "Д УЭ - Управление по эксплуатации объектов недвижимости и обеспечения деятельности", "Служебные подразделения" },//2031
            { "Д Отдел финансового планирования и сводной отчетности",                              "Служебные подразделения" },//2031
            { "Д Отдел по работе с персоналом",                                                     "Служебные подразделения" },//2031
            { "Д Отдел внутреннего финансового контроля",                                           "Служебные подразделения" },//2031
            { "Д Отдел безопасности",                                                               "Служебные подразделения" },//2031
            { "Д Отдел PR и редакция сайта",                                                        "Служебные подразделения" },//2031
            { "Д Контрактная служба",                                                               "Служебные подразделения" },//2031
            { "Д Группа экспедиторского обслуживания",                                              "Служебные подразделения" },//2031
            { "Д Бухгалтерия",                                                                      "Служебные подразделения" },//2031
            { "Д - Дирекция",                                                                       "Служебные подразделения" },//2031
            { "Д Аппарат генерального директора",                                                   "Служебные подразделения" },//2031
            { "…Хран… ЦИИТ Сервера библиотеки",                                                     "Сервера библиотеки" },//2030
            { "КО КОД Сектор ОД",                                                                   "Сектор обработки документов" },//2029
            { "КО ХКРФ Сектор книгохранения",                                                       "Сектор книгохранения" },//2011
            { "ЦМС Академия Рудомино",                                                              "Академия \"Рудомино\""}, //2000        
            { "…Выст… КОО Группа справочного-информационного обслуживания",                         "Выставка книг 2 этаж"},//2001
            { "…ЗалФ… Отдел детской книги и детских программ",                                      "Детский зал 2 этаж"},//2003
            { "ЦМС ОР Дом еврейской книги",                                                         "Дом еврейской книги 3 этаж"},//2005
            { "…Зал… КОО Группа абонементного обслуживания",                                        "Зал абонементного обслуживания 2 этаж"},//2006
            { "…Зал… КОО Группа выдачи документов",                                                 "Зал выдачи документов 2 этаж"},//2007
            { "…Зал… КНИО Группа искусствоведения",                                                 "Зал искусствоведения 4 этаж"},//2008
            { "…Зал… КНИО Группа редкой книги",                                                     "Зал редкой книги 4 этаж"},//2009
            { "…ЗалФ… КНИО Группа религиоведения",                                                  "Зал религиоведения 4 этаж"},//2010
            { "…Хран… Сектор книгохранения - 0 этаж",                                               "Книгохранение"},//2011
            { "…Хран… Сектор книгохранения - 2 этаж",                                               "Книгохранение"},//2011
            { "…Хран… Сектор книгохранения - 3 этаж",                                               "Книгохранение"},//2011
            { "…Хран… Сектор книгохранения - 4 этаж",                                               "Книгохранение"},//2011
            { "…Хран… Сектор книгохранения - 5 этаж",                                               "Книгохранение"},//2011
            { "…Хран… Сектор книгохранения - 6 этаж",                                               "Книгохранение"},//2011
            { "…Хран… Сектор книгохранения - 7 этаж",                                               "Книгохранение"},//2011
            { "…Хран… Сектор книгохранения - Абонемент",                                            "Книгохранение"},//2011
            { "…Хран… Сектор книгохранения - Новая периодика",                                      "Книгохранение"},//2011
            { "КО ХКРФ Группа МБА",                                                                 "Служебные подразделения" },//2031
            
            { "…Хран… КНИО Группа хранения редкой книги",                                           "Книгохранение редкой книги"},//2012
            { "Книжный клуб",                                                                       "Книжный клуб 1 этаж"},//2013
            { "…ЗалФ… ЦМС ОР Культурный центр Франкотека",                                          "Культурный центр \"Франкотека\" 2 этаж"},//2014
            { "…ЗалФ… ЦМС ОР Лингвистический ресурсный центр Pearson",                              "Лингвистический ресурсный центр Pearson 3 этаж"},//2015
            { "КНИО - Комплексный научно-исследовательский отдел",                                  "Научно-исследовательский отдел"},//2016
            { "…Обраб… КО КОД Сектор ОД - Группа инвентаризации",                                   "Обработка в группе инвентаризации"},//2017
            { "…Обраб… КО КОД Сектор ОД - Группа каталогизации",                                    "Обработка в группе каталогизации"},//2018
            { "…Обраб… КО ХКРФ Сектор микрофильмирования",                                          "Обработка в группе микрофильмирования"},//2019
            { "…Обраб… ЦИИТ Группа оцифровки",                                                      "Обработка в группе оцифровки"},//2020
            { "…Обраб… КО КОД Сектор ОД - Группа систематизации",                                   "Обработка в группе систематизации"},//2021
            { "…Обраб… КО КОД Сектор комплектования",                                               "Обработка в секторе комплектования"},//2022
            { "…Обраб… КО ХКРФ Сектор научной реставрации",                                         "Обработка в секторе научной реставрации"},//2023
            { "…Хран… Сектор книгохранения - Овальный зал",                                         "Овальный зал"},//2024
            { "КО КОД - Комплексный отдел комплектования и обработки документов",                   "Отдел комплектования"},//2025
            { "КОО - Комплексный отдел обслуживания",                                               "Отдел обслуживания"},//,2026
            { "КОО Группа регистрации",                                                             "Отдел обслуживания"},//2026
            { "КО ХКРФ - Комплексный отдел хранения, консервации и реставрации фондов",             "Отдел хранения и реставрации"},//2027
            { "ЦКПП Редакционно-издательский отдел",                                                "Редакционно-издательский отдел"}//2028   
        };

        //public static readonly Dictionary<string, string> UnifiedLocationBJCodeToVufindCode = new Dictionary<int, int> 
        //{ 
        //    { 55, 	2001},//…Выст… КОО Группа справочного-информационного обслуживания
        //    { 16,	2008},//…Зал… КНИО Группа искусствоведения
        //    { 20,	2009},//…Зал… КНИО Группа редкой книги
        //    { 29,	2006},//…Зал… КОО Группа абонементного обслуживания
        //    { 48,	2007},//…Зал… КОО Группа выдачи документов
        //    { 30,	},//…Зал… КОО Группа читального зала 3 этаж
        //    { 54,	},//…Зал… КОО Группа электронного зала 2 этаж
        //    { 21,	},//…ЗалФ… КНИО Группа религиоведения
        //    { 22,	},//…ЗалФ… Отдел детской книги и детских программ
        //    { 60,	},//…ЗалФ… ЦМС ОР Культурный центр Франкотека
        //    { 83,	},//…ЗалФ… ЦМС ОР Лингвистический ресурсный центр Pearson
        //    { 52,	},//…ЗалФ… ЦМС ОР Центр американской культуры
        //    { 61,	},//…ЗалФ… ЦМС ОР Центр славянских культур
        //    { 26,	},//…Обраб… КО КОД Сектор комплектования
        //    { 45,	},//…Обраб… КО КОД Сектор ОД - Группа инвентаризации
        //    { 43,	},//…Обраб… КО КОД Сектор ОД - Группа каталогизации
        //    { 44,	},//…Обраб… КО КОД Сектор ОД - Группа систематизации
        //    { 59,	},//…Обраб… КО ХКРФ Сектор микрофильмирования
        //    { 19,	},//…Обраб… КО ХКРФ Сектор научной реставрации
        //    { 38,	},//…Обраб… ЦИИТ Группа оцифровки
        //    { 46,	},//…Хран… КНИО Группа хранения редкой книги
        //    { 15,	},//…Хран… Сектор книгохранения - 0 этаж
        //    { 6,	},//…Хран… Сектор книгохранения - 2 этаж
        //    { 7,	},//…Хран… Сектор книгохранения - 3 этаж
        //    { 8,	},//…Хран… Сектор книгохранения - 4 этаж
        //    { 9,	},//…Хран… Сектор книгохранения - 5 этаж
        //    { 10,	},//…Хран… Сектор книгохранения - 6 этаж
        //    { 11,	},//…Хран… Сектор книгохранения - 7 этаж
        //    { 47,	},//…Хран… Сектор книгохранения - Абонемент
        //    { 31,	},//…Хран… Сектор книгохранения - Новая периодика
        //    { 13,	},//…Хран… Сектор книгохранения - Овальный зал
        //    { 79,	},//…Хран… ЦИИТ Сервера библиотеки
        //    { 4,	},//Д - Дирекция
        //    { 64,	},//Д Аппарат генерального директора
        //    { 2,	},//Д Бухгалтерия
        //    { 65,	},//Д Группа экспедиторского обслуживания
        //    { 66,	},//Д Контрактная служба
        //    { 69,	},//Д Отдел PR и редакция сайта
        //    { 67,	},//Д Отдел безопасности
        //    { 68,	},//Д Отдел внутреннего финансового контроля
        //    { 24,	},//Д Отдел по работе с персоналом
        //    { 34,	},//Д Отдел финансового планирования и сводной отчетности
        //    { 70,	},//Д УЭ - Управление по эксплуатации объектов недвижимости и обеспечения деятельности
        //    { 50,	},//Д УЭ Служба материально-технического обеспечения
        //    { 71,	},//Д УЭ Служба управления инженерными системами
        //    { 72,	},//Д УЭ Служба эксплуатации зданий и благоустройства
        //    { 86,	},//Книжный клуб
        //    { 73,	},//КНИО - Комплексный научно-исследовательский отдел
        //    { 74,	},//КО КОД - Комплексный отдел комплектования и обработки документов
        //    { 42,	},//КО КОД Сектор ОД
        //    { 75,	},//КО ХКРФ - Комплексный отдел хранения, консервации и реставрации фондов
        //    { 37,	},//КО ХКРФ Группа МБА
        //    { 25,	},//КО ХКРФ Сектор книгохранения
        //    { 28,	},//КОО - Комплексный отдел обслуживания
        //    { 49,	},//КОО Группа регистрации
        //    { 76,	},//ЦБИД - Центр библиотечно-информационной деятельности и поддержки чтения
        //    { 77,	},//ЦИИТ - Центр инновационных информационных технологий
        //    { 23,	},//ЦИИТ Группа IT
        //    { 18,	},//ЦИИТ Группа автоматизации
        //    { 78,	},//ЦИИТ Группа развития
        //    { 39,	},//ЦКПП - Центр культурно-просветительских программ
        //    { 17,	},//ЦКПП Редакционно-издательский отдел
        //    { 5,	},//ЦМРС - Центр межрегионального сотрудничества
        //    { 80,	},//ЦМС - Центр международного сотрудничества
        //    { 40,	},//ЦМС Академия Рудомино
        //    { 85,	},//ЦМС ОР - Отдел развития
        //    { 84,	},//ЦМС ОР Дом еврейской книги
        //    { 62,	},//ЦМС ОР Отдел японской культуры
        //    { 27,	},//ЦМС Отдел международного протокола
        //};


        public static readonly Dictionary<string, string> UnifiedLocationAccess = new Dictionary<string, string> 
        { 
            { "…ЗалФ… ЦМС ОР Культурный центр Франкотека",                                          "Культурный центр \"Франкотека\" 2 этаж"},//2014
            { "…Выст… КОО Группа справочного-информационного обслуживания",                         "Выставка книг 2 этаж"},//2001
            { "…ЗалФ… Отдел детской книги и детских программ",                                      "Детский зал 2 этаж"},//2003
            { "ЦМС ОР Дом еврейской книги",                                                         "Дом еврейской книги 3 этаж"},//2005
            { "…Зал… КОО Группа абонементного обслуживания",                                        "Зал абонементного обслуживания 2 этаж"},//2006
            { "…Зал… КОО Группа выдачи документов",                                                 "Зал выдачи документов 2 этаж"},//2007
            { "…Зал… КНИО Группа искусствоведения",                                                 "Зал искусствоведения 4 этаж"},//2008
            { "…Зал… КНИО Группа редкой книги",                                                     "Зал редкой книги 4 этаж"},//2009
            { "…ЗалФ… КНИО Группа религиоведения",                                                  "Зал религиоведения 4 этаж"},//2010
            { "…Хран… ЦИИТ Сервера библиотеки",                                                     "Сервера библиотеки" },//2030
            { "…ЗалФ… ЦМС ОР Центр американской культуры",                                          "Центр американской культуры 3 этаж" },//2039
            { "…Хран… Сектор книгохранения - Овальный зал",                                         "Овальный зал"},//2024
            { "КО обслуживания – зал абонементного обслуживания",                                   "Зал абонементного обслуживания 2 этаж" },//2006
            { "КО комплектования и ОД. Сектор комплектования – группа регистрации",                 "Служебные подразделения" },//2031
            { "КО автоматизации",                                                                   "Служебные подразделения" },//2031
            { "Центр славянских культур",                                                           "Центр славянских культур 4 этаж" },//2036
            { "Francothèque",                                                                       "Культурный центр \"Франкотека\" 2 этаж" },//2014
            { "Франкотека",                                                                         "Культурный центр \"Франкотека\" 2 этаж" },//2014
            { "Выездная библиотека",                                                                "Центр американской культуры 3 этаж" },//2039
            { "American cultural center(!)",                                                        "Центр американской культуры 3 этаж" },//2039
            { "American cultural center",                                                           "Центр американской культуры 3 этаж" },//2039
            { "…Зал… КОО Группа электронного зала 2 этаж",                                          "Электронный зал 2 этаж" },//2038
            { "…Зал… КОО Группа читального зала 3 этаж",                                            "Читальный зал 3 этаж" },//2037
            { "…ЗалФ… ЦМС ОР Центр славянских культур",                                             "Центр славянских культур 4 этаж" },//2036

            { "…Хран… Сектор книгохранения - 0 этаж",                                               "Книгохранение"},//2011
            { "…Хран… Сектор книгохранения - 2 этаж",                                               "Книгохранение"},//2011
            { "…Хран… Сектор книгохранения - 3 этаж",                                               "Книгохранение"},//2011
            { "…Хран… Сектор книгохранения - 4 этаж",                                               "Книгохранение"},//2011
            { "…Хран… Сектор книгохранения - 5 этаж",                                               "Книгохранение"},//2011
            { "…Хран… Сектор книгохранения - 6 этаж",                                               "Книгохранение"},//2011
            { "…Хран… Сектор книгохранения - 7 этаж",                                               "Книгохранение"},//2011
            { "…Хран… Сектор книгохранения - Абонемент",                                            "Книгохранение"},//2011
            { "…Хран… Сектор книгохранения - Новая периодика",                                      "Книгохранение"},//2011
            { "…Хран… КНИО Группа хранения редкой книги",                                           "Книгохранение"},//2011

            { "ЦМРС - Центр межрегионального сотрудничества",                                       "Служебные подразделения" },//2031
            { "ЦМС Отдел международного протокола",                                                 "Служебные подразделения" },//2031
            { "ЦМС ОР Отдел японской культуры",                                                     "Служебные подразделения" },//2031
            { "ЦМС ОР - Отдел развития",                                                            "Служебные подразделения" },//2031
            { "ЦМС - Центр международного сотрудничества",                                          "Служебные подразделения" },//2031
            { "ЦКПП - Центр культурно-просветительских программ",                                   "Служебные подразделения" },//2031
            { "ЦИИТ Группа развития",                                                               "Служебные подразделения" },//2031
            { "ЦИИТ Группа автоматизации",                                                          "Служебные подразделения" },//2031
            { "ЦИИТ Группа IT",                                                                     "Служебные подразделения" },//2031
            { "ЦИИТ - Центр инновационных информационных технологий",                               "Служебные подразделения" },//2031
            { "ЦБИД - Центр библиотечно-информационной деятельности и поддержки чтения",            "Служебные подразделения" },//2031
            { "Д УЭ Служба эксплуатации зданий и благоустройства",                                  "Служебные подразделения" },//2031
            { "Д УЭ Служба управления инженерными системами",                                       "Служебные подразделения" },//2031
            { "Д УЭ Служба материально-технического обеспечения",                                   "Служебные подразделения" },//2031
            { "Д УЭ - Управление по эксплуатации объектов недвижимости и обеспечения деятельности", "Служебные подразделения" },//2031
            { "Д Отдел финансового планирования и сводной отчетности",                              "Служебные подразделения" },//2031
            { "Д Отдел по работе с персоналом",                                                     "Служебные подразделения" },//2031
            { "Д Отдел внутреннего финансового контроля",                                           "Служебные подразделения" },//2031
            { "Д Отдел безопасности",                                                               "Служебные подразделения" },//2031
            { "Д Отдел PR и редакция сайта",                                                        "Служебные подразделения" },//2031
            { "Д Контрактная служба",                                                               "Служебные подразделения" },//2031
            { "Д Группа экспедиторского обслуживания",                                              "Служебные подразделения" },//2031
            { "Д Бухгалтерия",                                                                      "Служебные подразделения" },//2031
            { "КО КОД Сектор ОД",                                                                   "Служебные подразделения" },//2031
            { "КО ХКРФ Сектор книгохранения",                                                       "Служебные подразделения" },//2031
            { "ЦМС Академия Рудомино",                                                              "Служебные подразделения" },//2031
            { "Книжный клуб",                                                                       "Служебные подразделения" },//2031
            { "…ЗалФ… ЦМС ОР Лингвистический ресурсный центр Pearson",                              "Служебные подразделения" },//2031
            { "КНИО - Комплексный научно-исследовательский отдел",                                  "Служебные подразделения" },//2031
            { "…Обраб… КО КОД Сектор ОД - Группа инвентаризации",                                   "Служебные подразделения" },//2031
            { "…Обраб… КО КОД Сектор ОД - Группа каталогизации",                                    "Служебные подразделения" },//2031
            { "…Обраб… КО ХКРФ Сектор микрофильмирования",                                          "Служебные подразделения" },//2031
            { "…Обраб… ЦИИТ Группа оцифровки",                                                      "Служебные подразделения" },//2031
            { "…Обраб… КО КОД Сектор ОД - Группа систематизации",                                   "Служебные подразделения" },//2031
            { "…Обраб… КО КОД Сектор комплектования",                                               "Служебные подразделения" },//2031
            { "…Обраб… КО ХКРФ Сектор научной реставрации",                                         "Служебные подразделения" },//2031
            { "КО КОД - Комплексный отдел комплектования и обработки документов",                   "Служебные подразделения" },//2031
            { "КОО - Комплексный отдел обслуживания",                                               "Служебные подразделения" },//2031
            { "КОО Группа регистрации",                                                             "Служебные подразделения" },//2031
            { "КО ХКРФ - Комплексный отдел хранения, консервации и реставрации фондов",             "Служебные подразделения" },//2031
            { "ЦКПП Редакционно-издательский отдел",                                                "Служебные подразделения" },//2031   
        };
        public static readonly Dictionary<string, int> UnifiedLocationCode = new Dictionary<string, int>()
        {
            {  "Центр инновационных информационных технологий" , 2033},//2033
            {  "Центр американской культуры 3 этаж" , 2039},//2039
            {  "Электронный зал 2 этаж" , 2038},//2038
            {  "Читальный зал 3 этаж" , 2037},//2037
            {  "Центр славянских культур 4 этаж" , 2036},//2036
            {  "Центр межрегионального сотрудничества" , 2041},//2041
            {  "Центр международного сотрудничества" , 2035},//2035
            {  "Центр культурно-просветительских программ" , 2034},//2034
            {  "Служебные подразделения" , 2031},//2031
            {  "Сервера библиотеки" , 2030},//2030
            {  "Сектор обработки документов" , 2029},//2029
            {  "Сектор книгохранения" , 2011},//2011
            {  "Академия \"Рудомино\"", 2000}, //2000        
            {  "Выставка книг 2 этаж",2001 },//2001
            {  "Детский зал 2 этаж", 2003},//2003
            {  "Дом еврейской книги 3 этаж", 2005},//2005
            {  "Зал абонементного обслуживания 2 этаж", 2006},//2006
            {  "Зал выдачи документов 2 этаж", 2007},//2007
            {  "Зал искусствоведения 4 этаж", 2008},//2008
            {  "Зал редкой книги 4 этаж", 2009},//2009
            {  "Зал религиоведения 4 этаж", 2010},//2010
            {  "Книгохранение", 2011},//2011
            {  "Книгохранение редкой книги", 2012},//2012
            {  "Книжный клуб 1 этаж", 2013},//2013
            {  "Культурный центр \"Франкотека\" 2 этаж", 2014},//2014
            {  "Лингвистический ресурсный центр Pearson 3 этаж", 2015},//2015
            {  "Научно-исследовательский отдел", 2016},//2016
            {  "Обработка в группе инвентаризации", 2017},//2017
            {  "Обработка в группе каталогизации", 2018},//2018
            {  "Обработка в группе микрофильмирования", 2019},//2019
            {  "Обработка в группе оцифровки", 2020},//2020
            {  "Обработка в группе систематизации", 2021},//2021
            {  "Обработка в секторе комплектования", 2022},//2022
            {  "Обработка в секторе научной реставрации", 2023},//2023
            {  "Овальный зал", 2024},//2024
            {  "Отдел комплектования", 2025},//2025
            {  "Отдел обслуживания", 2026},//,2026
            {  "Отдел хранения и реставрации", 2027},//2027
            {  "Редакционно-издательский отдел", 2028}//2028   
        };

        public static readonly Dictionary<int, int> AccessCodeToGroup = new Dictionary<int, int>()
        {
            {  1000 , 14},
            {  1001 , 1},
            {  1002 , 2},
            {  1003 , 8},
            {  1004 , 3},
            {  1005 , 6},
            {  1006 , 7},
            {  1007 , 9},
            {  1008 , 4},
            {  1009 , 5},
            {  1010 , 11},
            {  1011 , 10},
            {  1012 , 6},
            {  1013 , 12},
            {  1014 , 9},
            {  1016 , 13},
            {  1999 , 99},
        };
        

        //default: 3001
        public static readonly Dictionary<string, int> CarrierNameToCode = new Dictionary<string, int>()
        {
            {  "Аудиокассета" ,         3000},
            {  "Бумага" ,               3001},
            {  "Видеокассета" ,         3002},
            {  "Грампластинка" ,        3003},
            {  "Дискета" ,              3004},
            {  "Комплект(бумага+)" ,    3005},
            {  "Магнитная лента" ,      3006},
            {  "Микрофильм" ,           3007},
            {  "Микрофиша" ,            3008},
            {  "СD/DVD" ,               3009},
            {  "Слайд" ,                3010},
            {  "Электронная копия" ,    3011},
            {  "Электронное издание" ,  3012},
        };
         
            

        
    }
}



           