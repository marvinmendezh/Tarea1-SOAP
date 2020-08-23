using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_WS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.ServiciosSoapClient ws = new ServiceReference1.ServiciosSoapClient();

            DataSet ds = ws.GetConsultaMontoOrdenes(Int32.Parse(textBox1.Text));

            textBox2.Text = ds.Tables[0].Rows[0]["totalFactura"].ToString();
            textBox3.Text = ds.Tables[0].Rows[0]["TotalDue"].ToString();
            textBox4.Text = ds.Tables[0].Rows[0]["TaxAmt"].ToString();
            textBox5.Text = ds.Tables[0].Rows[0]["Freight"].ToString();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ServiceReference1.ServiciosSoapClient ws = new ServiceReference1.ServiciosSoapClient();

            DataSet ds = ws.GetNumeroOrdenes();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                comboBox1.Items.Add(ds.Tables[0].Rows[i]["SalesOrderID"].ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ServiceReference1.ServiciosSoapClient ws = new ServiceReference1.ServiciosSoapClient();

            DataSet ds = ws.GetConsultaMontoOrdenes(Int32.Parse(comboBox1.Text));

            textBox2.Text = ds.Tables[0].Rows[0]["totalFactura"].ToString();
            textBox3.Text = ds.Tables[0].Rows[0]["TotalDue"].ToString();
            textBox4.Text = ds.Tables[0].Rows[0]["TaxAmt"].ToString();
            textBox5.Text = ds.Tables[0].Rows[0]["Freight"].ToString();
        }
    }
}
