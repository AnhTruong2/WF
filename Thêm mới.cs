using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Thêm_mới : Form
    {
        public static Form1 me;
        public EntDuLieu entdl;
        public Thêm_mới()
        {
            InitializeComponent();
            entdl = new EntDuLieu();

            // đổ data Khoa và combobox
            var kqKhoa = from khoa in entdl.KHOAs
                         orderby khoa.TenKhoa
                         select khoa;
            comboBox2.DataSource = kqKhoa.ToList();
            comboBox2.DisplayMember = "TenKhoa";
            comboBox2.ValueMember = "MaKhoa";

            // đổ data giáo viên vào combobox
            var gđ = from u in entdl.GIAOVIENs
                     orderby u.HoTen
                     select u;
            comboBox1.DataSource = gđ.ToList();
            comboBox1.DisplayMember = "HoTen";
            comboBox1.ValueMember = "MaGiaoVien";         
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        public void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // TRƯỜNG HỢP THÊM MỚI CHƯƠNG TRÌNH
        private void button1_Click(object sender, EventArgs e)
        {
            string mct = textBox1.Text.Trim();
            string tct = textBox3.Text.Trim();
            string mbh = textBox2.Text.Trim();
            string mk = comboBox2.SelectedValue.ToString().Trim();
            string mgv = comboBox1.SelectedValue.ToString().Trim();
            CHUONGTRINH ctmoi = new CHUONGTRINH();
            ctmoi.MaChuongTrinh = mct;
            ctmoi.TenChuongTrinh = tct;
            ctmoi.MaBacHoc = mbh;
            ctmoi.MaKhoa = mk;
            ctmoi.MaGiaoVien_GiamDocCT = mgv;
            
            // Các trường hợp ngoại lệ khi thêm mới
            if (string.IsNullOrEmpty(mct) || string.IsNullOrEmpty(tct) || string.IsNullOrEmpty(mbh))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (mbh.Length > 2)
            {
                MessageBox.Show("Mã bậc học không được nhiều hơn 2 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Form1.me.entdl.CHUONGTRINHs.Any(x => x.MaChuongTrinh == mct))
            {
                MessageBox.Show("Mã chương trình đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
            else // case thêm mới thành công
            {
                Form1.me.entdl.CHUONGTRINHs.InsertOnSubmit(ctmoi);
                Form1.me.entdl.dc.SubmitChanges();
                MessageBox.Show("Bạn đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }    
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
           
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
