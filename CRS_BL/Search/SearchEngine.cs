using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newton
using Newtonsoft.Json;

namespace nus.iss.crs.bl
{
    internal class SearchEngine : ISearch
    {
        SearchEngine()
        {
            
        }
        /// <summary>
        /// Search Registration by name, id number, company,
        /// Search user
        /// search company
        /// search course by TITLE, CATEGORY, DESCRIPTION,INSTRUCTOR
        /// search class
        /// search instructor by name
        /// fulltext search
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="criteion"></param>
        /// <returns></returns>
        public async Task<T> Search<T>(string token,Search.SearchCriterion criteion)
        {
            try 
            {
                HttpClient client = new HttpClient();
                string searchUrl = "http://localhost:8983/solr/CRS/select?wt=json&indent=true&q=" + token +":" + criteion;
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, new Uri(searchUrl, UriKind.Relative));
                //requestMessage.Headers.UserAgent.TryParseAdd("MSIClient");
                HttpResponseMessage resultMessage = await client.SendAsync(requestMessage);
                resultMessage.EnsureSuccessStatusCode();
                
                if (resultMessage.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string result = await resultMessage.Content.ReadAsStringAsync();

                    List<T> resultList = JsonConvert.DeserializeObject<List<T>>(result);
                    
                }
                else
                {

                }

                
            }
            catch(Exception ex)
            {
                Console.WriteLine("Search error:" + ex);
            }

            return default(T);
        }


    }
}
