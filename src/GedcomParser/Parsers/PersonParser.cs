﻿using System;
using System.Collections.Generic;
using System.Linq;
using GedcomParser.Entities;
using GedcomParser.Entities.Internal;

namespace GedcomParser.Parsers
{
    public static class PersonParser
    {
        internal static void ParsePerson(this ResultContainer resultContainer, GedcomChunk indiChunk)
        {
            var person = new Person {Id = indiChunk.Id};
  

            foreach (var chunk in indiChunk.SubChunks)
            {
                switch (chunk.Type)
                {
                    case "_UID":
                        person.Uid = chunk.Data;
                        break;

                    case "ADOP":
                        person.Adoption = resultContainer.ParseAdoption(chunk);
                        break;

                    case "BAPM":
                        person.Baptized = resultContainer.ParseDatePlace(chunk);
                        break;

                    case "BIRT":
                        person.Birth = resultContainer.ParseDatePlace(chunk);
                        break;

                    case "BURI":
                        person.Buried = resultContainer.ParseDatePlace(chunk);
                        break;

                    case "CHAN":
                        person.Changed = chunk.ParseDateTime();
                        break;

                    case "CHR":
                        person.Baptized = resultContainer.ParseDatePlace(chunk);
                        break;

                    case "DEAT":
                        person.Death = resultContainer.ParseDatePlace(chunk);
                        break;

                    case "EDUC":
                        person.Education = chunk.Data;
                        break;
                    case "EVEN":
                        string eventType = GetEventType(chunk);
                        if (person.Events.ContainsKey(eventType))
                        {
                            person.Events[eventType].Add(resultContainer.ParseDatePlace(chunk));
                        }
                        else 
                        {
                            person.Events.Add(eventType, new List<DatePlace>
                            {
                                resultContainer.ParseDatePlace(chunk)
                            });
                        }
                        break;

                    case "EMIG":
                        person.Emigrated.Add(resultContainer.ParseDatePlace(chunk));
                        break;

                    case "FACT":
                        person.Note = resultContainer.ParseNote(person.Note, chunk);
                        break;

                    case "GRAD":
                        person.Graduation = resultContainer.ParseDatePlace(chunk);
                        break;

                    case "HEAL":
                        person.Health = chunk.Data;
                        break;

                    case "IDNO":
                        person.IdNumber = chunk.Data;
                        break;

                    case "IMMI":
                        person.Immigrated.Add(resultContainer.ParseDatePlace(chunk));
                        break;

                    case "NAME":
                        if (!String.IsNullOrEmpty(chunk.Data))
                        {
                            // Add all names to list, first name encountered is considered preferred name
                            string[] nameSections = chunk.Data.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            Name tmpName = NameParser.ParseName(nameSections, person.Names.Count);
                            if (person.Names.Count == 0)
                            {
                                person.LastName = tmpName.LastName;
                                person.FirstName = tmpName.FirstName;
                            }
                            person.Names.Add(tmpName);
                        }

                        break;


                    case "NATU":
                        person.BecomingCitizen.Add(resultContainer.ParseDatePlace(chunk));
                        break;

                    case "NOTE":
                        person.Note = resultContainer.ParseNote(person.Note, chunk);
                        break;

                    case "OCCU":
                        person.Occupation = chunk.Data;
                        break;

                    case "RESI":
                        person.Residence.Add(resultContainer.ParseDatePlace(chunk));
                        break;

                    case "CENS":
                        person.Census.Add(resultContainer.ParseDatePlace(chunk));
                        break;

                    case "_DEST":
                        person.Destination.Add(resultContainer.ParseDatePlace(chunk));
                        break;

                    case "RELI":
                        person.Religion = chunk.Data;
                        break;

                    case "SEX":
                        person.Gender = chunk.Data;
                        break;

                    case "TITL":
                        person.Title = chunk.Data;
                        break;

                    // Deliberately skipped for now
                    case "_GRP":
                    case "CONF":
                    case "DSCR":
                    case "FAMS":
                    case "FAMC":
                    case "HIST":
                    case "NCHI":
                    case "NMR":
                    case "OBJE":
                    case "PAGE":
                    case "RIN":
                    case "SOUR":
                        resultContainer.Warnings.Add($"Skipped Person Type='{chunk.Type}'");
                        break;

                    default:
                        resultContainer.Errors.Add($"Failed to handle Person Type='{chunk.Type}'");
                        break;
                }
            }

            resultContainer.Persons.Add(person);
        }

        internal static string GetEventType(GedcomChunk chunk)
        {
            return chunk.SubChunks.SingleOrDefault(c => c.Type == "TYPE")?.Data.ToLower();
        }



    }
}