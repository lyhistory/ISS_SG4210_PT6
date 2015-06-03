using nus.iss.crs.dm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.bl.Search
{
    public class SearchCriterion
    {
        private List<SearchCriterionItem> conditionList = new List<SearchCriterionItem>();

        public void AddCriterionItem(SearchCriterionItem item)
        {
            conditionList.Add(item);
        }
    }
}
