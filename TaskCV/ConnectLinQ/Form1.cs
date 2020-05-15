using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.IO;
using System.Drawing.Imaging;

namespace ConnectLinQ
{
    public partial class Form1 : Form
    {

        /*  #region Variables
          int ImageId = 0;
          String strFilePath = "";
          Image DefaultImage;
          Byte[] ImageByteArray;
          Database.user user = new Database.user();*/

        List<Database.ConnectDatabaseDataContext> Users;
        private object adapter;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // db = new DataClasses1DataContext();
            /* var var = (from DemoLinQ in db.DemoLinQs
                        where DemoLinQ.id == 1
                         select  DemoLinQ).FirstOrDefault();*/
            using (Database.ConnectDatabaseDataContext db = new Database.ConnectDatabaseDataContext())
            {
                dataGridView1.DataSource = db.users.Select(p => p).ToList();
            }
            /*MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
            byte[] photo_array = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(photo_array, 0, photo_array.Length);*/
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Database.ConnectDatabaseDataContext db = new Database.ConnectDatabaseDataContext();
            /*DemoLinQ demoLinQ = new DemoLinQ();
            demoLinQ.id =Int32.Parse( txtId.Text);
            demoLinQ.name = txtName.Text;
            demoLinQ.sdt = txtPhone.Text;
            db.DemoLinQs.InsertOnSubmit(demoLinQ);
            db.SubmitChanges();
            dataGridView1.DataSource = db.DemoLinQs.Select(p => p).ToList();*/
            Database.user User = new Database.user();
            User.idUser = Int32.Parse(txtIdUser.Text);
            User.nameUser = txtUserName.Text;
            User.emailUser = txtEmailUer.Text;

            db.users.InsertOnSubmit(User);
            db.SubmitChanges();
            dataGridView1.DataSource = db.users.Select(p => p).ToList();


        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            String id = txtIdUser.Text;
            Database.ConnectDatabaseDataContext db = new Database.ConnectDatabaseDataContext();
            Database.user updateUser = db.users.Where(p => p.idUser == Convert.ToInt32(id)).SingleOrDefault();
            updateUser.nameUser = txtUserName.Text;
            updateUser.emailUser = txtEmailUer.Text;
            db.SubmitChanges();
            dataGridView1.DataSource = db.users.Select(p => p).ToList();
        }

        private void btnSelectIImage_Click(object sender, EventArgs e)
        {

            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pictureBox1.Image = new Bitmap(open.FileName);
                // image file path  
                
            }
        }
        
        private byte[] ImageToStream(string fileName)
        {
            MemoryStream stream = new MemoryStream();
        tryagain:
            try
            {
                Bitmap image = new Bitmap(fileName);
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                goto tryagain;
            }

            return stream.ToArray();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;


            txtIdUser.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            txtUserName.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            txtEmailUer.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            String id = txtIdUser.Text;
            Database.ConnectDatabaseDataContext db = new Database.ConnectDatabaseDataContext();
            Database.user deleteUser = db.users.Where(p => p.idUser == Convert.ToInt32(id)).SingleOrDefault();
            db.users.DeleteOnSubmit(deleteUser);
            db.SubmitChanges();
            dataGridView1.DataSource = db.users.Select(p => p).ToList();
            txtIdUser.Text = "";
            txtUserName.Text = "";
            txtEmailUer.Text = "";
        }
    }
}
