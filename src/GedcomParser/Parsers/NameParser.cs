using GedcomParser.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GedcomParser.Parsers
{
    public static class NameParser
    {

        internal static Name ParseName(string[] nameSections, bool preferred, ref string firstName, ref string lastName)
        {
            var gedName = new Name();
            if (nameSections.Length > 0)
            {
                firstName = nameSections[0];
                gedName.FirstName = nameSections[0];
            }

            if (nameSections.Length > 1)
            {
                lastName = nameSections[1];
                gedName.LastName = nameSections[1];
            }
            gedName.Preferred = preferred;

            return gedName;

        }

    }
}
