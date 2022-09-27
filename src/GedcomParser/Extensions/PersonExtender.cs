using GedcomParser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GedcomParser.Extensions
{
    public static class PersonExtender
    {

        public static Person getPersonByID(Result gedData, string PersonId)
        {

            return gedData.Persons.FirstOrDefault(e => e.Id == PersonId);
        }


    }
}
