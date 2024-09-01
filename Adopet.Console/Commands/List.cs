

using Adopet.Console.Models;
using Adopet.Console.Services;

namespace Adopet.Console.Commands
{
    [DocComandoAttribute(instrucao: "list",
      documentacao: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet.")]
    internal class List: IComando
    {

        private readonly HttpClientPet httpClientPet;

        public List(HttpClientPet httpClientPet)
        {
            this.httpClientPet = httpClientPet;
        }

        public Task ExecutarAsync(string[] args)
        {
            return this.ListaDadosPetsDaAPIAsync();
        }

        private async Task ListaDadosPetsDaAPIAsync()
        {           
            IEnumerable<Pet>? pets = await httpClientPet.ListPetsAsync();
            System.Console.WriteLine("----- Lista de Pets importados no sistema -----");
            foreach (var pet in pets)
            {
                System.Console.WriteLine(pet);
            }
        }

    }
}
