using GedcomParser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GedcomParser.Extensions
{
    public static class ParentExtender
    {

        public static List<ChildRelation> getParentsRelationsByID(Result gedData, string PersonId)
        {
            // Parents from ChildRelation
            List<ChildRelation> childRel = gedData.ChildRelations.FindAll(e => e.From.Id == PersonId);
            return childRel.GroupBy(x => x.To.Id).Select(x => x.First()).ToList();


         }

        public static List<Person> getParentsPersonsByID(Result gedData, string PersonId)
        {

            List<Person> perList = new List<Person>();

            // ChildRelation
            // Parents from ChildRelation
            List<ChildRelation> childRel2 = gedData.ChildRelations.FindAll(e => e.From.Id == PersonId);
            List<ChildRelation> childRel = childRel2.GroupBy(x => x.To.Id).Select(x => x.First()).ToList();


            if (childRel.Count > 0)
            {
                // Cycle through ChildRelations
                foreach (ChildRelation relItem in childRel)
                {
                    // Get Child
                    Person ToPerson = gedData.Persons.FirstOrDefault(e => e.Id == relItem.To.Id);
                    if (ToPerson != null)
                    {
                        perList.Add(ToPerson);

                    }
                }
            }
            return perList;
        }

    }
}
