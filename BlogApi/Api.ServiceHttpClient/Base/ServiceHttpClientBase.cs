using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Api.ServiceHttpClient
{
    public class ServiceHttpClientBase<T> : IServiceHttpClient<T> where T : class
    {

        public T GetById(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:31045/");
                //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "gV-m1s1PBZScqvISAfHCAeVoXmI3csqVPmW2yC2LlpnpLvP0CRdCKrsKYyJyTzUQNV-V5jIP0BMAmoRQlt04Jt_8veezphYZQbLILzXAlyCXbmAhVumUdhfmWXbmSpNp9df-H7TlwAJ7__xPpPAft6NnzT9Tb_cfhmEUqFDp8ROy9XCFCEE4HZzZyq5hubiGPv1QaavEC0xopLes62y3zxcLwqCDnB3msGvxv8WDSMY");

                HttpResponseMessage response = client.GetAsync("api/empresa/get").Result;

                response.EnsureSuccessStatusCode();
                var books1 = response.Content.ReadAsAsync<IEnumerable<T>>().Result;

                return books1.FirstOrDefault();
            }
        }

        public T GetById(decimal id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public void InsertRange(List<T> item)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public void Delete(decimal Id)
        {
            throw new NotImplementedException();
        }
    }
}
