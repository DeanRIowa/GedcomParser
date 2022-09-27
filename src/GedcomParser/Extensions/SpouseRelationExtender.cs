using GedcomParser.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GedcomParser.Extensions
{
    public static class SpouseRelationExtender
    {
        public static List<SpouseRelation> getSpouseRelationsByID(Result gedData, string PersonId)
        {
            return gedData.SpouseRelations.FindAll(e => e.From.Id == PersonId);
        }
    }
}