using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using xamApi.Models;

namespace xama.Services
{
  class Service
  {
    public async Task Login(string username, string password)
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
        await clientHtpp.PostAsync("http://10.0.2.2:5000/users/login", content);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
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
  }
}
