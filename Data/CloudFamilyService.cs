using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace Assignment.Data
{
    public class CloudFamilyService : IFamilyService
    {
        public async Task<IList<Family>> GetFamilies()
        {
            HttpClient client = new HttpClient();
            string message = await client.GetStringAsync("https://localhost:5001/Families");
            List<Family> result = JsonSerializer.Deserialize<List<Family>>(message);
            return result;
        }

        public async Task<IList<Adult>> GetAdults()
        {
            HttpClient client = new HttpClient();
            string message = await client.GetStringAsync("https://localhost:5001/Adults");
            List<Adult> result = JsonSerializer.Deserialize<List<Adult>>(message);
            return result;
        }

        public async Task<IList<Child>> GetChildren()
        {
            HttpClient client = new HttpClient();
            string message = await client.GetStringAsync("https://localhost:5001/Children");
            List<Child> result = JsonSerializer.Deserialize<List<Child>>(message);
            return result;
        }

        public async Task<Adult> getAdultById(int Id)
        {
            HttpClient client = new HttpClient();
            string message = await client.GetStringAsync("https://localhost:5001/Adults/search?id="+Id);
            Adult result = JsonSerializer.Deserialize<Adult>(message);
            return result;
        }

        public async Task<Child> getChildById(int Id)
        {
            HttpClient client = new HttpClient();
            string message = await client.GetStringAsync("https://localhost:5001/Children/search?id="+Id);
            Child result = JsonSerializer.Deserialize<Child>(message);
            return result;
        }

        public async Task AddFamily(Family family)
        {
            HttpClient client = new HttpClient();
            string familySerialized = JsonSerializer.Serialize(family);
            HttpContent httpContent = new StringContent(familySerialized,Encoding.UTF8,"application/json");
            await client.PutAsync("https://localhost:5001/Families", httpContent);
        }

        public async Task<string> AddAdult(Adult adult)
        {
            HttpClient client = new HttpClient();
            string adultSerialized = JsonSerializer.Serialize(adult);
            HttpContent httpContent = new StringContent(adultSerialized,Encoding.UTF8,"application/json");
            HttpResponseMessage responseMessage = await client.PutAsync("https://localhost:5001/Adults", httpContent);
            return await responseMessage.Content.ReadAsStringAsync();
        }

        public async Task<string> AddChildren(Child child)
        {
            HttpClient client = new HttpClient();
            string childSerialized = JsonSerializer.Serialize(child);
            HttpContent httpContent = new StringContent(childSerialized,Encoding.UTF8,"application/json");
            HttpResponseMessage responseMessage = await client.PutAsync("https://localhost:5001/Children", httpContent);
            return await responseMessage.Content.ReadAsStringAsync();
        }

        public async Task RemoveFamily(int familyId)
        {
            HttpClient client = new HttpClient();
            await client.DeleteAsync("https://localhost:5001/Families?familyId="+familyId);
        }

        public async Task RemoveAdult(int adultId)
        {
            HttpClient client = new HttpClient();
            await client.DeleteAsync("https://localhost:5001/Adults?id="+adultId);
        }

        public async Task RemoveChild(int childId)
        {
            HttpClient client = new HttpClient();
            await client.DeleteAsync("https://localhost:5001/Children?id="+childId);
        }

        public async Task UpdateFamily(Family family)
        {
            HttpClient client = new HttpClient();
            string familySerialized = JsonSerializer.Serialize(family);
            HttpContent httpContent = new StringContent(familySerialized,Encoding.UTF8,"application/json");
            await client.PatchAsync("https://localhost:5001/Families", httpContent);
        }

        public async Task UpdateAdult(Adult adult)
        {
            HttpClient client = new HttpClient();
            string adultSerialized = JsonSerializer.Serialize(adult);
            HttpContent httpContent = new StringContent(adultSerialized,Encoding.UTF8,"application/json");
            await client.PatchAsync("https://localhost:5001/Adults", httpContent);
        }

        public async Task UpdateChild(Child child)
        {
            HttpClient client = new HttpClient();
            string childSerialized = JsonSerializer.Serialize(child);
            HttpContent httpContent = new StringContent(childSerialized,Encoding.UTF8,"application/json");
            await client.PatchAsync("https://localhost:5001/Children", httpContent);
            
        }

        public async Task<string> getFamilyError()
        {
            HttpClient client = new HttpClient();
            string message = await client.GetStringAsync("https://localhost:5001/FamilyError");
            string result = message;
            Console.WriteLine(message);
            return result;
        }

        public async Task<IList<User>> GetUsers()
        {
            HttpClient client = new HttpClient();
            string message = await client.GetStringAsync("https://localhost:5001/Users");
            List<User> result = JsonSerializer.Deserialize<List<User>>(message);
            return result;
        }
    }
}