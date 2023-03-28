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
    [Table(Name = "KHOA" )]
    public class KHOA
    {
        private string _MaKhoa;
        [Column(Name = "MaKhoa", DbType = "varchar(10)", IsPrimaryKey = true)]
        public string MaKhoa
        {
            get { return _MaKhoa; }
            set { _MaKhoa = value; }
        }

        private EntitySet<CHUONGTRINH> _dsChuongTrinh// mapping mqh thứ 2
            = new EntitySet<CHUONGTRINH>();
        [Association(
            Storage = "_dsChuongTrinh",
            OtherKey = "MaChuongTrinh")]

        public EntitySet<CHUONGTRINH> dsChuongTrinh
        {
            set { _dsChuongTrinh.Assign( value); }
            get { return _dsChuongTrinh; }
        }

        private string _TenKhoa;
        [Column(Name = "TenKhoa", DbType = "nvarchar(50)" )]
        public string TenKhoa
        {
            get { return _TenKhoa; }
            set { _TenKhoa = value; }
        }
    }
}
