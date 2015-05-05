using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.bl
{
    internal class SearchEngine : ISearch
    {
        /// <summary>
        /// Search Registration by ame, id number, company,
        /// Search user
        /// search company
        /// search course by TITLE, CATEGORY, DESCRIPTION,INSTRUCTOR
        /// search class
        /// search instructor by name
        /// fulltext search
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="criteion"></param>
        /// <returns></returns>
        public List<T> Search<T>(Search.SearchCriterion criteion)
        {
            throw new NotImplementedException();
        }
    }
}
