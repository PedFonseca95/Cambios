using Cambios.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cambios.Servicos
{
    public class ApiService
    {
        // Em vez de ter o código de ligação à API diretamente no form, utilizamos esta classe para o fazer, utilizando um serviço

        public async Task<Response> GetRates(string urlBase, string controller) // Método com uma tarefa atribuida (Task) de obter uma resposta (response)
        {
            // Sempre que são feitas ligações a bases de dados, utilizar SEMPRE um try/catch

            try
            {
                var client = new HttpClient(); // Criar conexão via http

                client.BaseAddress = new Uri(urlBase); // Definir endereço base/principal da API

                var response = await client.GetAsync(controller); // Definir o controlador da API (resto do link)
                // async e await serve para que a aplicação continue a correr enquanto são carregadas as taxas - Tarefa asincrona

                var result = await response.Content.ReadAsStringAsync(); // Carregar os resultados obtidos em formato string -> JSON

                if (!response.IsSuccessStatusCode) // Caso haja algum problema/não seja obtida uma resposta por parte da API
                {
                    return new Response // Retorna uma nova resposta (falhou)
                    {
                        IsSuccess = false,
                        Message = result
                    };
                }

                // Caso tenha obtido uma resposta
                var rates = JsonConvert.DeserializeObject<List<Rate>>(result); // Converte o resultado JSON obtido (result) para dentro de uma lista com dados do tipo Rate

                return new Response // Retorna uma nova resposta (sucesso)
                {
                    IsSuccess = true,
                    Result = rates
                };

            }
            catch (Exception ex) // No caso de haver outro problema qualquer
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
