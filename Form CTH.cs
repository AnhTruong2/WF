using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public static Form1 me;
        public EntDuLieu entdl;
        public Form1()
        {
            me = this;
            InitializeComponent();
            entdl = new EntDuLieu();

            // đổ data vào combobox khoa
            var kqKhoa = from khoa in me.entdl.KHOAs
                         orderby khoa.TenKhoa
                         select khoa;
            comboBox1.DataSource = kqKhoa.ToList();
            comboBox1.DisplayMember = "TenKhoa";
            comboBox1.ValueMember = "MaKhoa";

            var kqCTMH = from m in me.entdl.CHUONGTRINHs
                         orderby m.MaChuongTrinh
                         select m;
            comboBox2.DataSource = kqCTMH.ToList();
            comboBox2.DisplayMember = "TenChuongTrinh";
            comboBox2.ValueMember = "MaChuongTrinh";


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox1.SelectedValue.ToString();// lấy giá trị mã khoa từ tên khoa                 
            var kq = from ct in me.entdl.CHUONGTRINHs
                     join k in me.entdl.KHOAs on ct.MaKhoa equals k.MaKhoa
                     join g in me.entdl.GIAOVIENs on ct.MaGiaoVien_GiamDocCT equals g.MaGiaoVien
                     where ct.MaKhoa == selectedItem
                     select new
                     {
                         ct.MaChuongTrinh,
                         ct.TenChuongTrinh,
                         ct.MaBacHoc,
                         k.TenKhoa,
                         g.HoTen,
                     };


            dataGridView1.DataSource = kq.ToList();

            dataGridView1.Columns[0].HeaderText = "Mã chương trình";
            dataGridView1.Columns[1].HeaderText = "Chương trình";
            dataGridView1.Columns[2].HeaderText = "Bậc học";
            dataGridView1.Columns[3].HeaderText = "Khoa";
            dataGridView1.Columns[4].HeaderText = "Giám đốc chương trình";
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Xóa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng để xóa !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa thông tin này ?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    // Lấy dòng được chọn trên DataGridView
                    DataGridViewRow Selectedrow = dataGridView1.CurrentRow;


                    // gán mã chương trình cần xóa vào xct
                    CHUONGTRINH xct = new CHUONGTRINH();
                    xct.MaChuongTrinh = Selectedrow.Cells["MaChuongTrinh"].Value.ToString();

                    // Xóa dòng trong SQL
                    var row = me.entdl.CHUONGTRINHs.FirstOrDefault(x => x.MaChuongTrinh == xct.MaChuongTrinh);
                    if (row != null)
                    {
                        me.entdl.CHUONGTRINHs.DeleteOnSubmit(row);
                        me.entdl.dc.SubmitChanges();
                        MessageBox.Show("Bạn đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // trường hợp xóa chương trình thì sẽ xóa tất cả chương trình môn học
                    }
                }
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            Thêm_mới formTM = new Thêm_mới();

            formTM.Show();



        }

        private void Sửa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng để chỉnh sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dataGridView1.SelectedRows.Count > 0)
            {


                // Lấy dòng được chọn trên DataGridView
                DataGridViewRow selectedRow = dataGridView1.CurrentRow;
                int rowIndex = selectedRow.Index;

                // Tạo biến truyền dữ liệu sang form Sửa
                CHUONGTRINH sct = new CHUONGTRINH();
                sct.MaChuongTrinh = selectedRow.Cells["MaChuongTrinh"].Value.ToString();
                sct.TenChuongTrinh = selectedRow.Cells["TenChuongTrinh"].Value.ToString();
                sct.MaBacHoc = selectedRow.Cells["MaBacHoc"].Value.ToString();
                sct.MaGiaoVien_GiamDocCT = selectedRow.Cells["HoTen"].Value.ToString();
                sct.MaKhoa = comboBox1.SelectedValue.ToString().Trim();

                // Hiển thị Form 2 để sửa thông tin
                Sửa formsua = new Sửa(sct);
                formsua.Show();

                //if (formsua.IsDataChanged)
                //{
                //RefreshDataGridView();
                //}

            }
        }






        private void Form1_Load(object sender, EventArgs e)
        {

        }

      

        private void button2_Click(object sender, EventArgs e)
        {
           

            


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox2.SelectedValue.ToString();// lấy giá trị mã khoa từ tên khoa                 
            var ctmn = from ct in me.entdl.CHUONGTRINHMONHOCs
                     join t in me.entdl.CHUONGTRINHs on ct.MaChuongTrinh equals t.MaChuongTrinh
                     join d in me.entdl.MONHOCs on ct.MaMonHoc equals d.MaMonHoc
                     where ct.MaChuongTrinh == selectedItem
                     select new
                     {
                         ct.MaChuongTrinh,
                         t.TenChuongTrinh,
                         d.TenMonHoc,
                         ct.HocKy,
                     
                     };


            dataGridView2.DataSource = ctmn.ToList();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //private void RefreshDataGridView()
        //{
        // Lấy dữ liệu mới từ CSDL và cập nhật lại DataGridView
        //var kqsua = from w in me.entdl.CHUONGTRINHs
        //select w;
        //dataGridView1.DataSource = kqsua.ToList();
        //}
    }
}

