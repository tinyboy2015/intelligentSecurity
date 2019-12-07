using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectHdDataLib
{
    public struct TransferData
    {
        public string areaNo { get; set; }
        public AlarmType areaType { get; set; }
        public string areaData { get; set; }
        public string areaTime { get; set; }
        public TransferData(DatabaseOpClassLibrary.DataBase dbop, string AreaNo, AlarmType AreaType, string AreaData)
        {
            areaNo = AreaNo;
            areaType = AreaType;
            areaData = AreaData;
            areaTime = DateTime.Now.ToString("yyyyMMdd-HH: mm:ss");
            string sql2 = "insert into s_areainfo (areano, areatype, areadata, areatime) values('" + AreaNo + "','" + AreaType + "','" + AreaData + "','" + areaTime + "')";
            dbop.ExecNonQuery(sql2);

        }
    }
}
