using System;
using System.Collections.Generic;
using System.Text;

namespace Db.Models.QueriesOld
{
    class CommonQueryBuilder<T> : QueryBuilder
    {
        private string Query { get; set; }

        public CommonQueryBuilder(string query)
        {
            Query = query;
        }

        public override string Build(bool isReturning = true)
        {
            return Query;
        }
    }
}
