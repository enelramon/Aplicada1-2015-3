using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EjemploConexion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=Aplicada1Db;Integrated Security=True");
            SqlCommand Comand = new SqlCommand();

            try
            {
                con.Open();
                Comand.Connection = con;
                Comand.CommandText = String.Format( "Insert Into Cuotas(NoCuota,Capital,Interes) Values({0},{1},{2})", CuotatextBox.Text , CapitaltextBox.Text,InterestextBox.Text  );
                Comand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }



        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=Aplicada1Db;Integrated Security=True");
            SqlCommand Comand = new SqlCommand();

            SqlDataAdapter adapter;
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                Comand.Connection = con;
                Comand.CommandText =  "Select * from Cuotas";

                adapter = new SqlDataAdapter(Comand);
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            dataGridView1.DataSource = dt;
        }
    }
}
