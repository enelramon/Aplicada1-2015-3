using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Calculos;
using System.Diagnostics;
using System.Threading;

namespace HolaMundo
{
    public partial class HolaForm : Form
    {
        public HolaForm()
        {
            InitializeComponent();
        }

        private void Saludarbutton_Click(object sender, EventArgs e)
        {
            //Calculadora calculadora = new Calculadora();
            //calculadora.Sumar(1, 2);
            //Saludarlabel.Text = "Hola mundo";

            //MessageBox.Show("Hola mundo", "saludo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

            //List<String> nombres = new List<string>();

            //nombres.Add("Enel");
            //nombres.Add("Elvin");

            //Debugger.Break();

            //nombres.Where(name => name.StartsWith("E"));

            MessageBox.Show(comboBox1.Text + " " + comboBox1.SelectedValue.ToString() );

        }

        private void HolaForm_Load(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Green;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                textBox2.Focus();
                e.Handled = true;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked && radioButton1.Checked  )
                MessageBox.Show("hola");
        }

        private void button1_Click(object sender, EventArgs e)
        {

           List<Categorias> lista = new List<Categorias>();

            lista.Add(new Categorias(1, "Terror"));
            lista.Add(new Categorias(2, "Comedia"));

            comboBox1.DataSource = lista;
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Descricion";


            listBox1.DataSource = lista;

            listBox1.ValueMember = "Id";
            listBox1.DisplayMember = "Descricion";

            dataGridView1.DataSource = lista;


            treeView1.Nodes.Clear();
            TreeNode nodo;

            foreach (var categoria in lista)
            {
                // treeView1.Nodes.Add(categoria.Id.ToString(), categoria.Descricion);
                nodo = new TreeNode(categoria.Descricion);
                nodo.Nodes.Add("Sanky");
                treeView1.Nodes.Add(nodo);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (nombresTextBox.Text.Length ==0)
            {
                errorProvider1.SetError(nombresTextBox, "Falta el nombre");
            }

            int edad = 0;

                int.TryParse(edadTextBox.Text,out edad);


            if ( edad <18)
            {
                errorProvider1.SetError(edadTextBox, "Debe ser mayor de edad");
            }
        }

        private void seleccionarButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = 60;
            progressBar1.Value = 0;
            for (int x=0; x<= progressBar1.Maximum; x++)
            {
                Thread.Sleep(1000);
                progressBar1.PerformStep();
            }
        }

        private void controlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controles controles = new Controles();
            controles.Show();
        }
    }
}
