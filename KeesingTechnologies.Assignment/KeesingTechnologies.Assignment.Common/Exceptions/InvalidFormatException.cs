using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeesingTechnologies.Assignment.Common.Exceptions
{
    public class InvalidFormatException : Exception
    {
        public InvalidFormatException(string message)
                        : base(string.Format("{0} {1}", message, " - format is not valid"))
        {

        }
    }
}
