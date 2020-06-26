using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using xamaLibrary;
using Xamarin.Forms;

namespace xama.Services
{
  class Service
  {
    public async Task<UserClient> Login(string username, string password)
    {
      try
      {
        var regModel = new RegisterModel()
        {
          Username = username,
          Password = password,
        };
        var json = JsonConvert.SerializeObject(regModel);

        HttpContent content = new StringContent(json);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var clientHtpp = new HttpClient();
        var httpResponse = await clientHtpp.PostAsync("http://10.0.2.2:5000/users/login", content);
        var resp = httpResponse.Content.ReadAsStringAsync().Result;
        var respJson = JsonConvert.DeserializeObject<UserClient>(resp);
        return httpResponse.StatusCode == HttpStatusCode.OK ? respJson : null;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }

    public async Task<bool> Register(string firstName, string lastName, string username, string password)
    {
      try
      {
        var httpClient = new HttpClient();

        var regModel = new RegisterModel()
        {
          Username = username,
          Password = password,
          FirstName = firstName,
          LastName = lastName
        };

        var json = JsonConvert.SerializeObject(regModel);

        HttpContent content = new StringContent(json);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var response = await httpClient.PostAsync("http://10.0.2.2:5000/users/register", content);
        return response.IsSuccessStatusCode;
      } catch (Exception ex)
      {
        Console.WriteLine(ex);
        return false;
      }
    }

    public async Task<bool> Update(int id, string username, string firstname, string lastname)
    {
      try
      {
        var httpClient = new HttpClient();
        var updateModel = new UpdateModel()
        {
          FirstName = firstname,
          LastName = lastname,
          Username = username
        };
        var json = JsonConvert.SerializeObject(updateModel);

        HttpContent content = new StringContent(json);
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", (string) Application.Current.Properties["token"]);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var response = await httpClient.PutAsync($"http://10.0.2.2:5000/users/{id}", content);
        return response.IsSuccessStatusCode;
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error in " + ex.Message);
        return false;
      }
    }
  }
}
