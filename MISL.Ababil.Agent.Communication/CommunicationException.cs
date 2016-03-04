using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Communication
{
    class CommunicationException : Exception
    {
        public CommunicationException() : base()
        {
            
        }
        public CommunicationException(string message) : base(message)
        {
            
        }
        public CommunicationException(string message, Exception inner) : base(message, inner)
        {
            
        }

    }
}
