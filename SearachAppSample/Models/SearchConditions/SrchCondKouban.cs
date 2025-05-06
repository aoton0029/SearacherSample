using SearachAppSample.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearachAppSample.Models.SearchConditions
{
    public class SrchCondKouban : ISnapshot
    {
        public string Kouban { get; set; } = string.Empty;

        public DateTime? BeginNoukiDate { get; set; }

        public DateTime? EndNoukiDate { get; set; }

        public DateTime Timestamp => throw new NotImplementedException();

        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
