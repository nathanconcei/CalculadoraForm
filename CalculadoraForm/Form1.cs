using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraForm
{
    public partial class Form1 : Form
    {
        // Variaveis globais:
        bool operadorClicado = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            // Implementar depois...
        }

        private void numero_Click(object sender, EventArgs e)
        {
            //  Obter o botão que está chamando esse evento:
            Button botaoClicado = (Button)sender;

            // Adicionar o text do botão clicado no text.Box
            txbTela.Text += botaoClicado.Text;

            // "Abaixar a bandeirinha"
            operadorClicado = false;
        }

        private void operador_Click(object sender, EventArgs e) 
        {
            if (operadorClicado ==  false) 
            {
                //  Obter o botão que está chamando esse evento:
                Button botaoClicado = (Button)sender;

                // Adicionar o text do botão clicado no text.Box
                txbTela.Text += botaoClicado.Text;

                // Mudar o operadorClicado para true (levantar bandeirinha)):
                operadorClicado = true;
            } 
        }
    }
}
