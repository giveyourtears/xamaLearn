using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using xamaLibrary;

namespace xama.Services
{
    class FilmService
    {
        private HttpClient _client = new HttpClient();

        public IList<FilmModel> GetFilms()
        {
            try
            {
                IList<FilmModel> data;
                var response = _client.GetAsync("http://10.0.2.2:5000/films/getall");
                var resultString = response.GetAwaiter().GetResult();
                response.Wait();
                using(HttpContent content = resultString.Content)
                {
                    var json = content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<List<FilmModel>>(json.Result);
                }
                return resultString.StatusCode == HttpStatusCode.OK ? data.ToList() : null;
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
