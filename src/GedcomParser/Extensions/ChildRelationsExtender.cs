using GedcomParser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GedcomParser.Extensions
{
    public static class ChildRelationsExtender
    {

        public static List<ChildRelation> getChildRelationsByID(Result gedData, string PersonId)
        {
            // ChildRelation
            List<ChildRelation> childRel = gedData.ChildRelations.FindAll(e => e.To.Id == PersonId);
            return childRel.GroupBy(x => x.From.Id).Select(x => x.First()).ToList();
        }
        public static List<Person> getChildPersonsByID(Result gedData, string PersonId)
        {

            List<Person> perList = new List<Person>();

            // ChildRelation
            List<ChildRelation> childRel2 = gedData.ChildRelations.FindAll(e => e.To.Id == PersonId);
            List<ChildRelation> childRel = childRel2.GroupBy(x => x.From.Id).Select(x => x.First()).ToList();

            if (childRel.Count > 0)
            {
                // Cycle through ChildRelations
                foreach (ChildRelation relItem in childRel)
                {
                    // Get Child
                    Person fromPerson= gedData.Persons.FirstOrDefault(e => e.Id == relItem.From.Id);
                    if (fromPerson != null)
                    {
                        perList.Add(fromPerson);

                    }
                }
            }
            return perList;

        }

    }
}
