using System;
using System.Collections.Generic;
using System.Text;

namespace GedcomParser.Entities
{
    public class Name
    {
        public bool Preferred { get; set; } = false;
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
    }
}