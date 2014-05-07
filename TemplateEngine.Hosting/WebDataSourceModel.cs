﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Hosting
{
    public class WebDataSourceModel
    {
        public string DataSource { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public bool IsListMode { get; set; }
    }
}
