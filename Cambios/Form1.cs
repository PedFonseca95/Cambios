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

        #endregion

        public List<Rate> Rates { get; set; } = new List<Rate>();

        public Form1()
        {
            InitializeComponent();
            networkService = new NetworkService();
            apiService = new ApiService();
            LoadRates();
        }

        private async void LoadRates()
        {
            //bool load; // Para saber se foi carregado ou não

            lbl_resultado.Text = "A atualizar taxas...";

            var connection = networkService.CheckConnection(); // Vai testar a conexão à internet

            if (!connection.IsSuccess) // Se a conexão não tiver sido feita com sucesso
            {
                MessageBox.Show(connection.Message);
                return; // Sai do método caso não haja conexão feita
            }
            else // Se tiver conexão
            {
                await LoadApiRates();
            }


            cb_origem.DataSource = Rates; // Apresentar os valores da lista criada rates na comboBox origem
            cb_origem.DisplayMember = "Name"; // Mostrar a propriedade Name nos items da comboBox 

            cb_destino.BindingContext = new BindingContext(); // Permite que as comboBox deixem de estar ligadas/binding, permitindo escolher items diferentes

            cb_destino.DataSource = Rates;
            cb_destino.DisplayMember = "Name";

            progressBar1.Value = 100;
            lbl_resultado.Text = "Taxas carregadas com sucesso!";
        }

        private async Task LoadApiRates()
        {
            progressBar1.Value = 0;

            // Definir endereço base/principal e controlador da API
            var response = await apiService.GetRates("http://cambios.somee.com", "/api/rates");
            // async e await serve para que a aplicação continue a correr enquanto são carregadas as taxas - Tarefa asincrona  

            Rates = (List<Rate>)response.Result;
        }
    }
}
