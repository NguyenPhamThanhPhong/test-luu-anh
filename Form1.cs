using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace test_luu_anh
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=STORE_IMAGE;Integrated Security=True");
        string file_name = "";
        string path_image_location = "";
        private void button_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_ID.Text != "")
                {
                    //path cua /Bin/Debug
                    string path_bin_debug = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                    // path cua resouce
                    string path_app = Path.Combine(path_bin_debug, "Resource");
                    // path cua file luu
                    file_name = textBox_ID.Text + file_name;
                    MessageBox.Show(file_name);
                    string path_Resouce_image = Path.Combine(path_app, file_name);
                    System.IO.File.Copy(path_image_location, path_Resouce_image, true);
                    con.Open();
                    SqlCommand command = new SqlCommand("Insert into store_image_tab (ID,Image_stored) values ('" + int.Parse(textBox_ID.Text) + "','" + file_name + "')", con);
                    int check = command.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("saved successfully " + check);
                }
            }
            catch (Exception ee)
            {
                throw ee;
            }

        }
        private void button_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = " png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                path_image_location = dialog.FileName.ToString(); // full path cua anh
                file_name = Path.GetFileName(dialog.FileName);

                label_image_address.Text = dialog.FileName.ToString();
                pictureBox1.ImageLocation = path_image_location;
            }
        }
        private void button_view_Click(object sender, EventArgs e)
        {
            if(con.State != ConnectionState.Open)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from store_image_tab", con);
                cmd.ExecuteNonQuery();
                SqlDataReader read_line = cmd.ExecuteReader();
                string open_file_name = "";
                if(read_line.Read())
                {
                    open_file_name = read_line.GetString(1);
                    MessageBox.Show(open_file_name);
                }
                //path cua /Bin/Debug
                string path_bin_debug = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                // path cua resouce
                string path_app = Path.Combine(path_bin_debug, "Resource");

                open_file_name = Path.Combine(path_app, open_file_name);// open_file_name : path của file khi ở trong resource

                MessageBox.Show(open_file_name);
                pictureBox1.ImageLocation = open_file_name;
            }
        }



        private void button_clear_Click(object sender, EventArgs e)
        {

        }
    }
}
