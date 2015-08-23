using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerDataLibrary.Exceptions
{
    class PlayerNotFoundException : Exception
    {
        public PlayerNotFoundException(String msg) : base(msg) { }
    }
    class TeamNotFoundException : Exception
    {
        public TeamNotFoundException(String msg) : base(msg) { }
    }
    class UnavailableConnectionException : Exception
    {
        public UnavailableConnectionException(String msg) : base(msg) { }
    }
}
