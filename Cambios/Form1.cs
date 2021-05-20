using Cambios.Modelos;
using Cambios.Servicos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cambios
{
    public partial class Form1 : Form
    {
        #region Atributos

        private NetworkService networkService;

        private ApiService apiService;

        private List<Rate> rates;

        private DialogService dialogService;

        #endregion
        
        public Form1()
        {
            InitializeComponent();
            networkService = new NetworkService();
            apiService = new ApiService();
            dialogService = new DialogService();
            LoadRates();
        }

        private async void LoadRates()
        {
            bool load; // Para saber se foi carregado ou não

            lbl_resultado.Text = "A atualizar taxas...";

            var connection = networkService.CheckConnection(); // Vai testar a conexão à internet

            if (!connection.IsSuccess) // Se a conexão não tiver sido feita com sucesso
            {
                LoadLocalRates(); // Conecta-se à base de dados local
                load = false;
            }
            else // Se tiver conexão
            {
                await LoadApiRates(); // Conecta-se à Api que vai estabelecer ligação à base de dados online
                load = true;
            }

            if (rates.Count == 0) // Se a lista de rates não tiver sido carregada ou estiver vazia
            {
                lbl_resultado.Text = "Não há ligação à internet.\nNão foram previamente carregadas as taxas.\nTente novamente mais tarde.";
                return; // Termina a execução do método LoadRates()
            }

            cb_origem.DataSource = rates; // Apresentar os valores da lista criada rates na comboBox origem
            cb_origem.DisplayMember = "Name"; // Mostrar a propriedade Name nos items da comboBox 

            cb_destino.BindingContext = new BindingContext(); // Permite que as comboBox deixem de estar ligadas/binding, permitindo escolher items diferentes

            cb_destino.DataSource = rates;
            cb_destino.DisplayMember = "Name";                       

            lbl_resultado.Text = "Taxas carregadas com sucesso!";

            btn_converter.Enabled = true; // Ativa o botão para que seja possivel converter o valor inserido

            if (load) // Se a Api carregar
            {
                lbl_status.Text = string.Format("Taxas carregadas da internet em {0:F}",DateTime.Now);
            }
            else // Se for carregado através da base de dados local
            {
                lbl_status.Text = string.Format("Taxas carregadas da base de dados local.");
            }

            progressBar1.Value = 100;

            btn_converter.Enabled = true;
            btn_troca.Enabled = true;
        }

        private void LoadLocalRates()
        {
            MessageBox.Show("Não está implementado");
        }

        private async Task LoadApiRates()
        {
            progressBar1.Value = 0;

            // Definir endereço base/principal e controlador da API
            var response = await apiService.GetRates("http://cambios.somee.com", "/api/rates");
            // async e await serve para que a aplicação continue a correr enquanto são carregadas as taxas - Tarefa asincrona  

            rates = (List<Rate>)response.Result;
        }

        private void btn_converter_Click(object sender, EventArgs e)
        {
            Converter();
        }

        private void Converter()
        {
            if (string.IsNullOrEmpty(tb_valor.Text)) // Se não existir um valor inserido
            {
                dialogService.ShowMessage("Erro","Insira um valor a converter");
                return;
            }

            decimal valor;

            if (!decimal.TryParse(tb_valor.Text, out valor)) // Se não conseguir converter o valor inserido
            {
                dialogService.ShowMessage("Erro de conversão", "Insira um valor numérico!");
                return;
            }

            if (cb_origem.SelectedItem == null) // Se não houver nada selecionado na primeira comboBox
            {
                dialogService.ShowMessage("Erro", "Escolha uma moeda a converter");
                return;
            }

            if (cb_destino.SelectedItem == null) // Se não houver nada selecionado na segunda comboBox
            {
                dialogService.ShowMessage("Erro", "Escolha uma moeda de destino para converter");
                return;
            }

            var taxaOrigem = (Rate)cb_origem.SelectedItem;

            var taxaDestino = (Rate)cb_destino.SelectedItem;

            var valorConvertido = valor / (decimal)taxaOrigem.TaxRate * (decimal)taxaDestino.TaxRate;

            lbl_resultado.Text = string.Format("{0} {1:C2} = {2} {3:C2}", taxaOrigem.Code, valor, taxaDestino.Code, valorConvertido);
        }

        private void btn_troca_Click(object sender, EventArgs e)
        {
            Trocar();
        }

        private void Trocar()
        {
            var aux = cb_origem.SelectedItem;
            cb_origem.SelectedItem = cb_destino.SelectedItem;
            cb_destino.SelectedItem = aux;
            Converter();
        }
    }
}
