using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DispositivoDarwin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Calculos calculo = new Calculos();

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textBox1.TextLength) > 0)
                {
                    string qtdLetras = textBox1.Text;
                    label2.Text = calculo.gerarPalavra(qtdLetras.Length);
                } else
                {
                    MessageBox.Show("Objetivo inválido!");
                }
                
            }
            catch
            {
                MessageBox.Show("Erro!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime tempoini = DateTime.Now;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                string objetivo = textBox1.Text;
                int filhos = (int)numericUpDown1.Value;
                int mutacoes = (int)numericUpDown2.Value;
                string pai = label2.Text;
                int distancia = calculo.calcDistString(objetivo, pai);
                int distAux;
                int coluna = -1;
                dataGridView1.RowCount = filhos;
                while (distancia != 0)
                {
                    dataGridView1.ColumnCount++;
                    coluna++;
                    dataGridView1.Columns[coluna].HeaderCell.Value = pai;
                    for (int i = 0; i < filhos; i++)
                    {
                        dataGridView1.Rows[i].Cells[coluna].Value = calculo.gerarFilhos(pai, (int)mutacoes);
                        distAux = calculo.calcDistString(objetivo, (dataGridView1.Rows[i].Cells[coluna].Value).ToString());
                        if (distancia > distAux)
                        {
                            distancia = distAux;
                            pai = dataGridView1.Rows[i].Cells[coluna].Value.ToString();

                        }
                    }
                }
                label8.Text = "Número de gerações: " + (dataGridView1.ColumnCount--).ToString();
                DateTime tempofim = DateTime.Now;
                label7.Text = "Tempo gasto: " + (tempofim - tempoini).TotalMilliseconds.ToString() + "ms";
            }
            catch
            {
                MessageBox.Show("Erro!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = "";
            label7.Text = "";
            label8.Text = "";
        }

        private void e(object sender, EventArgs e)
        {

        }

        private void sobreToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form frm = new Sobre();
            frm.ShowDialog();
        }
    }
}
