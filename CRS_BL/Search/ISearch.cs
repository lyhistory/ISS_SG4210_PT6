using nus.iss.crs.bl.Search;
using nus.iss.crs.dm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.bl
{
    public interface ISearch
    {
        Task<List<BaseSearchValueObject>> Search(SearchCriterion criteion);

    }
}
