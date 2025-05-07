using SearachAppSample.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearachAppSample.Models.SearchConditions
{
    public class SrchCondChuban : ISnapshot
    {
        public int? OrderKeyNo { get; set; } = null;

        public string OrderSheetNo { get; set; } = string.Empty;

        public int? GroupNo { get; set; } = null;

        public DateTime Timestamp => throw new NotImplementedException();

        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
