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
    [Table(Name = "CHUONGTRINH")]
    public class CHUONGTRINH
    {
        private string _MaChuongTrinh;
        [Column(Name = "MaChuongTrinh", DbType = "nvarchar(5)", IsPrimaryKey = true)]
        public string MaChuongTrinh
        {
            get { return _MaChuongTrinh; }
            set { _MaChuongTrinh = value; }
        }
        private string _TenChuongTrinh;
        [Column(Name = "TenChuongTrinh", DbType = "nvarchar(50)")]
        public string TenChuongTrinh
        {
            get { return _TenChuongTrinh; }
            set { _TenChuongTrinh = value; }
        }
        private string _MaBacHoc;
        [Column(Name = "MaBacHoc", DbType = "char(2)")]
        public string MaBacHoc
        {
            get { return _MaBacHoc; }
            set { _MaBacHoc = value; }
        }
        private string _MaKhoa;
        [Column(Name = "MaKhoa", DbType = "varchar(10)", IsPrimaryKey = true)]
        public string MaKhoa
        {
            get { return _MaKhoa; }
            set { _MaKhoa = value; }
        }
        private string _MaGiaoVien_GiamDocCT;
        [Column(Name = "MaGiaoVien_GiamdocCT", DbType = "varchar(10)", IsPrimaryKey = true)]
        public string MaGiaoVien_GiamDocCT
        {
            get { return _MaGiaoVien_GiamDocCT; }
            set { _MaGiaoVien_GiamDocCT = value; }
        }
        private EntityRef<KHOA> _thuocKhoa = new EntityRef<KHOA>();// mapping mối quan hệ
        [Association(Name = "ct_k", IsForeignKey =true, 
            Storage = "_thuocKhoa", ThisKey ="MaKhoa", OtherKey ="MaKhoa" )]
        public KHOA thuocKhoa // con trỏ
        {
            get { return _thuocKhoa.Entity; }
            set { _thuocKhoa.Entity = value; }
        }

        private EntityRef<GIAOVIEN> _thuocGiaoVien = new EntityRef<GIAOVIEN>();// mapping mối quan hệ
        [Association(Name = "ct_gv", IsForeignKey = true,
            Storage = "_thuocGiaoVien", ThisKey = "MaGiaoVien_GiamDocCT", OtherKey = "MaGiaoVien")]

        public GIAOVIEN thuocGiaoVien// con trỏ
        {
            get { return _thuocGiaoVien.Entity; }
            set { _thuocGiaoVien.Entity = value; }
        }

        public CHUONGTRINH() { }// hàm tạo không tham số
        public CHUONGTRINH (string _ma, string _ten, KHOA _k, GIAOVIEN _gv)
        {
            MaChuongTrinh = _ma; TenChuongTrinh = _ten; thuocKhoa = _k;
            thuocGiaoVien = _gv;
            MaKhoa = _k.MaKhoa;
            MaGiaoVien_GiamDocCT = _gv.MaGiaoVien;
        }
        
        
       

    }
}
