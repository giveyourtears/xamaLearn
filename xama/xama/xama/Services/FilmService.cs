using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using xamaLibrary;

namespace xama.Services
{
    class FilmService
    {
        private HttpClient _client = new HttpClient();

        public async Task<IEnumerable<FilmModel>> GetFilms()
        {
            try
            {
                var response = _client.PostAsync("http://10.0.2.2:5000/films/getall", null).Result;
                var result = await response.Content.ReadAsStringAsync();
                return response.StatusCode == HttpStatusCode.OK ? JsonConvert.DeserializeObject<List<FilmModel>>(result) : null;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error is " + ex);
                return null;
            }
        }

        public async void UpdateFilm(FilmModel film)
        {
            try
            {
                var json = JsonConvert.SerializeObject(film);
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, "http://10.0.2.2:5000/films/getall")
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };
                await _client.SendAsync(requestMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in " + ex);
            }
        }

        public async void DeleteFilm(int id)
        {
            try
            {
                await _client.DeleteAsync("http://10.0.2.2:5000/films/delete?id=" + id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in " + ex);
            }
        }
    }
}
