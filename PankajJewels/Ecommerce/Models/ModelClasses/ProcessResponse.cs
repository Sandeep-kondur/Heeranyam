using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.ModelClasses
{
    public class ProcessResponse
    {
        public int statusCode { get; set; }//0-fail  or 1-success
        public string statusMessage { get; set; }//success or Failure
        public int currentId { get; set; }//CurrentId after Insertionss
        public int cartcount { get; set; }

        public string emailId { get; set; }

    }
}
