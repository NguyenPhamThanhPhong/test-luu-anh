using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_luu_anh
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=STORE_IMAGE;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from store_image_tab", con);
            cmd.ExecuteNonQuery();
            List<string> strarr = new List<string>(); // define a list outside of the loop
            List<Int32> intarr = new List<int>();
            //string str = "";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                
                    intarr.Add(reader.GetInt32(0));
                    strarr.Add(reader.GetString(1));
                }
            }
            MessageBox.Show(intarr[1].ToString());
            MessageBox.Show(strarr[1]);
        }
    }
}
