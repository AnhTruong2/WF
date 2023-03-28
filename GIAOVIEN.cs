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
    [Table(Name = "GIAOVIEN")]
    public class GIAOVIEN
    {
        private string _MaGiaoVien;
        [Column(Name = "MaGiaoVien", DbType = "varchar(10)", IsPrimaryKey = true)]
        public string MaGiaoVien
        {
            get { return _MaGiaoVien; }
            set { _MaGiaoVien = value; }
        }

        private EntitySet<CHUONGTRINH> _dsChuongTrinh// mapping mqh thứ 2
            = new EntitySet<CHUONGTRINH>();
        [Association(
            Storage = "_dsChuongTrinh",
            OtherKey = "MaChuongTrinh")]

        public EntitySet<CHUONGTRINH> dsChuongTrinh
        {
            set { _dsChuongTrinh.Assign(value); }
            get { return _dsChuongTrinh; }
        }

        private string _HoTen;
        [Column(Name = "HoTen", DbType = "varchar(50)")]
        public string HoTen
        { 
            get { return _HoTen; }
            set { _HoTen = value; }
        }

    }
}
