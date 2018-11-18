using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortlandTimbers.Models
{
    public class Player
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Nationality { get; set; }
        public string Position { get; set; }
        public int Number { get; set; }
    }
}