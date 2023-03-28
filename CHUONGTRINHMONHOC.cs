using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Data.Linq;

namespace WindowsFormsApp2
{
    [Table(Name = "CHUONGTRINHMONHOC")]
    public class CHUONGTRINHMONHOC
    {
        private string _MaChuongTrinh;
        [Column(Name = "MaChuongTrinh", DbType = "nvarchar(5)", IsPrimaryKey = true)]
        public string MaChuongTrinh
        {
            get { return _MaChuongTrinh; }
            set { _MaChuongTrinh = value; }
        }

        private EntityRef<CHUONGTRINH> _thuocChuongTrinh = new EntityRef<CHUONGTRINH>();// mapping mối quan hệ
        [Association(Name = "ctmh_ct", IsForeignKey = true,
            Storage = "_thuocChuongTrinh", ThisKey = "MaChuongTrinh", OtherKey = "MaChuongTrinh")]
        public CHUONGTRINH thuocChuongTrinh // con trỏ
        {
            get { return _thuocChuongTrinh.Entity; }
            set { _thuocChuongTrinh.Entity = value; }
        }

        private string _MaMonHoc;
        [Column(Name = "MaMonHoc", DbType = "nvarchar(10)", IsPrimaryKey = true)]
        public string MaMonHoc
        {
            get { return _MaMonHoc; }
            set { _MaMonHoc = value; }
        }

        private EntityRef<MONHOC> _thuocMonHoc = new EntityRef<MONHOC>();// mapping mối quan hệ
        [Association(Name = "ctmh_mh", IsForeignKey = true,
            Storage = "_thuocMonHoc", ThisKey = "MaMonHoc", OtherKey = "MaMonHoc")]
        public MONHOC thuocMonHoc // con trỏ
        {
            get { return _thuocMonHoc.Entity; }
            set { _thuocMonHoc.Entity = value; }
        }

        private string _HocKy;
        [Column(Name = "HocKy", DbType = "int")]
        public string HocKy
        {
            get { return _HocKy; }
            set { _HocKy = value; }
        }

        public CHUONGTRINHMONHOC() { }// hàm tạo không tham số
        public CHUONGTRINHMONHOC(string _hk, CHUONGTRINH _maCT, MONHOC _maMH)
        {
            HocKy = _hk; thuocChuongTrinh = _maCT;
            thuocMonHoc = _maMH;
            MaChuongTrinh = _maCT.MaChuongTrinh;
            MaMonHoc = _maMH.MaMonHoc;
        }
    }
}
