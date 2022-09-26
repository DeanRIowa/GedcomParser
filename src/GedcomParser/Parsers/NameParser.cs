using GedcomParser.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GedcomParser.Parsers
{
    public static class NameParser
    {

        internal static Name ParseName(string[] nameSections, int nameCount)
        {
            var gedName = new Name();
            // FirstName
            if (nameSections.Length > 0)
            {
                gedName.FirstName = nameSections[0];
            }
            // LastName
            if (nameSections.Length > 1)
            {
                gedName.LastName = nameSections[1];
            }
            // Preferred
            if (nameCount== 0)
            {
                gedName.Preferred = true;
            }
            else
            {
                gedName.Preferred = false;
            }


            return gedName;

        }

    }
}
