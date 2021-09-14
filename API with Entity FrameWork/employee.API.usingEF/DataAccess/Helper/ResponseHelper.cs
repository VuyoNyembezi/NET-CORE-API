using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Helper
{
    public class ResponseHelper
    {
        public bool IsSucesss { get; set; }
        public string Message { get; set; }
        public List<string> Error { get; set; }

    }
}
