using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinéBuddy.Exceptions
{
    public class KonNietMetDeDatabaseVerbinden : Exception
    {
        public KonNietMetDeDatabaseVerbinden(string message):base(message)
        {

        }
    }
}