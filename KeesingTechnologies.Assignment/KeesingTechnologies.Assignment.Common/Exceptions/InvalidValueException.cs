using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeesingTechnologies.Assignment.Common.Exceptions
{
    public class InvalidValueException : Exception
    {
        public InvalidValueException(string message)
            : base(string.Format("{0} {1}", message, " - Invalid price value"))
        { }
    }
}
