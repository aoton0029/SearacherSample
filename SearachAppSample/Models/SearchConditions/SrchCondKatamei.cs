using SearachAppSample.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearachAppSample.Models.SearchConditions
{
    public class SrchCondKatamei : ISnapshot
    {
        public string Katamei1 { get; set; } = string.Empty;

        public FilterOperation FilterOperation1 { get; set; } = FilterOperation.Equals;

        public FilterLogic? FilterLogic1 { get; set; } = null;

        public string Katamei2 { get; set; } = string.Empty;

        public FilterOperation? FilterOperation2 { get; set; } = null;

        public FilterLogic? FilterLogic2 { get; set; } = null;

        public string Katamei3 { get; set; } = string.Empty;

        public FilterOperation? FilterOperation3 { get; set; } = null;

        public DateTime? BeginNoukiDate { get; set; } = null;

        public DateTime? EndNoukiDate { get; set; } = null;

        public DateTime Timestamp => throw new NotImplementedException();

        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
