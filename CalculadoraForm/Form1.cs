using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
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
            string mat = txbTela.Text;

            // Verificar se o campo está vazio
            if (mat == "")
            {
                MessageBox.Show("Erro, o campo está vazio", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Pega o último caractere da expressão digitada
            char ultimoOperador = mat[mat.Length - 1];

            // Escolha caso para identificar o operador
            switch (ultimoOperador)
            {
                case '-':
                case '+':
                case '/':
                case '*':
                    // Caso ele nenhum operador
                    MessageBox.Show("Erro,verique o operador.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Uma biblioteca importada o .Net para fazer expressoes matematicas com strings e armazenar na variavel resultado 
                var resultado = new System.Data.DataTable().Compute(mat, null).ToString();
            
                // Mostra o resultado
                txbTela.Text = resultado.ToString();
                // Erro ao calcular por 0 (zero)
                if (resultado == "∞")
                {
                    txbTela.Text = "";
                    MessageBox.Show("Erro ao calcular expressão, por dividir o número por zero ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
                // "Ele levanta a bandeirinha novamente" para iniciar novamente o programa e digitar o proximo numero
                operadorClicado = true;
            }
            catch
            {
                // 
                MessageBox.Show("Erro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbTela.Text = "";
            }
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

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            // Limpar a tela
            txbTela.Text = "";
            // Voltar o operador clicado para true:
            operadorClicado = true;
        }
    }
}
