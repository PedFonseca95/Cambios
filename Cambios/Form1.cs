using Cambios.Modelos;
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
        public Form1()
        {
            InitializeComponent();
            LoadRates();
        }

        private async void LoadRates()
        {
            //bool load; // Para saber se foi carregado ou não

            progressBar1.Value = 0;

            var client = new HttpClient(); // Criar conexão via http

            client.BaseAddress = new Uri("http://cambios.somee.com"); // Definir endereço base/principal da API

            var response = await client.GetAsync("/api/rates"); // Definir o controlador da API (resto do link)
            // async e await serve para que a aplicação continue a correr enquanto são carregadas as taxas - Tarefa asincrona

            var result = await response.Content.ReadAsStringAsync(); // Carregar os resultados obtidos em formato string -> JSON

            if (!response.IsSuccessStatusCode) // Caso haja algum problema/não seja obtida uma resposta por parte da API
            {
                MessageBox.Show(response.ReasonPhrase); // Mostra uma mensagem com o motivo pela qual a resposta não foi feita com sucesso
                return; // Termina o método
            }

            // Caso tenha obtido uma resposta
            var rates = JsonConvert.DeserializeObject<List<Rate>>(result); // Converte o resultado JSON obtido (result) para dentro de uma lista com dados do tipo Rate

            cb_origem.DataSource = rates; // Apresentar os valores da lista criada rates na comboBox origem
            cb_origem.DisplayMember = "Name"; // Mostrar a propriedade Name nos items da comboBox 

            cb_destino.BindingContext = new BindingContext(); // Permite que as comboBox deixem de estar ligadas/binding, permitindo escolher items diferentes

            cb_destino.DataSource = rates;
            cb_destino.DisplayMember = "Name";

            progressBar1.Value = 100;
        }
    }
}
