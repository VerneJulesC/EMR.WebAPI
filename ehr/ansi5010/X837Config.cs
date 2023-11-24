using iTextSharp.text.pdf.qrcode;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EMR.WebAPI.ehr.ansi5010
{
    static class X837Config
    {
        static X837Config()
        {
            Items = new Dictionary<string, string>();
            X837ConfigFormat = new Dictionary<string, X837Segment[]>();
            SeparateNewLine = false;
            RetrieveFormatConfig();
            RetrieveConfig();
        }

        public static X837Segment[] X12_837
        {
            get;
            set;
        }
        public static X837Segment[] X12_Other
        {
            get;
            set;
        }
        public static X837Segment X12_GS
        {
            get;
            set;
        }

        public static Dictionary<string, X837Segment[]> X837ConfigFormat
        {
            get;
            set;
        }

        public static bool SeparateNewLine
        {
            get;
            set;
        }

        public static Dictionary<string, string> Items
        {
            get;
            set;
        }

        public static void RetrieveFormatConfig()
        {
            X12_837 = new X837Segment[] {
    new X837Segment(
        null,
        "ISA",
        "Interchange Control Header",
        true,
        "1",
        null,
        false,
        null,
        new X837Element[] {
            new X837Element("ISA01", "I01", "Identifier (ID)", "Mandatory", 2, 2, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("ISA02", "I02", "String (AN)", "Mandatory", 10, 10, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("ISA03", "I03", "Identifier (ID)", "Mandatory", 2, 2, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("ISA04", "I04", "String (AN)", "Mandatory", 10, 10, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("ISA05", "I05", "Identifier (ID)", "Mandatory", 2, 2, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("ISA06", "I06", "String (AN)", "Mandatory", 15, 15, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("ISA07", "I05", "Identifier (ID)", "Mandatory", 2, 2, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("ISA08", "I07", "String (AN)", "Mandatory", 15, 15, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("ISA09", "I08", "Date (DT)", "Mandatory", 6, 6, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("ISA10", "I09", "Time (TM)", "Mandatory", 4, 4, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("ISA11", "I65", "", "Mandatory", 1, 1, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("ISA12", "I11", "Identifier (ID)", "Mandatory", 5, 5, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("ISA13", "I12", "Numeric (N0)", "Mandatory", 9, 9, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("ISA14", "I13", "Identifier (ID)", "Mandatory", 1, 1, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("ISA15", "I14", "Identifier (ID)", "Mandatory", 1, 1, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("ISA16", "I15", "", "Mandatory", 1, 1, 1, new string[] { }, new X837Element[]{ })
        },
new X837Segment[] { }),
    new X837Segment(
        "0050",
        "ST",
        "Transaction Set Header",
        true,
        "1",
        null,
        false,
        null,
        new X837Element[]{
            new X837Element("ST01","143","Identifier (ID)","Mandatory",3,3,1, new string[]{  }, new X837Element[]{ }),
            new X837Element("ST02","329","String (AN)","Mandatory",4,9,1, new string[]{  }, new X837Element[]{ }),
            new X837Element("ST03","1705","String (AN)","Optional",1,35,1, new string[]{  }, new X837Element[]{ })
        },
new X837Segment[] { }),
    new X837Segment(
        "0100",
        "BHT",
        "Beginning of Hierarchical Transaction",
        true,
        "1",
        null,
        false,
        null,
        new X837Element[]{
            new X837Element("BHT01", "1005", "Identifier (ID)", "Mandatory", 4, 4, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("BHT02", "353", "Identifier (ID)", "Mandatory", 2, 2, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("BHT03", "127", "String (AN)", "Optional", 1, 50, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("BHT04", "373", "Date (DT)", "Optional", 8, 8, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("BHT05", "337", "Time (TM)", "Optional", 4, 8, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("BHT06", "640", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ })
        },
new X837Segment[] { }),
    new X837Segment(
        "0150",
        "REF",
        "Reference Information",
        false,
        "3",
        null,
        false,
        null,
        new X837Element[]{
            new X837Element("REF01", "128", "Identifier (ID)", "Mandatory", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("REF02", "127", "String (AN)", "Conditional", 1, 50, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("REF03", "352", "String (AN)", "Conditional", 1, 80, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("REF04", "C040", "Composite (composite)", "Optional", -1, -1, 1, new string[] { }, new X837Element[]{
                    new X837Element("01", "128", "Identifier (ID)", "Mandatory", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("02", "127", "String (AN)", "Mandatory", 1, 50, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("03", "128", "Identifier (ID)", "Conditional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("04", "127", "String (AN)", "Conditional", 1, 50, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("05", "128", "Identifier (ID)", "Conditional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("06", "127", "String (AN)", "Conditional", 1, 50, 1, new string[] { }, new X837Element[]{ })
                })
        },
new X837Segment[] { }),
    new X837Segment(
        "0200",
        "NM1",
        "Individual or Organizational Name",
        true,
        "1",
        "1000",
        false,
        "10",
        new X837Element[]{
            new X837Element("NM101", "98", "Identifier (ID)", "Mandatory", 2, 3, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("NM102", "1065", "Identifier (ID)", "Mandatory", 1, 1, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("NM103", "1035", "String (AN)", "Conditional", 1, 60, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("NM104", "1036", "String (AN)", "Optional", 1, 35, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("NM105", "1037", "String (AN)", "Optional", 1, 25, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("NM106", "1038", "String (AN)", "Optional", 1, 10, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("NM107", "1039", "String (AN)", "Optional", 1, 10, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("NM108", "66", "Identifier (ID)", "Conditional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("NM109", "67", "String (AN)", "Conditional", 2, 80, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("NM110", "706", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("NM111", "98", "Identifier (ID)", "Optional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("NM112", "1035", "String (AN)", "Optional", 1, 60, 1, new string[] { }, new X837Element[]{ })
        },
new X837Segment[] { }),
        new X837Segment(
            "0250",
            "N2",
            "Additional Name Information",
            false,
            "2",
            "1000",
            false,
            "10",
            new X837Element[]{
                new X837Element("N201", "93", "String (AN)", "Mandatory", 1, 60, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("N202", "93", "String (AN)", "Optional", 1, 60, 1, new string[] { }, new X837Element[]{ })
            },
new X837Segment[] { }),
        new X837Segment(
            "0300",
            "N3",
            "Party Location",
            false,
            "2",
            "1000",
            false,
            "10",
            new X837Element[]{
                new X837Element("N301", "166", "String (AN)", "Mandatory", 1, 55, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("N302", "166", "String (AN)", "Optional", 1, 55, 1, new string[] { }, new X837Element[]{ })
            },
new X837Segment[] { }),
        new X837Segment(
            "0350",
            "N4",
            "Geographic Location",
            false,
            "1",
            "1000",
            false,
            "10",
            new X837Element[]{
                new X837Element("N401", "19", "String (AN)", "Optional", 2, 30, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("N402", "156", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("N403", "116", "Identifier (ID)", "Optional", 3, 15, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("N404", "26", "Identifier (ID)", "Conditional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("N405", "309", "Identifier (ID)", "Conditional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("N406", "310", "String (AN)", "Optional", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("N407", "1715", "Identifier (ID)", "Conditional", 1, 3, 1, new string[] { }, new X837Element[]{ })
            },
new X837Segment[] { }),
        new X837Segment(
            "0450",
            "PER",
            "Administrative Communications Contact",
            false,
            "2",
            "1000",
            false,
            "10",
            new X837Element[]{
                new X837Element("PER01", "366", "Identifier (ID)", "Mandatory", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("PER02", "93", "String (AN)", "Optional", 1, 60, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("PER03", "365", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("PER04", "364", "String (AN)", "Conditional", 1, 256, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("PER05", "365", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("PER06", "364", "String (AN)", "Conditional", 1, 256, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("PER07", "365", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("PER08", "364", "String (AN)", "Conditional", 1, 256, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("PER09", "443", "String (AN)", "Optional", 1, 20, 1, new string[] { }, new X837Element[]{ })
            },
new X837Segment[] { }),
    new X837Segment(
        "0010",
        "HL",
        "Hierarchical Level",
        true,
        "1",
        "2000",
        true,
        ">1",
        new X837Element[]{
            new X837Element("HL01", "628", "String (AN)", "Mandatory", 1, 12, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("HL02", "734", "String (AN)", "Optional", 1, 12, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("HL03", "735", "Identifier (ID)", "Mandatory", 1, 2, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("HL04", "736", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ })
        },
new X837Segment[] { }),
        new X837Segment(
            "0030",
            "PRV",
            "Provider Information",
            false,
            "1",
            "2000",
            true,
            ">1",
            new X837Element[]{
                new X837Element("PRV01", "1221", "Identifier (ID)", "Mandatory", 1, 3, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("PRV02", "128", "Identifier (ID)", "Conditional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("PRV03", "127", "String (AN)", "Conditional", 1, 50, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("PRV04", "156", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("PRV05", "C035", "Composite (composite)", "Optional", -1, -1, 1, new string[] { }, new X837Element[]{
                    new X837Element("01", "1222", "String (AN)", "Mandatory", 1, 3, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("02", "559", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("03", "1073", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ })
                }),
                new X837Element("PRV06", "1223", "Identifier (ID)", "Optional", 3, 3, 1, new string[] { }, new X837Element[]{ })
            },
new X837Segment[] { }),
        new X837Segment(
            "0050",
            "SBR",
            "Subscriber Information",
            false,
            "1",
            "2000",
            true,
            ">1",
            new X837Element[]{
                new X837Element("SBR01", "1138", "Identifier (ID)", "Mandatory", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("SBR02", "1069", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("SBR03", "127", "String (AN)", "Optional", 1, 50, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("SBR04", "93", "String (AN)", "Optional", 1, 60, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("SBR05", "1336", "Identifier (ID)", "Optional", 1, 3, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("SBR06", "1143", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("SBR07", "1073", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("SBR08", "584", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("SBR09", "1032", "Identifier (ID)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ })
            },
new X837Segment[] { }),
        new X837Segment(
            "0070",
            "PAT",
            "Patient Information",
            false,
            "1",
            "2000",
            true,
            ">1",
            new X837Element[]{
                new X837Element("PAT01", "1069", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("PAT02", "1384", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("PAT03", "584", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("PAT04", "1220", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("PAT05", "1250", "Identifier (ID)", "Conditional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("PAT06", "1251", "String (AN)", "Conditional", 1, 35, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("PAT07", "355", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("PAT08", "81", "Decimal number (R)", "Conditional", 1, 10, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("PAT09", "1073", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ })
            },
new X837Segment[] { }),
        new X837Segment(
            "0090",
            "DTP",
            "Date or Time or Period",
            false,
            "5",
            "2000",
            true,
            ">1",
            new X837Element[]{
                new X837Element("DTP01", "374", "Identifier (ID)", "Mandatory", 3, 3, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("DTP02", "1250", "Identifier (ID)", "Mandatory", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("DTP03", "1251", "String (AN)", "Mandatory", 1, 35, 1, new string[] { }, new X837Element[]{ })
            },
new X837Segment[] { }),
        new X837Segment(
            "0100",
            "CUR",
            "Currency",
            false,
            "1",
            "2000",
            true,
            ">1",
            new X837Element[]{
                new X837Element("CUR01", "98", "Identifier (ID)", "Mandatory", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CUR02", "100", "Identifier (ID)", "Mandatory", 3, 3, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CUR03", "280", "Decimal number (R)", "Optional", 4, 10, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CUR04", "98", "Identifier (ID)", "Optional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CUR05", "100", "Identifier (ID)", "Optional", 3, 3, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CUR06", "669", "Identifier (ID)", "Optional", 3, 3, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CUR07", "374", "Identifier (ID)", "Conditional", 3, 3, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CUR08", "373", "Date (DT)", "Optional", 8, 8, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CUR09", "337", "Time (TM)", "Optional", 4, 8, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CUR10", "374", "Identifier (ID)", "Conditional", 3, 3, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CUR11", "373", "Date (DT)", "Conditional", 8, 8, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CUR12", "337", "Time (TM)", "Conditional", 4, 8, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CUR13", "374", "Identifier (ID)", "Conditional", 3, 3, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CUR14", "373", "Date (DT)", "Conditional", 8, 8, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CUR15", "337", "Time (TM)", "Conditional", 4, 8, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CUR16", "374", "Identifier (ID)", "Conditional", 3, 3, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CUR17", "373", "Date (DT)", "Conditional", 8, 8, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CUR18", "337", "Time (TM)", "Conditional", 4, 8, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CUR19", "374", "Identifier (ID)", "Conditional", 3, 3, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CUR20", "373", "Date (DT)", "Conditional", 8, 8, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CUR21", "337", "Time (TM)", "Conditional", 4, 8, 1, new string[] { }, new X837Element[]{ })
            },
new X837Segment[] { }),
            new X837Segment(
                "0320",
                "DMG",
                "Demographic Information",
                false,
                "1",
                "2010",
                false,
                "10",
                new X837Element[]{
                    new X837Element("DMG01", "1250", "Identifier (ID)", "Conditional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("DMG02", "1251", "String (AN)", "Conditional", 1, 35, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("DMG03", "1068", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("DMG04", "1067", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("DMG05", "C056", "Composite (composite)", "Conditional", -1, -1, 10, new string[] { }, new X837Element[]{
                        new X837Element("01", "1109", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("02", "1270", "Identifier (ID)", "Conditional", 1, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("03", "1271", "String (AN)", "Conditional", 1, 30, 1, new string[] { }, new X837Element[]{ })
                    }),
                    new X837Element("DMG06", "1066", "Identifier (ID)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("DMG07", "26", "Identifier (ID)", "Optional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("DMG08", "659", "Identifier (ID)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("DMG09", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("DMG10", "1270", "Identifier (ID)", "Conditional", 1, 3, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("DMG11", "1271", "String (AN)", "Conditional", 1, 30, 1, new string[] { }, new X837Element[]{ })
                },
new X837Segment[] { }),
        new X837Segment(
            "1300",
            "CLM",
            "Health Claim",
            true,
            "1",
            "2300",
            false,
            "100",
            new X837Element[]{
                new X837Element("CLM01", "1028", "String (AN)", "Mandatory", 1, 38, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CLM02", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CLM03", "1032", "Identifier (ID)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CLM04", "1343", "Identifier (ID)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CLM05", "C023", "Composite (composite)", "Optional", -1, -1, 1, new string[] { }, new X837Element[]{
                    new X837Element("01", "1331", "String (AN)", "Mandatory", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("02", "1332", "Identifier (ID)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("03", "1325", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ })
                }),
                new X837Element("CLM06", "1073", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CLM07", "1359", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CLM08", "1073", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CLM09", "1363", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CLM10", "1351", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CLM11", "C024", "Composite (composite)", "Optional", -1, -1, 1, new string[] { }, new X837Element[]{
                    new X837Element("01", "1362", "Identifier (ID)", "Mandatory", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("02", "1362", "Identifier (ID)", "Optional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("03", "1362", "Identifier (ID)", "Optional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("04", "156", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("05", "26", "Identifier (ID)", "Optional", 2, 3, 1, new string[] { }, new X837Element[]{ })
                }),
                new X837Element("CLM12", "1366", "Identifier (ID)", "Optional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CLM13", "1073", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CLM14", "1338", "Identifier (ID)", "Optional", 1, 3, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CLM15", "1073", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CLM16", "1360", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CLM17", "1029", "Identifier (ID)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CLM18", "1073", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CLM19", "1383", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                new X837Element("CLM20", "1514", "Identifier (ID)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ })
            },
new X837Segment[] { }),
            new X837Segment(
                "1400",
                "CL1",
                "Claim Codes",
                false,
                "1",
                "2300",
                false,
                "100",
                new X837Element[]{
                    new X837Element("CL101", "1315", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CL102", "1314", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CL103", "1352", "Identifier (ID)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CL104", "1345", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ })
                },
new X837Segment[] { }),
            new X837Segment(
                "1450",
                "DN1",
                "Orthodontic Information",
                false,
                "1",
                "2300",
                false,
                "100",
                new X837Element[]{
                    new X837Element("DN101", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("DN102", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("DN103", "1073", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("DN104", "352", "String (AN)", "Optional", 1, 80, 1, new string[] { }, new X837Element[]{ })
                },
new X837Segment[] { }),
            new X837Segment(
                "1500",
                "DN2",
                "Tooth Summary",
                false,
                "35",
                "2300",
                false,
                "100",
                new X837Element[]{
                    new X837Element("DN201", "127", "String (AN)", "Mandatory", 1, 50, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("DN202", "1368", "Identifier (ID)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("DN203", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("DN204", "1250", "Identifier (ID)", "Conditional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("DN205", "1251", "String (AN)", "Conditional", 1, 35, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("DN206", "1270", "Identifier (ID)", "Mandatory", 1, 3, 1, new string[] { }, new X837Element[]{ })
                },
new X837Segment[] { }),
            new X837Segment(
                "1550",
                "PWK",
                "Paperwork",
                false,
                "10",
                "2300",
                false,
                "100",
                new X837Element[]{
                    new X837Element("PWK01", "755", "Identifier (ID)", "Mandatory", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("PWK02", "756", "Identifier (ID)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("PWK03", "757", "Numeric (N0)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("PWK04", "98", "Identifier (ID)", "Optional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("PWK05", "66", "Identifier (ID)", "Conditional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("PWK06", "67", "String (AN)", "Conditional", 2, 80, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("PWK07", "352", "String (AN)", "Optional", 1, 80, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("PWK08", "C002", "Composite (composite)", "Optional", -1, -1, 1, new string[] { }, new X837Element[]{
                        new X837Element("01", "704", "Identifier (ID)", "Mandatory", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("02", "704", "Identifier (ID)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("03", "704", "Identifier (ID)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("04", "704", "Identifier (ID)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("05", "704", "Identifier (ID)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ })
                    }),
                    new X837Element("PWK09", "1525", "Identifier (ID)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ })
                },
new X837Segment[] { }),
            new X837Segment(
                "1600",
                "CN1",
                "Contract Information",
                false,
                "1",
                "2300",
                false,
                "100",
                new X837Element[]{
                    new X837Element("CN101", "1166", "Identifier (ID)", "Mandatory", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CN102", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CN103", "332", "Decimal number (R)", "Optional", 1, 6, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CN104", "127", "String (AN)", "Optional", 1, 50, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CN105", "338", "Decimal number (R)", "Optional", 1, 6, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CN106", "799", "String (AN)", "Optional", 1, 30, 1, new string[] { }, new X837Element[]{ })
                },
new X837Segment[] { }),
            new X837Segment(
                "1650",
                "DSB",
                "Disability Information",
                false,
                "1",
                "2300",
                false,
                "100",
                new X837Element[]{
                    new X837Element("DSB01", "1146", "Identifier (ID)", "Mandatory", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("DSB02", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("DSB03", "1149", "Identifier (ID)", "Optional", 4, 6, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("DSB04", "1154", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("DSB05", "1161", "Identifier (ID)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("DSB06", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("DSB07", "235", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("DSB08", "1137", "String (AN)", "Conditional", 1, 15, 1, new string[] { }, new X837Element[]{ })
                },
new X837Segment[] { }),
            new X837Segment(
                "1700",
                "UR",
                "Peer Review Organization or Utilization Review",
                false,
                "1",
                "2300",
                false,
                "100",
                new X837Element[]{
                    new X837Element("UR01", "1318", "Identifier (ID)", "Mandatory", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("UR02", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ })
                },
new X837Segment[] { }),
            new X837Segment(
                "1750",
                "AMT",
                "Monetary Amount Information",
                false,
                "40",
                "2300",
                false,
                "100",
                new X837Element[]{
                    new X837Element("AMT01", "522", "Identifier (ID)", "Mandatory", 1, 3, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("AMT02", "782", "Decimal number (R)", "Mandatory", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("AMT03", "478", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ })
                },
new X837Segment[] { }),
            new X837Segment(
                "1850",
                "K3",
                "File Information",
                false,
                "10",
                "2300",
                false,
                "100",
                new X837Element[]{
                    new X837Element("K301", "449", "String (AN)", "Mandatory", 1, 80, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("K302", "1333", "Identifier (ID)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("K303", "C001", "Composite (composite)", "Optional", -1, -1, 1, new string[] { }, new X837Element[]{
                        new X837Element("01", "355", "Identifier (ID)", "Mandatory", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("02", "1018", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("03", "649", "Decimal number (R)", "Optional", 1, 10, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("04", "355", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("05", "1018", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("06", "649", "Decimal number (R)", "Optional", 1, 10, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("07", "355", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("08", "1018", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("09", "649", "Decimal number (R)", "Optional", 1, 10, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("10", "355", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("11", "1018", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("12", "649", "Decimal number (R)", "Optional", 1, 10, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("13", "355", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("14", "1018", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("15", "649", "Decimal number (R)", "Optional", 1, 10, 1, new string[] { }, new X837Element[]{ })
                    })
                },
new X837Segment[] { }),
            new X837Segment(
                "1900",
                "NTE",
                "Note/Special Instruction",
                false,
                "20",
                "2300",
                false,
                "100",
                new X837Element[]{
                    new X837Element("NTE01", "363", "Identifier (ID)", "Optional", 3, 3, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("NTE02", "352", "String (AN)", "Mandatory", 1, 80, 1, new string[] { }, new X837Element[]{ })
                },
new X837Segment[] { }),
            new X837Segment(
                "1950",
                "CR1",
                "Ambulance Certification",
                false,
                "1",
                "2300",
                false,
                "100",
                new X837Element[]{
                    new X837Element("CR101", "355", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR102", "81", "Decimal number (R)", "Conditional", 1, 10, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR103", "1316", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR104", "1317", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR105", "355", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR106", "380", "Decimal number (R)", "Conditional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR107", "166", "String (AN)", "Optional", 1, 55, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR108", "166", "String (AN)", "Optional", 1, 55, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR109", "352", "String (AN)", "Optional", 1, 80, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR110", "352", "String (AN)", "Optional", 1, 80, 1, new string[] { }, new X837Element[]{ })
                },
new X837Segment[] { }),
            new X837Segment(
                "2000",
                "CR2",
                "Chiropractic Certification",
                false,
                "1",
                "2300",
                false,
                "100",
                new X837Element[]{
                    new X837Element("CR201", "609", "Numeric (N0)", "Conditional", 1, 9, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR202", "380", "Decimal number (R)", "Conditional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR203", "1367", "Identifier (ID)", "Conditional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR204", "1367", "Identifier (ID)", "Optional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR205", "355", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR206", "380", "Decimal number (R)", "Conditional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR207", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR208", "1342", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR209", "1073", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR210", "352", "String (AN)", "Optional", 1, 80, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR211", "352", "String (AN)", "Optional", 1, 80, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR212", "1073", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ })
                },
new X837Segment[] { }),
            new X837Segment(
                "2050",
                "CR3",
                "Durable Medical Equipment Certification",
                false,
                "1",
                "2300",
                false,
                "100",
                new X837Element[]{
                    new X837Element("CR301", "1322", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR302", "355", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR303", "380", "Decimal number (R)", "Conditional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR304", "1335", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR305", "352", "String (AN)", "Optional", 1, 80, 1, new string[] { }, new X837Element[]{ })

                },
new X837Segment[] { }),
            new X837Segment(
                "2100",
                "CR4",
                "Enteral or Parenteral Therapy Certification",
                false,
                "3",
                "2300",
                false,
                "100",
                new X837Element[]{
                    new X837Element("CR401", "1073", "Identifier (ID)", "Mandatory", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR402", "1322", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR403", "355", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR404", "380", "Decimal number (R)", "Conditional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR405", "355", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR406", "380", "Decimal number (R)", "Conditional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR407", "1344", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR408", "355", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR409", "380", "Decimal number (R)", "Conditional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR410", "355", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR411", "65", "Decimal number (R)", "Conditional", 1, 8, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR412", "355", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR413", "81", "Decimal number (R)", "Conditional", 1, 10, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR414", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR415", "352", "String (AN)", "Optional", 1, 80, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR416", "1346", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR417", "1347", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR418", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR419", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR420", "352", "String (AN)", "Optional", 1, 80, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR421", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR422", "954", "Decimal number (R)", "Optional", 1, 10, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR423", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR424", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR425", "954", "Decimal number (R)", "Optional", 1, 10, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR426", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR427", "954", "Decimal number (R)", "Optional", 1, 10, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR428", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR429", "352", "String (AN)", "Optional", 1, 80, 1, new string[] { }, new X837Element[]{ })
                },
new X837Segment[] { }),
            new X837Segment(
                "2150",
                "CR5",
                "Oxygen Therapy Certification",
                false,
                "1",
                "2300",
                false,
                "100",
                new X837Element[]{
                    new X837Element("CR501", "1322", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR502", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR503", "1348", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR504", "1348", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR505", "352", "String (AN)", "Optional", 1, 80, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR506", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR507", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR508", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR509", "352", "String (AN)", "Optional", 1, 80, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR510", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR511", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR512", "1349", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR513", "1350", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR514", "1350", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR515", "1350", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR516", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR517", "1382", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR518", "1348", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ })
                },
new X837Segment[] { }),
            new X837Segment(
                "2160",
                "CR6",
                "Home Health Care Certification",
                false,
                "1",
                "2300",
                false,
                "100",
                new X837Element[]{
                    new X837Element("CR601", "923", "Identifier (ID)", "Mandatory", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR602", "373", "Date (DT)", "Mandatory", 8, 8, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR603", "1250", "Identifier (ID)", "Conditional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR604", "1251", "String (AN)", "Conditional", 1, 35, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR605", "373", "Date (DT)", "Optional", 8, 8, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR606", "1073", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR607", "1073", "Identifier (ID)", "Mandatory", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR608", "1322", "Identifier (ID)", "Mandatory", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR609", "373", "Date (DT)", "Conditional", 8, 8, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR610", "235", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR611", "1137", "String (AN)", "Conditional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR612", "373", "Date (DT)", "Optional", 8, 8, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR613", "373", "Date (DT)", "Optional", 8, 8, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR614", "373", "Date (DT)", "Optional", 8, 8, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR615", "1250", "Identifier (ID)", "Conditional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR616", "1251", "String (AN)", "Conditional", 1, 35, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR617", "1384", "Identifier (ID)", "Conditional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR618", "373", "Date (DT)", "Optional", 8, 8, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR619", "373", "Date (DT)", "Optional", 8, 8, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR620", "373", "Date (DT)", "Optional", 8, 8, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR621", "373", "Date (DT)", "Optional", 8, 8, 1, new string[] { }, new X837Element[]{ })
                },
new X837Segment[] { }),
            new X837Segment(
                "2190",
                "CR8",
                "Pacemaker Certification",
                false,
                "9",
                "2300",
                false,
                "100",
                new X837Element[]{
                    new X837Element("CR801", "1403", "Identifier (ID)", "Mandatory", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR802", "1404", "Identifier (ID)", "Mandatory", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR803", "373", "Date (DT)", "Mandatory", 8, 8, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR804", "373", "Date (DT)", "Mandatory", 8, 8, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR805", "127", "String (AN)", "Mandatory", 1, 50, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR806", "127", "String (AN)", "Mandatory", 1, 50, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR807", "127", "String (AN)", "Mandatory", 1, 50, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR808", "1073", "Identifier (ID)", "Mandatory", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR809", "1073", "Identifier (ID)", "Mandatory", 1, 1, 1, new string[] { }, new X837Element[]{ })
                },
new X837Segment[] { }),
            new X837Segment(
                "2200",
                "CRC",
                "Conditions Indicator",
                false,
                "100",
                "2300",
                false,
                "100",
                new X837Element[]{
                    new X837Element("CRC01", "1136", "Identifier (ID)", "Mandatory", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CRC02", "1073", "Identifier (ID)", "Mandatory", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CRC03", "1321", "Identifier (ID)", "Mandatory", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CRC04", "1321", "Identifier (ID)", "Optional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CRC05", "1321", "Identifier (ID)", "Optional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CRC06", "1321", "Identifier (ID)", "Optional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CRC07", "1321", "Identifier (ID)", "Optional", 2, 3, 1, new string[] { }, new X837Element[]{ })
                },
new X837Segment[] { }),
            new X837Segment(
                "2310",
                "HI",
                "Health Care Information Codes",
                false,
                "25",
                "2300",
                false,
                "100",
                new X837Element[]{
                    new X837Element("HI01", "C022", "Composite (composite)", "Mandatory", -1, -1, 1, new string[] { }, new X837Element[]{
                        new X837Element("01", "1270", "Identifier (ID)", "Mandatory", 1, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("02", "1271", "String (AN)", "Mandatory", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("03", "1250", "Identifier (ID)", "Conditional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("04", "1251", "String (AN)", "Conditional", 1, 35, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("05", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("06", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("07", "799", "String (AN)", "Optional", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("08", "1271", "String (AN)", "Conditional", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("09", "1073", "Identifier (ID)", "Conditional", 1, 1, 1, new string[] { }, new X837Element[]{ })
                    }),
                    new X837Element("HI02", "C022", "Composite (composite)", "Optional", -1, -1, 1, new string[] { }, new X837Element[]{
                        new X837Element("01", "1270", "Identifier (ID)", "Mandatory", 1, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("02", "1271", "String (AN)", "Mandatory", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("03", "1250", "Identifier (ID)", "Conditional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("04", "1251", "String (AN)", "Conditional", 1, 35, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("05", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("06", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("07", "799", "String (AN)", "Optional", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("08", "1271", "String (AN)", "Conditional", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("09", "1073", "Identifier (ID)", "Conditional", 1, 1, 1, new string[] { }, new X837Element[]{ })
                    }),
                    new X837Element("HI03", "C022", "Composite (composite)", "Optional", -1, -1, 1, new string[] { }, new X837Element[]{
                        new X837Element("01", "1270", "Identifier (ID)", "Mandatory", 1, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("02", "1271", "String (AN)", "Mandatory", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("03", "1250", "Identifier (ID)", "Conditional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("04", "1251", "String (AN)", "Conditional", 1, 35, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("05", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("06", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("07", "799", "String (AN)", "Optional", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("08", "1271", "String (AN)", "Conditional", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("09", "1073", "Identifier (ID)", "Conditional", 1, 1, 1, new string[] { }, new X837Element[]{ })
                    }),
                    new X837Element("HI04", "C022", "Composite (composite)", "Optional", -1, -1, 1, new string[] { }, new X837Element[]{
                        new X837Element("01", "1270", "Identifier (ID)", "Mandatory", 1, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("02", "1271", "String (AN)", "Mandatory", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("03", "1250", "Identifier (ID)", "Conditional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("04", "1251", "String (AN)", "Conditional", 1, 35, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("05", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("06", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("07", "799", "String (AN)", "Optional", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("08", "1271", "String (AN)", "Conditional", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("09", "1073", "Identifier (ID)", "Conditional", 1, 1, 1, new string[] { }, new X837Element[]{ })
                    }),
                    new X837Element("HI05", "C022", "Composite (composite)", "Optional", -1, -1, 1, new string[] { }, new X837Element[]{
                        new X837Element("01", "1270", "Identifier (ID)", "Mandatory", 1, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("02", "1271", "String (AN)", "Mandatory", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("03", "1250", "Identifier (ID)", "Conditional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("04", "1251", "String (AN)", "Conditional", 1, 35, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("05", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("06", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("07", "799", "String (AN)", "Optional", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("08", "1271", "String (AN)", "Conditional", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("09", "1073", "Identifier (ID)", "Conditional", 1, 1, 1, new string[] { }, new X837Element[]{ })
                    }),
                    new X837Element("HI06", "C022", "Composite (composite)", "Optional", -1, -1, 1, new string[] { }, new X837Element[]{
                        new X837Element("01", "1270", "Identifier (ID)", "Mandatory", 1, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("02", "1271", "String (AN)", "Mandatory", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("03", "1250", "Identifier (ID)", "Conditional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("04", "1251", "String (AN)", "Conditional", 1, 35, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("05", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("06", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("07", "799", "String (AN)", "Optional", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("08", "1271", "String (AN)", "Conditional", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("09", "1073", "Identifier (ID)", "Conditional", 1, 1, 1, new string[] { }, new X837Element[]{ })
                    }),
                    new X837Element("HI07", "C022", "Composite (composite)", "Optional", -1, -1, 1, new string[] { }, new X837Element[]{
                        new X837Element("01", "1270", "Identifier (ID)", "Mandatory", 1, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("02", "1271", "String (AN)", "Mandatory", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("03", "1250", "Identifier (ID)", "Conditional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("04", "1251", "String (AN)", "Conditional", 1, 35, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("05", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("06", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("07", "799", "String (AN)", "Optional", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("08", "1271", "String (AN)", "Conditional", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("09", "1073", "Identifier (ID)", "Conditional", 1, 1, 1, new string[] { }, new X837Element[]{ })
                    }),
                    new X837Element("HI08", "C022", "Composite (composite)", "Optional", -1, -1, 1, new string[] { }, new X837Element[]{
                        new X837Element("01", "1270", "Identifier (ID)", "Mandatory", 1, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("02", "1271", "String (AN)", "Mandatory", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("03", "1250", "Identifier (ID)", "Conditional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("04", "1251", "String (AN)", "Conditional", 1, 35, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("05", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("06", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("07", "799", "String (AN)", "Optional", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("08", "1271", "String (AN)", "Conditional", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("09", "1073", "Identifier (ID)", "Conditional", 1, 1, 1, new string[] { }, new X837Element[]{ })
                    }),
                    new X837Element("HI09", "C022", "Composite (composite)", "Optional", -1, -1, 1, new string[] { }, new X837Element[]{
                        new X837Element("01", "1270", "Identifier (ID)", "Mandatory", 1, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("02", "1271", "String (AN)", "Mandatory", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("03", "1250", "Identifier (ID)", "Conditional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("04", "1251", "String (AN)", "Conditional", 1, 35, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("05", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("06", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("07", "799", "String (AN)", "Optional", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("08", "1271", "String (AN)", "Conditional", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("09", "1073", "Identifier (ID)", "Conditional", 1, 1, 1, new string[] { }, new X837Element[]{ })
                    }),
                    new X837Element("HI10", "C022", "Composite (composite)", "Optional", -1, -1, 1, new string[] { }, new X837Element[]{
                        new X837Element("01", "1270", "Identifier (ID)", "Mandatory", 1, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("02", "1271", "String (AN)", "Mandatory", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("03", "1250", "Identifier (ID)", "Conditional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("04", "1251", "String (AN)", "Conditional", 1, 35, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("05", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("06", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("07", "799", "String (AN)", "Optional", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("08", "1271", "String (AN)", "Conditional", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("09", "1073", "Identifier (ID)", "Conditional", 1, 1, 1, new string[] { }, new X837Element[]{ })
                    }),
                    new X837Element("HI11", "C022", "Composite (composite)", "Optional", -1, -1, 1, new string[] { }, new X837Element[]{
                        new X837Element("01", "1270", "Identifier (ID)", "Mandatory", 1, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("02", "1271", "String (AN)", "Mandatory", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("03", "1250", "Identifier (ID)", "Conditional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("04", "1251", "String (AN)", "Conditional", 1, 35, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("05", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("06", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("07", "799", "String (AN)", "Optional", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("08", "1271", "String (AN)", "Conditional", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("09", "1073", "Identifier (ID)", "Conditional", 1, 1, 1, new string[] { }, new X837Element[]{ })
                    }),
                    new X837Element("HI12", "C022", "Composite (composite)", "Optional", -1, -1, 1, new string[] { }, new X837Element[]{
                        new X837Element("01", "1270", "Identifier (ID)", "Mandatory", 1, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("02", "1271", "String (AN)", "Mandatory", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("03", "1250", "Identifier (ID)", "Conditional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("04", "1251", "String (AN)", "Conditional", 1, 35, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("05", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("06", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("07", "799", "String (AN)", "Optional", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("08", "1271", "String (AN)", "Conditional", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("09", "1073", "Identifier (ID)", "Conditional", 1, 1, 1, new string[] { }, new X837Element[]{ })
                    })
                },
new X837Segment[] { }),
            new X837Segment(
                "2400",
                "QTY",
                "Quantity Information",
                false,
                "10",
                "2300",
                false,
                "100",
                new X837Element[]{
                    new X837Element("QTY01", "673", "Identifier (ID)", "Mandatory", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("QTY02", "380", "Decimal number (R)", "Conditional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("QTY03", "C001", "Composite (composite)", "Optional", -1, -1, 1, new string[] { }, new X837Element[]{
                        new X837Element("01", "355", "Identifier (ID)", "Mandatory", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("02", "1018", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("03", "649", "Decimal number (R)", "Optional", 1, 10, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("04", "355", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("05", "1018", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("06", "649", "Decimal number (R)", "Optional", 1, 10, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("07", "355", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("08", "1018", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("09", "649", "Decimal number (R)", "Optional", 1, 10, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("10", "355", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("11", "1018", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("12", "649", "Decimal number (R)", "Optional", 1, 10, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("13", "355", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("14", "1018", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("15", "649", "Decimal number (R)", "Optional", 1, 10, 1, new string[] { }, new X837Element[]{ })
                    }),
                    new X837Element("QTY04", "61", "String (AN)", "Conditional", 1, 30, 1, new string[] { }, new X837Element[]{ })
                },
new X837Segment[] { }),
            new X837Segment(
                "2410",
                "HCP",
                "Health Care Pricing",
                false,
                "1",
                "2300",
                false,
                "100",
                new X837Element[]{
                    new X837Element("HCP01", "1473", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("HCP02", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("HCP03", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("HCP04", "127", "String (AN)", "Optional", 1, 50, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("HCP05", "118", "Decimal number (R)", "Optional", 1, 9, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("HCP06", "127", "String (AN)", "Optional", 1, 50, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("HCP07", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("HCP08", "234", "String (AN)", "Optional", 1, 48, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("HCP09", "235", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("HCP10", "234", "String (AN)", "Conditional", 1, 48, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("HCP11", "355", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("HCP12", "380", "Decimal number (R)", "Conditional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("HCP13", "901", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("HCP14", "1526", "Identifier (ID)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("HCP15", "1527", "Identifier (ID)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ })
                },
new X837Segment[] { }),
            new X837Segment(
                "2420",
                "CR7",
                "Home Health Treatment Plan Certification",
                true,
                "1",
                "2305",
                false,
                "6",
                new X837Element[]{
                    new X837Element("CR701", "921", "Identifier (ID)", "Mandatory", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR702", "1470", "Numeric (N0)", "Mandatory", 1, 9, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("CR703", "1470", "Numeric (N0)", "Mandatory", 1, 9, 1, new string[] { }, new X837Element[]{ })
                },
new X837Segment[] { }),
                new X837Segment(
                    "2430",
                    "HSD",
                    "Health Care Services Delivery",
                    false,
                    "12",
                    "2305",
                    false,
                    "6",
                    new X837Element[]{
                        new X837Element("HSD01", "673", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("HSD02", "380", "Decimal number (R)", "Conditional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("HSD03", "355", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("HSD04", "1167", "Decimal number (R)", "Optional", 1, 6, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("HSD05", "615", "Identifier (ID)", "Conditional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("HSD06", "616", "Numeric (N0)", "Optional", 1, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("HSD07", "678", "Identifier (ID)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("HSD08", "679", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ })
                    },
new X837Segment[] { }),
                new X837Segment(
                    "2950",
                    "CAS",
                    "Claims Adjustment",
                    false,
                    "99",
                    "2320",
                    false,
                    "10",
                    new X837Element[]{
                        new X837Element("CAS01", "1033", "Identifier (ID)", "Mandatory", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("CAS02", "1034", "Identifier (ID)", "Mandatory", 1, 5, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("CAS03", "782", "Decimal number (R)", "Mandatory", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("CAS04", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("CAS05", "1034", "Identifier (ID)", "Conditional", 1, 5, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("CAS06", "782", "Decimal number (R)", "Conditional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("CAS07", "380", "Decimal number (R)", "Conditional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("CAS08", "1034", "Identifier (ID)", "Conditional", 1, 5, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("CAS09", "782", "Decimal number (R)", "Conditional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("CAS10", "380", "Decimal number (R)", "Conditional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("CAS11", "1034", "Identifier (ID)", "Conditional", 1, 5, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("CAS12", "782", "Decimal number (R)", "Conditional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("CAS13", "380", "Decimal number (R)", "Conditional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("CAS14", "1034", "Identifier (ID)", "Conditional", 1, 5, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("CAS15", "782", "Decimal number (R)", "Conditional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("CAS16", "380", "Decimal number (R)", "Conditional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("CAS17", "1034", "Identifier (ID)", "Conditional", 1, 5, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("CAS18", "782", "Decimal number (R)", "Conditional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("CAS19", "380", "Decimal number (R)", "Conditional", 1, 15, 1, new string[] { }, new X837Element[]{ })
                    },
new X837Segment[] { }),
                new X837Segment(
                    "3100",
                    "OI",
                    "Other Health Insurance Information",
                    false,
                    "1",
                    "2320",
                    false,
                    "10",
                    new X837Element[]{
                        new X837Element("OI01", "1032", "Identifier (ID)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("OI02", "1383", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("OI03", "1073", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("OI04", "1351", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("OI05", "1360", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("OI06", "1363", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ })
                    },
new X837Segment[] { }),
                new X837Segment(
                    "3150",
                    "MIA",
                    "Medicare Inpatient Adjudication",
                    false,
                    "1",
                    "2320",
                    false,
                    "10",
                    new X837Element[]{
                        new X837Element("MIA01", "380", "Decimal number (R)", "Mandatory", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("MIA02", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("MIA03", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("MIA04", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("MIA05", "127", "String (AN)", "Optional", 1, 50, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("MIA06", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("MIA07", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("MIA08", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("MIA09", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("MIA10", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("MIA11", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("MIA12", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("MIA13", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("MIA14", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("MIA15", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("MIA16", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("MIA17", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("MIA18", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("MIA19", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("MIA20", "127", "String (AN)", "Optional", 1, 50, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("MIA21", "127", "String (AN)", "Optional", 1, 50, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("MIA22", "127", "String (AN)", "Optional", 1, 50, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("MIA23", "127", "String (AN)", "Optional", 1, 50, 1, new string[] { }, new X837Element[]{ }),
                    new X837Element("MIA24", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ })
                    },
new X837Segment[] { }),
                new X837Segment(
                    "3200",
                    "MOA",
                    "Medicare Outpatient Adjudication",
                    false,
                    "1",
                    "2320",
                    false,
                    "10",
                    new X837Element[]{
                        new X837Element("MOA01", "954", "Decimal number (R)", "Optional", 1, 10, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("MOA02", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("MOA03", "127", "String (AN)", "Optional", 1, 50, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("MOA04", "127", "String (AN)", "Optional", 1, 50, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("MOA05", "127", "String (AN)", "Optional", 1, 50, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("MOA06", "127", "String (AN)", "Optional", 1, 50, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("MOA07", "127", "String (AN)", "Optional", 1, 50, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("MOA08", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("MOA09", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ })
                    },
new X837Segment[] { }),
            new X837Segment(
                "3650",
                "LX",
                "Transaction Set Line Number",
                true,
                "1",
                "2400",
                false,
                ">1",
                new X837Element[]{
                    new X837Element("LX01", "554", "Numeric (N0)", "Mandatory", 1, 6, 1, new string[] { }, new X837Element[]{ })
                },
new X837Segment[] { }),
                new X837Segment(
                    "3700",
                    "SV1",
                    "Professional Service",
                    false,
                    "1",
                    "2400",
                    false,
                    ">1",
                    new X837Element[]{
                        new X837Element("SV101", "C003", "Composite (composite)", "Mandatory", -1, -1, 1, new string[] { }, new X837Element[]{
                            new X837Element("01", "235", "Identifier (ID)", "Mandatory", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("02", "234", "String (AN)", "Mandatory", 1, 48, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("03", "1339", "String (AN)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("04", "1339", "String (AN)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("05", "1339", "String (AN)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("06", "1339", "String (AN)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("07", "352", "String (AN)", "Optional", 1, 80, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("08", "234", "String (AN)", "Optional", 1, 48, 1, new string[] { }, new X837Element[]{ })
                        }),
                        new X837Element("SV102", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV103", "355", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV104", "380", "Decimal number (R)", "Conditional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV105", "1331", "String (AN)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV106", "1365", "Identifier (ID)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV107", "C004", "Composite (composite)", "Optional", -1, -1, 1, new string[] { }, new X837Element[]{
                            new X837Element("01", "1328", "Numeric (N0)", "Mandatory", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("02", "1328", "Numeric (N0)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("03", "1328", "Numeric (N0)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("04", "1328", "Numeric (N0)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ })
                        }),
                        new X837Element("SV108", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV109", "1073", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV110", "1340", "Identifier (ID)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV111", "1073", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV112", "1073", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV113", "1364", "Identifier (ID)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV114", "1341", "String (AN)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV115", "1327", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV116", "1334", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV117", "127", "String (AN)", "Optional", 1, 50, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV118", "116", "Identifier (ID)", "Optional", 3, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV119", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV120", "1337", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV121", "1360", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ })
                    },
new X837Segment[] { }),
                new X837Segment(
                    "3750",
                    "SV2",
                    "Institutional Service",
                    false,
                    "1",
                    "2400",
                    false,
                    ">1",
                    new X837Element[]{
                        new X837Element("SV201", "234", "String (AN)", "Conditional", 1, 48, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV202", "C003", "Composite (composite)", "Conditional", -1, -1, 1, new string[] { }, new X837Element[]{
                            new X837Element("01", "235", "Identifier (ID)", "Mandatory", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("02", "234", "String (AN)", "Mandatory", 1, 48, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("03", "1339", "String (AN)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("04", "1339", "String (AN)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("05", "1339", "String (AN)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("06", "1339", "String (AN)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("07", "352", "String (AN)", "Optional", 1, 80, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("08", "234", "String (AN)", "Optional", 1, 48, 1, new string[] { }, new X837Element[]{ })
                        }),
                        new X837Element("SV203", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV204", "355", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV205", "380", "Decimal number (R)", "Conditional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV206", "1371", "Decimal number (R)", "Optional", 1, 10, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV207", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV208", "1073", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV209", "1345", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV210", "1337", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ })
                    },
new X837Segment[] { }),
                new X837Segment(
                    "3800",
                    "SV3",
                    "Dental Service",
                    false,
                    "1",
                    "2400",
                    false,
                    ">1",
                    new X837Element[]{
                        new X837Element("SV301", "C003", "Composite (composite)", "Mandatory", -1, -1, 1, new string[] { }, new X837Element[]{
                            new X837Element("01", "235", "Identifier (ID)", "Mandatory", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("02", "234", "String (AN)", "Mandatory", 1, 48, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("03", "1339", "String (AN)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("04", "1339", "String (AN)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("05", "1339", "String (AN)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("06", "1339", "String (AN)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("07", "352", "String (AN)", "Optional", 1, 80, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("08", "234", "String (AN)", "Optional", 1, 48, 1, new string[] { }, new X837Element[]{ })
                        }),
                        new X837Element("SV302", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV303", "1331", "String (AN)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV304", "C006", "Composite (composite)", "Optional", -1, -1, 1, new string[] { }, new X837Element[]{
                            new X837Element("01", "1361", "Identifier (ID)", "Mandatory", 1, 3, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("02", "1361", "Identifier (ID)", "Optional", 1, 3, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("03", "1361", "Identifier (ID)", "Optional", 1, 3, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("04", "1361", "Identifier (ID)", "Optional", 1, 3, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("05", "1361", "Identifier (ID)", "Optional", 1, 3, 1, new string[] { }, new X837Element[]{ })
                        }),
                        new X837Element("SV305", "1358", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV306", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV307", "352", "String (AN)", "Optional", 1, 80, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV308", "1327", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV309", "1360", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV310", "1073", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV311", "C004", "Composite (composite)", "Optional", -1, -1, 1, new string[] { }, new X837Element[]{
                            new X837Element("01", "1328", "Numeric (N0)", "Mandatory", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("02", "1328", "Numeric (N0)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("03", "1328", "Numeric (N0)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("04", "1328", "Numeric (N0)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ })
                        })
                    },
new X837Segment[] { }),
                new X837Segment(
                    "3820",
                    "TOO",
                    "Tooth Identification",
                    false,
                    "32",
                    "2400",
                    false,
                    ">1",
                    new X837Element[]{
                        new X837Element("TOO01", "1270", "Identifier (ID)", "Conditional", 1, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("TOO02", "1271", "String (AN)", "Conditional", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("TOO03", "C005", "Composite (composite)", "Optional", -1, -1, 1, new string[] { }, new X837Element[]{
                            new X837Element("01", "1369", "Identifier (ID)", "Mandatory", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("02", "1369", "Identifier (ID)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("03", "1369", "Identifier (ID)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("04", "1369", "Identifier (ID)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("05", "1369", "Identifier (ID)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ })
                        })
                    },
new X837Segment[] { }),
                new X837Segment(
                    "3850",
                    "SV4",
                    "Drug Service",
                    false,
                    "1",
                    "2400",
                    false,
                    ">1",
                    new X837Element[]{
                        new X837Element("SV401", "127", "String (AN)", "Mandatory", 1, 50, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV402", "C003", "Composite (composite)", "Optional", -1, -1, 1, new string[] { }, new X837Element[]{
                            new X837Element("01", "235", "Identifier (ID)", "Mandatory", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("02", "234", "String (AN)", "Mandatory", 1, 48, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("03", "1339", "String (AN)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("04", "1339", "String (AN)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("05", "1339", "String (AN)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("06", "1339", "String (AN)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("07", "352", "String (AN)", "Optional", 1, 80, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("08", "234", "String (AN)", "Optional", 1, 48, 1, new string[] { }, new X837Element[]{ })
                        }),
                        new X837Element("SV403", "127", "String (AN)", "Optional", 1, 50, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV404", "1073", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV405", "1329", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV406", "1338", "Identifier (ID)", "Optional", 1, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV407", "1356", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV408", "352", "String (AN)", "Optional", 1, 80, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV409", "1073", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV410", "1073", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV411", "1370", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV412", "1319", "Identifier (ID)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV413", "1320", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV414", "1330", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV415", "1327", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV416", "1384", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV417", "1337", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV418", "1357", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ })
                    },
new X837Segment[] { }),
                new X837Segment(
                    "4000",
                    "SV5",
                    "Durable Medical Equipment Service",
                    false,
                    "1",
                    "2400",
                    false,
                    ">1",
                    new X837Element[]{
                        new X837Element("SV501", "C003", "Composite (composite)", "Mandatory", -1, -1, 1, new string[] { }, new X837Element[]{
                            new X837Element("01", "235", "Identifier (ID)", "Mandatory", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("02", "234", "String (AN)", "Mandatory", 1, 48, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("03", "1339", "String (AN)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("04", "1339", "String (AN)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("05", "1339", "String (AN)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("06", "1339", "String (AN)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("07", "352", "String (AN)", "Optional", 1, 80, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("08", "234", "String (AN)", "Optional", 1, 48, 1, new string[] { }, new X837Element[]{ })
                        }),
                        new X837Element("SV502", "355", "Identifier (ID)", "Mandatory", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV503", "380", "Decimal number (R)", "Mandatory", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV504", "782", "Decimal number (R)", "Conditional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV505", "782", "Decimal number (R)", "Conditional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV506", "594", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV507", "923", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ })
                    },
new X837Segment[] { }),
                new X837Segment(
                    "4050",
                    "SV6",
                    "Anesthesia Service",
                    false,
                    "1",
                    "2400",
                    false,
                    ">1",
                    new X837Element[]{
                        new X837Element("SV601", "C003", "Composite (composite)", "Mandatory", -1, -1, 1, new string[] { }, new X837Element[]{
                            new X837Element("01", "235", "Identifier (ID)", "Mandatory", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("02", "234", "String (AN)", "Mandatory", 1, 48, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("03", "1339", "String (AN)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("04", "1339", "String (AN)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("05", "1339", "String (AN)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("06", "1339", "String (AN)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("07", "352", "String (AN)", "Optional", 1, 80, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("08", "234", "String (AN)", "Optional", 1, 48, 1, new string[] { }, new X837Element[]{ })
                        }),
                        new X837Element("SV602", "1332", "Identifier (ID)", "Conditional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV603", "1331", "String (AN)", "Conditional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV604", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV605", "C004", "Composite (composite)", "Optional", -1, -1, 1, new string[] { }, new X837Element[]{
                            new X837Element("01", "1328", "Numeric (N0)", "Mandatory", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("02", "1328", "Numeric (N0)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("03", "1328", "Numeric (N0)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("04", "1328", "Numeric (N0)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ })
                        }),
                        new X837Element("SV606", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV607", "1073", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ })
                    },
new X837Segment[] { }),
                new X837Segment(
                    "4100",
                    "SV7",
                    "Drug Adjudication",
                    false,
                    "1",
                    "2400",
                    false,
                    ">1",
                    new X837Element[]{
                        new X837Element("SV701", "127", "String (AN)", "Optional", 1, 50, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV702", "127", "String (AN)", "Optional", 1, 50, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV703", "1355", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV704", "1207", "Identifier (ID)", "Mandatory", 3, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV705", "750", "Identifier (ID)", "Mandatory", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SV706", "1073", "Identifier (ID)", "Optional", 1, 1, 1, new string[] { }, new X837Element[]{ })
                    },
new X837Segment[] { }),
                new X837Segment(
                    "4620",
                    "MEA",
                    "Measurements",
                    false,
                    "20",
                    "2400",
                    false,
                    ">1",
                    new X837Element[]{
                        new X837Element("MEA01", "737", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("MEA02", "738", "Identifier (ID)", "Optional", 1, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("MEA03", "739", "Decimal number (R)", "Conditional", 1, 20, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("MEA04", "C001", "Composite (composite)", "Conditional", -1, -1, 1, new string[] { }, new X837Element[]{
                            new X837Element("01", "355", "Identifier (ID)", "Mandatory", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("02", "1018", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("03", "649", "Decimal number (R)", "Optional", 1, 10, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("04", "355", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("05", "1018", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("06", "649", "Decimal number (R)", "Optional", 1, 10, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("07", "355", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("08", "1018", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("09", "649", "Decimal number (R)", "Optional", 1, 10, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("10", "355", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("11", "1018", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("12", "649", "Decimal number (R)", "Optional", 1, 10, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("13", "355", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("14", "1018", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("15", "649", "Decimal number (R)", "Optional", 1, 10, 1, new string[] { }, new X837Element[]{ })
                        }),
                        new X837Element("MEA05", "740", "Decimal number (R)", "Conditional", 1, 20, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("MEA06", "741", "Decimal number (R)", "Conditional", 1, 20, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("MEA07", "935", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("MEA08", "936", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("MEA09", "752", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("MEA10", "1373", "Identifier (ID)", "Optional", 2, 4, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("MEA11", "1270", "Identifier (ID)", "Conditional", 1, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("MEA12", "1271", "String (AN)", "Conditional", 1, 30, 1, new string[] { }, new X837Element[]{ })
                    },
new X837Segment[] { }),
                new X837Segment(
                    "4880",
                    "PS1",
                    "Purchase Service",
                    false,
                    "1",
                    "2400",
                    false,
                    ">1",
                    new X837Element[]{
                        new X837Element("PS101", "127", "String (AN)", "Mandatory", 1, 50, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("PS102", "782", "Decimal number (R)", "Mandatory", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("PS103", "156", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ })
                    },
new X837Segment[] { }),
                new X837Segment(
                    "4900",
                    "IMM",
                    "Immunization Status",
                    false,
                    ">1",
                    "2400",
                    false,
                    ">1",
                    new X837Element[]{
                        new X837Element("IMM01", "1271", "String (AN)", "Mandatory", 1, 30, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("IMM02", "1250", "Identifier (ID)", "Conditional", 2, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("IMM03", "1251", "String (AN)", "Conditional", 1, 35, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("IMM04", "1254", "Identifier (ID)", "Conditional", 1, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("IMM05", "755", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("IMM06", "1270", "Identifier (ID)", "Mandatory", 1, 3, 1, new string[] { }, new X837Element[]{ })
                    },
new X837Segment[] { }),
                new X837Segment(
                    "4930",
                    "LIN",
                    "Item Identification",
                    true,
                    "1",
                    "2410",
                    false,
                    ">1",
                    new X837Element[]{
                        new X837Element("LIN01", "350", "String (AN)", "Optional", 1, 20, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("LIN02", "235", "Identifier (ID)", "Mandatory", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("LIN03", "234", "String (AN)", "Mandatory", 1, 48, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("LIN04", "235", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("LIN05", "234", "String (AN)", "Conditional", 1, 48, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("LIN06", "235", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("LIN07", "234", "String (AN)", "Conditional", 1, 48, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("LIN08", "235", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("LIN09", "234", "String (AN)", "Conditional", 1, 48, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("LIN10", "235", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("LIN11", "234", "String (AN)", "Conditional", 1, 48, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("LIN12", "235", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("LIN13", "234", "String (AN)", "Conditional", 1, 48, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("LIN14", "235", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("LIN15", "234", "String (AN)", "Conditional", 1, 48, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("LIN16", "235", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("LIN17", "234", "String (AN)", "Conditional", 1, 48, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("LIN18", "235", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("LIN19", "234", "String (AN)", "Conditional", 1, 48, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("LIN20", "235", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("LIN21", "234", "String (AN)", "Conditional", 1, 48, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("LIN22", "235", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("LIN23", "234", "String (AN)", "Conditional", 1, 48, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("LIN24", "235", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("LIN25", "234", "String (AN)", "Conditional", 1, 48, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("LIN26", "235", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("LIN27", "234", "String (AN)", "Conditional", 1, 48, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("LIN28", "235", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("LIN29", "234", "String (AN)", "Conditional", 1, 48, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("LIN30", "235", "Identifier (ID)", "Conditional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("LIN31", "234", "String (AN)", "Conditional", 1, 48, 1, new string[] { }, new X837Element[]{ })
                    },
new X837Segment[] { }),
                    new X837Segment(
                        "4940",
                        "CTP",
                        "Pricing Information",
                        false,
                        "1",
                        "2410",
                        false,
                        ">1",
                        new X837Element[]{
                            new X837Element("CTP01", "687", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("CTP02", "236", "Identifier (ID)", "Conditional", 3, 3, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("CTP03", "212", "Decimal number (R)", "Conditional", 1, 17, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("CTP04", "380", "Decimal number (R)", "Conditional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("CTP05", "C001", "Composite (composite)", "Conditional", -1, -1, 1, new string[] { }, new X837Element[]{
                                new X837Element("01", "355", "Identifier (ID)", "Mandatory", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                                new X837Element("02", "1018", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                                new X837Element("03", "649", "Decimal number (R)", "Optional", 1, 10, 1, new string[] { }, new X837Element[]{ }),
                                new X837Element("04", "355", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                                new X837Element("05", "1018", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                                new X837Element("06", "649", "Decimal number (R)", "Optional", 1, 10, 1, new string[] { }, new X837Element[]{ }),
                                new X837Element("07", "355", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                                new X837Element("08", "1018", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                                new X837Element("09", "649", "Decimal number (R)", "Optional", 1, 10, 1, new string[] { }, new X837Element[]{ }),
                                new X837Element("10", "355", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                                new X837Element("11", "1018", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                                new X837Element("12", "649", "Decimal number (R)", "Optional", 1, 10, 1, new string[] { }, new X837Element[]{ }),
                                new X837Element("13", "355", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                                new X837Element("14", "1018", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                                new X837Element("15", "649", "Decimal number (R)", "Optional", 1, 10, 1, new string[] { }, new X837Element[]{ })
                            }),
                            new X837Element("CTP06", "648", "Identifier (ID)", "Optional", 3, 3, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("CTP07", "649", "Decimal number (R)", "Conditional", 1, 10, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("CTP08", "782", "Decimal number (R)", "Optional", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("CTP09", "639", "Identifier (ID)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("CTP10", "499", "String (AN)", "Optional", 1, 10, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("CTP11", "289", "Numeric (N0)", "Optional", 1, 2, 1, new string[] { }, new X837Element[]{ })
                        },
new X837Segment[] { }),
                new X837Segment(
                    "5400",
                    "SVD",
                    "Service Line Adjudication",
                    true,
                    "1",
                    "2430",
                    false,
                    ">1",
                    new X837Element[]{
                        new X837Element("SVD01", "67", "String (AN)", "Mandatory", 2, 80, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SVD02", "782", "Decimal number (R)", "Mandatory", 1, 18, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SVD03", "C003", "Composite (composite)", "Optional", -1, -1, 1, new string[] { }, new X837Element[]{
                            new X837Element("01", "235", "Identifier (ID)", "Mandatory", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("02", "234", "String (AN)", "Mandatory", 1, 48, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("03", "1339", "String (AN)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("04", "1339", "String (AN)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("05", "1339", "String (AN)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("06", "1339", "String (AN)", "Optional", 2, 2, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("07", "352", "String (AN)", "Optional", 1, 80, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("08", "234", "String (AN)", "Optional", 1, 48, 1, new string[] { }, new X837Element[]{ })
                        }),
                        new X837Element("SVD04", "234", "String (AN)", "Optional", 1, 48, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SVD05", "380", "Decimal number (R)", "Optional", 1, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("SVD06", "554", "Numeric (N0)", "Optional", 1, 6, 1, new string[] { }, new X837Element[]{ })
                    },
new X837Segment[] { }),
                new X837Segment(
                    "5510",
                    "LQ",
                    "Industry Code Identification",
                    true,
                    "1",
                    "2440",
                    false,
                    ">1",
                    new X837Element[]{
                        new X837Element("LQ01", "1270", "Identifier (ID)", "Optional", 1, 3, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("LQ02", "1271", "String (AN)", "Conditional", 1, 30, 1, new string[] { }, new X837Element[]{ })
                    },
new X837Segment[] { }),
                    new X837Segment(
                        "5520",
                        "FRM",
                        "Supporting Documentation",
                        true,
                        "99",
                        "2440",
                        false,
                        ">1",
                        new X837Element[]{
                            new X837Element("FRM01", "350", "String (AN)", "Mandatory", 1, 20, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("FRM02", "1073", "Identifier (ID)", "Conditional", 1, 1, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("FRM03", "127", "String (AN)", "Conditional", 1, 50, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("FRM04", "373", "Date (DT)", "Conditional", 8, 8, 1, new string[] { }, new X837Element[]{ }),
                            new X837Element("FRM05", "332", "Decimal number (R)", "Conditional", 1, 6, 1, new string[] { }, new X837Element[]{ })
                        },
new X837Segment[] { }),
    new X837Segment(
        "5550",
        "SE",
        "Transaction Set Trailer",
        true,
        "1",
        null,
        false,
        null,
        new X837Element[]{
            new X837Element("SE01", "96", "Numeric (N0)", "Mandatory", 1, 10, 1, new string[] { }, new X837Element[]{ }),
            new X837Element("SE02", "329", "String (AN)", "Mandatory", 4, 9, 1, new string[] { }, new X837Element[]{ })
        },
new X837Segment[] { })
};
            X12_Other = new X837Segment[]
            {
                new X837Segment(
                    null,
                    "GS",
                    "Functional Group Header",
                    false,
                    ">1",
                    null,
                    false,
                    null,
                    new X837Element[] {
                        new X837Element("GS01", "479", "Identifier (ID)", "Mandatory", 2, 2, 1, new string[] { "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BL", "BS", "CA", "CB", "CC", "CD", "CE", "CF", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "D3", "D4", "D5", "DA", "DD", "DF", "DI", "DM", "DS", "DX", "EC", "ED", "EI", "EN", "EP", "ER", "ES", "EV", "EX", "FA", "FB", "FC", "FG", "FR", "FT", "GC", "GE", "GF", "GL", "GP", "GR", "GT", "HB", "HC", "HI", "HN", "HP", "HR", "HS", "HU", "HV", "IA", "IB", "IC", "ID", "IE", "IF", "IG", "IH", "IJ", "IM", "IN", "IO", "IR", "IS", "JB", "KM", "LA", "LB", "LI", "LN", "LR", "LS", "LT", "MA", "MC", "MD", "ME", "MF", "MG", "MH", "MI", "MJ", "MK", "MM", "MN", "MO", "MP", "MQ", "MR", "MS", "MT", "MV", "MW", "MX", "MY", "MZ", "NC", "NL", "NP", "NR", "NT", "OC", "OG", "OR", "OW", "PA", "PB", "PC", "PD", "PE", "PF", "PG", "PH", "PI", "PJ", "PK", "PL", "PN", "PO", "PQ", "PR", "PS", "PT", "PU", "PV", "PW", "PY", "QG", "QM", "QO", "RA", "RB", "RC", "RD", "RE", "RF", "RG", "RH", "RI", "RJ", "RK", "RL", "RM", "RN", "RO", "RP", "RQ", "RR", "RS", "RT", "RU", "RV", "RW", "RX", "RY", "RZ", "SA", "SB", "SC", "SD", "SE", "SH", "SI", "SJ", "SL", "SM", "SN", "SO", "SP", "SQ", "SR", "SS", "ST", "SU", "SV", "SW", "TA", "TB", "TD", "TE", "TF", "TI", "TJ", "TM", "TN", "TO", "TP", "TR", "TS", "TT", "TU", "TX", "UA", "UB", "UC", "UD", "UI", "UP", "UW", "VA", "VB", "VC", "VD", "VE", "VH", "VI", "VS", "WA", "WB", "WG", "WI", "WL", "WR", "WT" }, new X837Element[]{ }),
                        new X837Element("GS02", "142", "String (AN)", "Mandatory", 2, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("GS03", "124", "String (AN)", "Mandatory", 2, 15, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("GS04", "373", "Date (DT)", "Mandatory", 8, 8, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("GS05", "337", "Time (TM)", "Mandatory", 4, 8, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("GS06", "28", "Numeric (N0)", "Mandatory", 1, 9, 1, new string[] { "T", "X" }, new X837Element[]{ }),
                        new X837Element("GS07", "455", "Identifier (ID)", "Mandatory", 1, 2, 1, new string[] { "T", "X" }, new X837Element[]{ }),
                        new X837Element("GS08", "480", "String (AN)", "Mandatory", 1, 12, 1, new string[] { "001000", "002000", "002001", "002002", "002003", "002031", "002040", "002041", "002042", "003000", "003010", "003011", "003012", "003020", "003021", "003022", "003030", "003031", "003032", "003040", "003041", "003042", "003050", "003051", "003052", "003060", "003061", "003062", "003070", "003071", "003072", "004000", "004010", "004011", "004012", "004020", "004021", "004022", "004030", "004031", "004032", "004040", "004041", "004042", "004050", "004051", "004052", "004060", "004061", "004062", "005000", "005010" }, new X837Element[]{ })
                    },
                    new X837Segment[] { }
                ),
                new X837Segment(
                    null,
                    "GE",
                    "Functional Group Trailer",
                    false,
                    ">1",
                    null,
                    false,
                    null,
                    new X837Element[] {
                        new X837Element("GE01", "97", "Numeric (N0)", "Mandatory", 1, 6, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("GE02", "28", "Numeric (N0)", "Mandatory", 1, 9, 1, new string[] { }, new X837Element[]{ })
                    },
                    new X837Segment[] { }
                ),
                new X837Segment(
                    null,
                    "IEA",
                    "Interchange Control Trailer",
                    false,
                    ">1",
                    null,
                    false,
                    null,
                    new X837Element[] {
                        new X837Element("IEA01", "I16", "Numeric (N0)", "Mandatory", 1, 5, 1, new string[] { }, new X837Element[]{ }),
                        new X837Element("IEA02", "I12", "Numeric (N0)", "Mandatory", 9, 9, 1, new string[] { }, new X837Element[]{ })
                    },
                    new X837Segment[] { }
                )
            };
        }

        public static string FormatVal(string segmentname, string elementname, string paramval)
        {
            string returnval = paramval;
            foreach (X837Segment x12837 in X12_837.ToList())
            {
                string formattedval = x12837.findElement(segmentname, elementname, paramval);
                if (formattedval != null)
                {
                    returnval = formattedval;
                    break;
                }
            }
            return returnval;
        }

        public static string OtherFormatVal(string segmentname, string elementname, string paramval)
        {
            string returnval = paramval;
            foreach (X837Segment x12oth in X12_Other.ToList())
            {
                string formattedval = x12oth.findElement(segmentname, elementname, paramval);
                if (formattedval != null)
                {
                    returnval = formattedval;
                    break;
                }
            }
            return returnval;
        }

        public static void RetrieveConfig()
        {
            Items["SUBMITTER_NAME"] = "HEALTH CARE RESOURCES";
            Items["RECEIVER_NAME"] = "HEALTH CARE RESOURCES";

            Items["ISA01"] = FormatVal("ISA", "ISA01", "00");
            Items["ISA02"] = FormatVal("ISA", "ISA02", "");
            Items["ISA03"] = FormatVal("ISA", "ISA03", "00");
            Items["ISA04"] = FormatVal("ISA", "ISA04", "");
            Items["ISA05"] = FormatVal("ISA", "ISA05", "ZZ");
            Items["ISA06"] = FormatVal("ISA", "ISA06", "491776");
            Items["ISA07"] = FormatVal("ISA", "ISA07", "ZZ");
            Items["ISA08"] = FormatVal("ISA", "ISA08", "");
            Items["ISA11"] = FormatVal("ISA", "ISA11", "^");
            Items["ISA12"] = FormatVal("ISA", "ISA12", "00501");
            Items["ISA14"] = FormatVal("ISA", "ISA14", "0");
            Items["ISA15"] = FormatVal("ISA", "ISA15", "T");
            Items["ISA16"] = FormatVal("ISA", "ISA16", ":");

            Items["GS01"] = OtherFormatVal("GS", "GS01", "XX");
            Items["GS02"] = OtherFormatVal("GS", "GS02", "491776");
            Items["GS03"] = OtherFormatVal("GS", "GS03", "");
            Items["GS07"] = OtherFormatVal("GS", "GS07", "X");
            Items["GS08"] = OtherFormatVal("GS", "GS08", "005010X222A1");

            Items["BHT02"] = FormatVal("BHT","BHT02","00");
            Items["BHT06"] = FormatVal("BHT","BHT06","CH");

            Items["1000A_NM102"] = FormatVal("NM1","NM102","2");
            Items["1000A_NM103"] = FormatVal("NM1","NM103","HEALTH CARE RESOURCES, INC");
            Items["1000A_NM104"] = FormatVal("NM1","NM104",String.Empty);
            Items["1000A_NM105"] = FormatVal("NM1","NM105",String.Empty);
            Items["1000A_NM108"] = FormatVal("NM1","NM108","46");
            Items["1000A_NM109"] = FormatVal("NM1","NM109","SUBMITTER_ID");

            Items["1000A_PER02"] = FormatVal("PER","PER02","SUBMITTER_ID");
            Items["1000A_PER03"] = FormatVal("PER","PER03","TE");
            Items["1000A_PER04"] = FormatVal("PER","PER04","2018140700");
            Items["1000A_PER05"] = FormatVal("PER","PER05",String.Empty);// "EM";
            Items["1000A_PER06"] = FormatVal("PER","PER06",String.Empty);// "marlonsvillarama@gmail.com";
            Items["1000A_PER07"] = FormatVal("PER","PER07",String.Empty);// "FX";
            Items["1000A_PER08"] = FormatVal("PER","PER08",String.Empty);// "1234567890";

            Items["2000A_PRV03"] = FormatVal("PRV","PRV03",String.Empty); // "0000XX3790";

            Items["2010AA_ISPERSON"] = "F";
            Items["2010AA_NM103"] = FormatVal("NM1","NM103","2010AA_NM103");
            Items["2010AA_NM104"] = FormatVal("NM1","NM104","2010AA_NM104");
            Items["2010AA_NM105"] = FormatVal("NM1","NM105","2010AA_NM105");
            Items["2010AA_NM107"] = FormatVal("NM1","NM107","2010AA_NM107");
            Items["2010AA_NM108"] = FormatVal("NM1","NM108","XX");

            Items["2010AA_N301"] = FormatVal("N3","N301","570 kinderkamack rd");
            Items["2010AA_N302"] = FormatVal("N3","N302","BRGY BUNGAD");
            Items["2010AA_N401"] = FormatVal("N4","N401","QUEZON CITY");
            Items["2010AA_N402"] = FormatVal("N4","N402","MM");
            Items["2010AA_N403"] = FormatVal("N4","N403","12345");
            Items["2010AA_N404"] = FormatVal("N4","N404","PH");
            Items["2010AA_N407"] = FormatVal("N4","N407","2010AA_NM407");

            Items["2010AA_REF01"] = FormatVal("REF", "REF01", "EI");
            Items["2010AA_REF02"] = FormatVal("REF", "REF02", "123456789");
            Items["2010AA_REF01_UPIN"] = FormatVal("REF", "REF01", "0B");
            Items["2010AA_REF02_UPIN"] = FormatVal("REF", "REF02", "A12345");

            Items["2010AA_PER02"] = FormatVal("PER","PER02","SIMON RYOO");
            Items["2010AA_PER03"] = FormatVal("PER","PER03","TE");
            Items["2010AA_PER04"] = FormatVal("PER","PER04","6098789232");
            Items["2010AA_PER05"] = FormatVal("PER","PER05","EM");
            Items["2010AA_PER06"] = FormatVal("PER","PER06","MARLONSVILLARAMA@GMAIL.COM");

            Items["2010AB_NM102"] = FormatVal("NM1","NM102","2");
            Items["2010AB_NM103"] = FormatVal("NM1","NM103","2010AB_NM103");
            Items["2010AB_NM108"] = FormatVal("NM1","NM108","PI");
            Items["2010AB_NM109"] = FormatVal("NM1","NM109","2010AB_NM109");

            Items["2010AC_NM103"] = FormatVal("NM1", "NM103", "2010AC_NM103");
            Items["2010AC_NM108"] = FormatVal("NM1", "NM108", "PI");
            Items["2010AC_NM109"] = FormatVal("NM1", "NM109", "989898");
            Items["2010AC_N301"] = FormatVal("N3", "N301", "MEM 3");
            Items["2010AC_N302"] = FormatVal("N3", "N302", "G ENRIQUEZ ST");
            Items["2010AA_REF01"] = FormatVal("REF", "REF01", "2U");
            Items["2010AA_REF02"] = FormatVal("REF", "REF02", "123456789");
            Items["2010AC_REF_Tax"] = "2010AC_REF_Tax";
        }

        public static int LevenshteinDistance(string source, string target)
        {
            if (String.IsNullOrEmpty(source))
            {
                if (String.IsNullOrEmpty(target)) return 0;
                return target.Length;
            }
            if (String.IsNullOrEmpty(target)) return source.Length;

            if (source.Length > target.Length)
            {
                var temp = target;
                target = source;
                source = temp;
            }

            var m = target.Length;
            var n = source.Length;
            var distance = new int[2, m + 1];
            // Initialize the distance 'matrix'
            for (var j = 1; j <= m; j++) distance[0, j] = j;

            var currentRow = 0;
            for (var i = 1; i <= n; ++i)
            {
                currentRow = i & 1;
                distance[currentRow, 0] = i;
                var previousRow = currentRow ^ 1;
                for (var j = 1; j <= m; j++)
                {
                    var cost = (target[j - 1] == source[i - 1] ? 0 : 1);
                    distance[currentRow, j] = Math.Min(Math.Min(
                        distance[previousRow, j] + 1,
                        distance[currentRow, j - 1] + 1),
                        distance[previousRow, j - 1] + cost);
                }
            }
            return distance[currentRow, m];
        }

    }
}