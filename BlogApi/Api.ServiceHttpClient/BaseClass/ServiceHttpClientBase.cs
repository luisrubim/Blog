using Api.ServiceHttpClient.BaseClass;
using Business.Entitie.Infra;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Api.ServiceHttpClient
{
    public class ServiceHttpClientBase<T> : IServiceHttpClient<T> where T : class
    {
        protected HttpClient client;
        protected string controller;

        public ServiceHttpClientBase()
        {
            client = new HttpClient();
        }

        public void SetParametros(string url, LoginTokenResult token)
        {
            client.BaseAddress = new Uri(url);
            if(token != null && !String.IsNullOrEmpty(token.AccessToken))
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.AccessToken);
        }

        public virtual T GetById(Guid id)
        {
            HttpResponseMessage response = client.GetAsync(string.Format("api/{0}/GetById/{1}", typeof(T).Name, id)).Result;

            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<T>().Result;
            else
                throw new Exception(ReturnErro.GetErro(response));
        }

        public List<T> GetAll()
        {        
            string url = "api/" + typeof(T).Name + "/getall";
            HttpResponseMessage response = client.GetAsync(url).Result;            

            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<IEnumerable<T>>().Result.ToList();
            else
                throw new Exception(ReturnErro.GetErro(response));
        }

        public T Save(T entity)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("api/" + typeof(T).Name + "/Save/", entity).Result;

            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<T>().Result;
            else
                throw new Exception(ReturnErro.GetErro(response));
          }
    }
}
