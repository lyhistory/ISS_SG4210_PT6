using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<T> Search<T>(Search.SearchCriterion criteion)
        {
            try 
            {
                string searchUrl = "http://localhost:8983/solr/CRS/select?wt=json&indent=true&q=name:" + criteion;
                //HttpRequestMessage reuestMessage = new HttpRequestMessage(HttpMethod.Get, new Uri(relativeUrl, UriKind.Relative));
                //reqMsg.Headers.UserAgent.TryParseAdd("MSIClient");
                //HttpResponseMessage resMsg = await client.SendAsync(reqMsg);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Search error:" + ex);
            }
            throw new NotImplementedException();
        }
    }
}
