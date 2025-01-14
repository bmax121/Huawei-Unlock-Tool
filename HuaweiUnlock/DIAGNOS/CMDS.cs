﻿using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace HuaweiUnlocker.DIAGNOS
{
    public class Port_D
    {
        public string ComName;
        public string FullName;
    }
    public class IDentifyDev
    {
        public string BSN = "NaN";
        public string BUILD = "NaN";
        public string VERSION = "NaN";
        public string SerialNum = "NaN";
        public string HWID = "NaN";
        public string SWID = "NaN";
        public string PK_HASH = "NaN";
        public string SBLV = "NaN";
        public string Name = "Unknown";
        public Dictionary<string, Partition> Partitions = new Dictionary<string, Partition>();
        public bool loadedhose = false;
        public Port_D Port = new Port_D();
    }
    class GPT_Struct
    {
        public int StartAdress;
        public int Length;
        public string ValueString;
        public GPT_Struct(int startAdress = -1, int length = -1, string value = "")
        {
            StartAdress = startAdress;
            Length = length;
            ValueString = value;
        }
    }
    public struct Partition
    {
        public string BlockStart;
        public string BlockEnd;
        public string BlockLength;
        public string BlockNumSectors;
        public string BlockBytes;
    }
    public class CMDS
    {
        public static bool GetStatus(byte[] buff)
        {
            if (buff.Length <= 0 || buff == null) return false;
            return !(buff[0] == 19 || buff[0] == 21);
        }
        public static string GetStatusStr(byte[] buff)
        {
            if (buff.Length <= 0 || buff == null) return "[ERROR] No Response";
            if (buff[0] == 19 || buff[0] == 21) return "[ERROR] Acces Denied or Command Wrong";
            return "[INFO] Success";
        }
        public static string REBOOT_OR_3RECOVERY = "3A";
        public static string SET_STATE = "29";
        public static string HW_CMD = "4BC9";
        public static string GET_NV = "26";
        public static string GET_TIME = "00";

        public static int LENDB = 64;
        public static int LENKEY = 512;
        public static int LENPC = 256;
        public static int LENRSA2 = 2048;
        public static int LENRSA1 = 1024;

        public static string DONGLEINFO = "000008004F43544F504C555300000000000000001027010001000008";
        public struct PCUI
        {
            public static string AT_GET_INFO = "ATI\r";
            public static string AT_GOTO_QCDMG = "AT$QCDMG=115200\r";
            public static string PCUI_UNKNOWN = "2600";
            public static string PCUI_UNKNOWN2 = "2672";
        }
        public struct DBADAPTER
        {
            public static string OEM_GET_DIAG_KEY = "EDEE";
            public static string OEM_REWRITE_KEY = "75EE";
            public static string OEM_BOARDINFO = "3CFF";
            public static string OEM_WRITE_BSN = "4EFF";
            public static string OEM_AUTH_WITH = "CCEE";
            public static string OEM_FACTORY_RESET = "28FF01";
            public static string NV_IMEI = "2602";
            public static string NV_FIRMWAREINFO = "72";
            public static string ERASE_REGION_GUESS = "36FF";
            public static string UNKNOWN_0 = "31FF";
            public static string UNKNOWN_1 = "D6EE";
            public static string UNKNOWN_2 = "02EE";
            public static string UNKNOWN_3 = "55EE";
        }
    }
}
