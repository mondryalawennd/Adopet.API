
using Adopet.Console.Models;
using Adopet.Console.Services;
using Adopet.Console.Util;

namespace Adopet.Console.Commands
{
    [DocComandoAttribute(instrucao: "import", documentacao: "adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets.")]
    internal class Import:IComando
    {
        private readonly HttpClientPet httpClientPet;

        public Import(HttpClientPet httpClientPet)
        {
            this.httpClientPet = httpClientPet;
        }

        public async Task ExecutarAsync(string[] args)
        {
            await this.ImportacaoArquivoPetAsync(caminhoDoArquivoDeImportacao: args[1]);
        }

        private async Task ImportacaoArquivoPetAsync(string caminhoDoArquivoDeImportacao)
        {
            var leitor = new LeitorDeArquivo();
            var listaDePet = leitor.RealizaLeitura(caminhoDoArquivoDeImportacao);
            foreach (var pet in listaDePet)
            {
                System.Console.WriteLine(pet);
                try
                {
                    await httpClientPet.CreatePetAsync(pet);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            System.Console.WriteLine("Importação concluída!");
        }
    }
}
