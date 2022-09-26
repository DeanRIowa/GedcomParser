using GedcomParser.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GedcomParser.Parsers
{
    public static class NameParser
    {

        internal static Name ParseName(string[] nameSections)
        {
            var gedName = new Name();
            if (nameSections.Length > 0)
            {
                gedName.FirstName = nameSections[0];
            }

            if (nameSections.Length > 1)
            {
                gedName.LastName = nameSections[1];
            }

            return gedName;

        }

    }
}
