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

namespace SPIDKILLER
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnKill_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection conn = new SqlConnection(Connect.ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("spidkiller", conn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("TNAME", txtTableName.Text);

                cmd.ExecuteScalar();

                conn.Close();
                MessageBox.Show("Table locks for table " + txtTableName.Text + " now released!" , "Success", MessageBoxButtons.OK);



            }
            catch
            {
                MessageBox.Show("An error has occured, please check the table name", "Error", MessageBoxButtons.OK);
            }

        }
    }
}
