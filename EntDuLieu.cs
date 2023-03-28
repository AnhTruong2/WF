using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class EntDuLieu
    {
        public Table<KHOA> KHOAs;
        public Table<GIAOVIEN> GIAOVIENs;
        public Table<CHUONGTRINH> CHUONGTRINHs;
        public Table<MONHOC> MONHOCs;
        public Table<CHUONGTRINHMONHOC> CHUONGTRINHMONHOCs;

        
        public DataContext dc;

        public EntDuLieu()
        {
            dc = new DataContext("server=DESKTOP-0CFABTS;database = WF;Trusted_Connection = True");
            KHOAs = dc.GetTable<KHOA>();
            GIAOVIENs = dc.GetTable<GIAOVIEN>();
            CHUONGTRINHs = dc.GetTable<CHUONGTRINH>();
            MONHOCs = dc.GetTable<MONHOC>();
            CHUONGTRINHMONHOCs = dc.GetTable<CHUONGTRINHMONHOC>();
          
        }

    }




}
