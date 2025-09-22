using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4
{
    public class APIresponse
    {
        public string table { get; set; }
        public string no { get; set; }
        public string effectiveDate { get; set; }
        public List<Rate> rates { get; set; }
    }
}
