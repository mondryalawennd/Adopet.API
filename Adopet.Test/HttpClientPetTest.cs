
using Adopet.Console.Services;
using Moq;
using Moq.Protected;
using System.Net;

namespace Adopet.Test
{
    public class HttpClientPetTest
    {
        [Fact]
        public async Task ListaPetsDeveRetornarUmaListaNaoVazia()
        {
            var handlerMock = new Mock<HttpMessageHandler>();

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"
         [
            {
                ""id"": ""ed48920c-5adb-4684-9b8f-ba8a94775a11"",
                ""nome"": ""Sábio"",
                ""tipo"": 0,
                ""proprietario"":null
            },
            {
                ""id"": ""456b24f4-19e2-4423-845d-4a80e8854a41"",
                ""nome"": ""Lima Limão"",
                ""tipo"": 0,
                ""proprietario"": null
            }
        ]
    "),
            };
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);


            //moq-objeto fake
            var httpClient = new Mock<HttpClient>(MockBehavior.Default, handlerMock.Object);
            httpClient.Object.BaseAddress = new Uri("http://localhost:5057");

            //Arrange
            var clientePet = new HttpClientPet(httpClient.Object);
            //Act
            var lista = await clientePet.ListPetsAsync();


            //Assert
            Assert.NotNull(lista);
            Assert.NotEmpty(lista);
        }

        [Fact]
        public async Task QuandoAPIForaDeveRetornarUmaExcecao()
        {
            ////Arrange
            //var clientePet = new HttpClientPet(uri:"http://localhost:1111");

            ////Act+Assert
            //await Assert.ThrowsAnyAsync<Exception>(()=> clientePet.ListPetsAsync());

        }

    }
}