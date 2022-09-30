using GedcomParser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GedcomParser.Extensions
{
    public static class PersonExtender
    {

        public static Person getPersonByID(Result gedData, string PersonId)
        {

            Person tmpPerson = gedData.Persons.FirstOrDefault(e => e.Id == PersonId);
            return tmpPerson;
        }

        // Combines all Person properties using the dataplace pbject into one list
        public static List<DatePlace> getPersonPlacesByID(Result gedData, string PersonId)
        {
            List<DatePlace> places = new List<DatePlace>();
            Person tmpPerson = getPersonByID(gedData, PersonId);
            if (tmpPerson != null)
            {
                places = getPersonPlaces(tmpPerson);
            }

            return places;
        }

        #region Places
        private static List<DatePlace> getPersonPlaces(Person perData)
        {
            List<DatePlace> places = new List<DatePlace>();

            Type type = perData.GetType();
            PropertyInfo[] props = type.GetProperties();
            string str = "{";
            foreach (var prop in props)
            {

                string propStruc = prop.GetValue(perData) + "";

                // Single DatePlace
                if (propStruc == "GedcomParser.Entities.DatePlace")
                {
                    DatePlace placeData = (DatePlace)prop.GetValue(perData);
                    //  str += objData.Id + " " + prop.Name + Environment.NewLine;
                    if (placeData.Date != null || placeData.Place != null)
                    {
                        placeData.Description = prop.Name;
                        places.Add(placeData);
                    }
                }
                // List of DatePlaces
                if (propStruc == "System.Collections.Generic.List`1[GedcomParser.Entities.DatePlace]")
                {
                    List<DatePlace> placeData = (List<DatePlace>)prop.GetValue(perData);
                    foreach (var item in placeData)
                    {
                        if (item.Date != null || item.Place != null)
                        {
                            item.Description = prop.Name;
                            places.Add(item);
                        }
                    }
                }
                // Dictionary
                if (propStruc == "System.Collections.Generic.Dictionary`2[System.String,System.Collections.Generic.List`1[GedcomParser.Entities.DatePlace]]")
                {

                    Dictionary<string, List<DatePlace>> placeData = (Dictionary<string, List<DatePlace>>)prop.GetValue(perData);
                    foreach (KeyValuePair<string, List<DatePlace>> ele1 in placeData)
                    {
                        List<DatePlace> placeData2 = (List<DatePlace>)ele1.Value;
                        foreach (var item in placeData2)
                        {
                            if (item.Date != null || item.Place != null)
                            {
                                // item.Description = ele1.Key;
                                item.Description = ele1.Key;
                                places.Add(item);
                            }
                        }

                    }
                }
            }
            return places;
        }


            #endregion


        }
}
