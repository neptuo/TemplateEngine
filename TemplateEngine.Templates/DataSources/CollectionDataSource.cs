﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.DataSources
{
    /// <summary>
    /// <see cref="IListDataSource"/> that operates on <see cref="Data"/>.
    /// </summary>
    public class CollectionDataSource : IListDataSource
    {
        public IEnumerable Data { get; set; }

        public IEnumerable GetData(int? pageIndex, int? pageSize)
        {
            return Data;
        }

        public int GetTotalCount()
        {
            return 0;
        }
    }
}
