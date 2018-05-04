using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    public class HandlerException : Exception
    {
        public HandlerException(string message)
				: base(message)
			{
        }

        public HandlerException(string format, params object[] args)
				: base(string.Format(format, args)) { }
    }
}
