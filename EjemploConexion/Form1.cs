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

            ConexionDb conexion = new ConexionDb();
            try
            {
                 conexion.Ejecutar( String.Format( "Insert Into Cuotas(NoCuota,Capital,Interes) Values({0},{1},{2})", CuotatextBox.Text , CapitaltextBox.Text,InterestextBox.Text ) );
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
  



        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ConexionDb conexion = new ConexionDb();

            try
            {
                dataGridView1.DataSource = conexion.ObtenerDatos("Select * from Cuotas");              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
        }
    }
}
