using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Common
{
        public class BusinessValidationException : Exception
        {
            public BusinessValidationException(string message) : base(message)
            {
            }

            public BusinessValidationException(string message, Exception ex) : base(message, ex)
            {
            }
        }
}
