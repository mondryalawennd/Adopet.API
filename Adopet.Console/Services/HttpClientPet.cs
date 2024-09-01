using Adopet.Console.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;


namespace Adopet.Console.Services
{
    public class HttpClientPet
    {
        private HttpClient client;
       
        public HttpClientPet(HttpClient client)
        {
            this.client = client;
        }

        public Task CreatePetAsync(Pet pet)
        {
            return client.PostAsJsonAsync("pet/add", pet);
        }

        public async Task<IEnumerable<Pet>?> ListPetsAsync()
        {
            HttpResponseMessage response = await client.GetAsync("pet/list");
            return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
        }
    }
}
