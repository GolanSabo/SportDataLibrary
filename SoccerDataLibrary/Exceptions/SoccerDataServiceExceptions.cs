using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerDataLibrary.Exceptions
{
    /// <summary>The exception that is thrown when player was not found in api </summary>
    class PlayerNotFoundException : Exception
    {
        public PlayerNotFoundException(String msg) : base(msg) { }
    }
    /// <summary>The exception that is thrown when team was not found in api </summary>
    class TeamNotFoundException : Exception
    {
        public TeamNotFoundException(String msg) : base(msg) { }
    }
    /// <summary>The exception that is thrown when player was not found in a spesific team </summary>
    class TeamPlayersNotFoundException : Exception
    {
        public TeamPlayersNotFoundException(String msg) : base(msg) { }
    }
    /// <summary>The exception that is thrown when connection to api failed </summary>
    class UnavailableConnectionException : Exception
    {
        public UnavailableConnectionException(String msg) : base(msg) { }
    }
}
