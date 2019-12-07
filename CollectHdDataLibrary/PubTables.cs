using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectHdDataLib
{
    public enum SerialCommuType
    {
        Alarm,
        Wave,
    }
    public enum AlarmType
    {
        Broken,
        Intrusion
    }

    public struct spinfo
    {
        public string _spName;
        public SerialCommuType _type;
        public spinfo(string spName, SerialCommuType type)
        {
            _spName = spName;
            _type = type;
        }
    }

    public static class SpToAreaTbl
    {
        public static Dictionary<string, string> dicSptoArea = new Dictionary<string, string>();
        public static List<spinfo> listSp = new List<spinfo>();
        static SpToAreaTbl()
        {
            dicSptoArea["com3_1"] = "301";
            dicSptoArea["com3_2"] = "311";
            dicSptoArea["com3_3"] = "321";
            dicSptoArea["com3_4"] = "331";
            dicSptoArea["com3_5"] = "341";
            dicSptoArea["com3_6"] = "351";
            dicSptoArea["com3_7"] = "361";
            dicSptoArea["com3_8"] = "371";

            dicSptoArea["com4_1"] = "401";
            dicSptoArea["com4_2"] = "411";
            dicSptoArea["com4_3"] = "421";
            dicSptoArea["com4_4"] = "431";
            dicSptoArea["com4_5"] = "441";
            dicSptoArea["com4_6"] = "451";
            dicSptoArea["com4_7"] = "461";
            dicSptoArea["com4_8"] = "471";

            dicSptoArea["com5_1"] = "501";
            dicSptoArea["com5_2"] = "511";
            dicSptoArea["com5_3"] = "521";
            dicSptoArea["com5_4"] = "531";
            dicSptoArea["com5_5"] = "541";
            dicSptoArea["com5_6"] = "551";
            dicSptoArea["com5_7"] = "561";
            dicSptoArea["com5_8"] = "571";

            listSp.Add(new spinfo("com3", SerialCommuType.Alarm));
            listSp.Add(new spinfo("com4", SerialCommuType.Alarm));
            listSp.Add(new spinfo("com5", SerialCommuType.Alarm));
        }
    }
}
