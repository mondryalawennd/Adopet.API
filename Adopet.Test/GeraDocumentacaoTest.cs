
using Adopet.Console.Commands;
using Adopet.Console.Util;
using System.Reflection;

namespace Adopet.Test
{
    public class GeraDocumentacaoTest
    {
        [Fact]
        public void QuandoExistemComandosDeveRetornarDicionarioNaoVazio()
        {
            //Arrange
            Assembly assemblyComOTipoDocComando = Assembly.GetAssembly(typeof(Adopet.Console.Commands.DocComandoAttribute))!;

            //Act
            Dictionary<string, Adopet.Console.Commands.DocComandoAttribute> dicionario =
                  DocumentacaoDoSistema.ToDictionary(assemblyComOTipoDocComando);

            //Assert            
            Assert.NotNull(dicionario);
            Assert.NotEmpty(dicionario);
            Assert.Equal(4, dicionario.Count);

        }
    }
}
