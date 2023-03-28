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
    [Table(Name = "MONHOC")]
    public class MONHOC
    {
        private string _MaMonHoc;
        [Column(Name = "MaMonHoc", DbType = "nvarchar(10)", IsPrimaryKey = true)]
        public string MaMonHoc
        {
            get { return _MaMonHoc; }
            set { _MaMonHoc = value; }
        }

        private string _TenMonHoc;
        [Column(Name = "TenMonHoc", DbType = "nvarchar(50")]
        public string TenMonHoc
        {
            get { return _TenMonHoc; }
            set { _TenMonHoc = value; }
        }

        private int _SoTinChi;
        [Column(Name = "SoTinChi", DbType = "int")]
        public int SoTinChi
        {
            get { return _SoTinChi; }
            set { _SoTinChi = value; }
        }

        private string _MaKhoa;
        [Column(Name = "MaKhoa", DbType = "varchar(10)")]
        public string MaKhoa
        {
            get { return _MaKhoa; }
            set { _MaKhoa = value; }
        }

        private EntityRef<KHOA> _thuocKhoa = new EntityRef<KHOA>();// mapping mối quan hệ
        [Association(Name = "ct_k", IsForeignKey = true,
            Storage = "_thuocKhoa", ThisKey = "MaKhoa", OtherKey = "MaKhoa")]
        public KHOA thuocKhoa // con trỏ
        {
            get { return _thuocKhoa.Entity; }
            set { _thuocKhoa.Entity = value; }
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

        public MONHOC() { }// hàm tạo không tham số
        public MONHOC(string _ma, string _ten, int _stc, KHOA _k)
        {
            MaMonHoc = _ma; TenMonHoc = _ten; SoTinChi = _stc; thuocKhoa = _k;            
            MaKhoa = _k.MaKhoa;
           
        }
    }
}
