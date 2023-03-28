using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Sửa : Form
    {
        
        public static Form1 me;       
        public EntDuLieu entdl;
        private CHUONGTRINH sct;
        
        
        public Sửa( CHUONGTRINH sct)


        {
            InitializeComponent();
            this.sct = sct;          
            LoadData();

            // đổ Tên khoa vào combobox1
            var sK = from q in Form1.me.entdl.KHOAs
                         orderby q.TenKhoa
                         select q;
            comboBox1.DataSource = sK.ToList();
            comboBox1.DisplayMember = "TenKhoa";
            comboBox1.ValueMember = "MaKhoa";
            comboBox1.SelectedValue = sct.MaKhoa;// show selectedItem ở form CTH

            var sGD = from a in Form1.me.entdl.GIAOVIENs
                     orderby a.HoTen
                     select a;
            comboBox2.DataSource = sGD.ToList();
            comboBox2.DisplayMember = "HoTen";
            comboBox2.ValueMember = "MaGiaoVien";
            comboBox2.Text = sct.MaGiaoVien_GiamDocCT;


        }
        public void LoadData()
        {
            // Hiển thị thông tin của đối tượng sct lên các controls trên Form 2
            textBox1.Text = sct.MaChuongTrinh;
            textBox2.Text = sct.TenChuongTrinh;
            textBox3.Text = sct.MaBacHoc;
            comboBox1.SelectedValue = sct.MaKhoa;
            comboBox2.Text = sct.MaGiaoVien_GiamDocCT;           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)

        {
            // xử lý các trường hợp ngoại lệ
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox3.Text.Length > 2)
            {
                MessageBox.Show("Mã bậc học không được nhiều hơn 2 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }          
            else // case thêm mới thành công
            {               
                sct.TenChuongTrinh = textBox2.Text;
                sct.MaBacHoc = textBox3.Text;
                sct.MaKhoa = comboBox1.SelectedValue.ToString().Trim();
                sct.MaGiaoVien_GiamDocCT = comboBox2.Text;

                // Lấy đối tượng CHUONGTRINH tương ứng với thông tin đã chỉnh sửa trên Form 2 từ cơ sở dữ liệu
                var chuongTrinh = Form1.me.entdl.CHUONGTRINHs.Single(c => c.MaChuongTrinh == sct.MaChuongTrinh);

                // Cập nhật thông tin mới cho đối tượng CHUONGTRINH đã lấy được
                chuongTrinh.TenChuongTrinh = textBox2.Text; 
                chuongTrinh.MaBacHoc = textBox3.Text;
                //chuongTrinh.MaKhoa = comboBox2.Text;
                //chuongTrinh.MaGiaoVien_GiamDocCT = comboBox2.Text;

                Form1.me.entdl.dc.SubmitChanges();

                // Cập nhật lại Data Gridview trên Form 1

                MessageBox.Show("Bạn đã sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
