using GedcomParser.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GedcomSampleApp
{
    public partial class frmSample : Form
    {
        public frmSample()
        {
            InitializeComponent();
        }

        private void btnPersonLooping_Click(object sender, EventArgs e)
        {
          string gedFile = @"C:\Users\deanr\source\repos\GedcomParser-master\src\GedcomParser.Test\Resources\GedcomStandard\555SAMPLE.GED";
          // string gedFile = @"C:\Family Research\DNA\TestTree.ged";


            var myLines = GedcomParser.Services.FileParser.ParseFromFile(gedFile);

            // Reset Listbox
            lstResults.Items.Clear();

            lstResults.Items.Add("People Count: " + myLines.Persons.Count.ToString());

            foreach (GedcomParser.Entities.Person item in myLines.Persons)
            {
                lstResults.Items.Add("**Person**");
                lstResults.Items.Add("Person Last Name: " + item.LastName);
                lstResults.Items.Add("Person First Name: " + item.FirstName);
                lstResults.Items.Add("--- Names Collection");
                foreach (Name personName in item.Names)
                {
                    lstResults.Items.Add("--- Preferred: " + personName.Preferred.ToString());
                    lstResults.Items.Add("------ Last Name: " + personName.LastName);
                    lstResults.Items.Add("------ First Name: " + personName.FirstName);
                }
            }
            string stopPoint;
            stopPoint = "";
        }

        private void btnPersonLoopingSpouses_Click(object sender, EventArgs e)
        {
            string gedFile = @"C:\Users\deanr\source\repos\GedcomParser-master\src\GedcomParser.Test\Resources\GedcomStandard\555SAMPLE.GED";
            // string gedFile = @"C:\Family Research\DNA\TestTree.ged";


            var myLines = GedcomParser.Services.FileParser.ParseFromFile(gedFile);

            // Reset Listbox
            lstResults.Items.Clear();

            lstResults.Items.Add("Spouse Count: " + myLines.SpouseRelations.Count.ToString());

            foreach (GedcomParser.Entities.SpouseRelation item in myLines.SpouseRelations)
            {
                //Marriage
                if (item.Marriage.Count > 0)
                {
                    foreach (DatePlace perMarriage in item.Marriage)
                    {
                        lstResults.Items.Add("**Marriage**");
                        lstResults.Items.Add("--- Date: " + perMarriage.Date.ToString());
                        lstResults.Items.Add("--- Place: " + perMarriage.Place?.ToString());
                     }
                 //   var fromPerson= myLines.Persons.FirstOrDefault(p => p.Id.Trim().Equals(item.From.Id));
                    var fromPerson = myLines.Persons.FirstOrDefault(e => e.Id== item.From.Id);
                    if (fromPerson != null)
                    {
                        lstResults.Items.Add("----- LastName: " + fromPerson.LastName);
                        lstResults.Items.Add("----- FirstName: " + fromPerson.FirstName);
                    }

                    lstResults.Items.Add("----- Gender: " + item.From.Gender);
                    lstResults.Items.Add("----- to: " );
                    var toPerson = myLines.Persons.FirstOrDefault(e => e.Id == item.To.Id);
                    if (toPerson != null)
                    {
                        lstResults.Items.Add("----- LastName: " + toPerson.LastName);
                        lstResults.Items.Add("----- FirstName: " + toPerson.FirstName);
                    }
                    lstResults.Items.Add("----- Gender: " + item.To.Gender);
                }

                //    lstResults.Items.Add("Person Last Name: " + item.LastName);
                //lstResults.Items.Add("Person First Name: " + item.FirstName);
                //lstResults.Items.Add("--- Names Collection");
                //foreach (Name personName in item.Names)
                //{
                //    lstResults.Items.Add("--- Preferred: " + personName.Preferred.ToString());
                //    lstResults.Items.Add("------ Last Name: " + personName.LastName);
                //    lstResults.Items.Add("------ First Name: " + personName.FirstName);
                //}
            }
            string stopPoint;
            stopPoint = "";
        }

        private void btnPersonMarriage_Click(object sender, EventArgs e)
        {
            string gedFile = @"C:\Users\deanr\source\repos\GedcomParser-master\src\GedcomParser.Test\Resources\GedcomStandard\555SAMPLE.GED";
            // string gedFile = @"C:\Family Research\DNA\TestTree.ged";


            var myLines = GedcomParser.Services.FileParser.ParseFromFile(gedFile);

            // Reset Listbox
            lstResults.Items.Clear();

            lstResults.Items.Add("People Count: " + myLines.Persons.Count.ToString());
            lstResults.Items.Add("--- Marriage Collection");
            foreach (GedcomParser.Entities.Person item in myLines.Persons)
            {
                lstResults.Items.Add("**Person**");
                lstResults.Items.Add("Person Last Name: " + item.LastName);
                lstResults.Items.Add("Person First Name: " + item.FirstName);
                lstResults.Items.Add("Person Gender: " + item.Gender);

                //    List<SpouseRelation> perRelations = (List<SpouseRelation>)myLines.SpouseRelations.Select(e => e.From.Id == item.Id);
                List<SpouseRelation> perRelations = myLines.SpouseRelations.FindAll(e => e.From.Id == item.Id);
                //Marriage
                if (perRelations.Count > 0)
                {
                    foreach (SpouseRelation relItem in perRelations)
                    {
                        foreach (DatePlace marrItem in relItem.Marriage)
                        {
                            lstResults.Items.Add("**Marriage**");
                            lstResults.Items.Add("--- Date: " + marrItem.Date.ToString());
                            lstResults.Items.Add("--- Place: " + marrItem.Place.ToString());
                        }

                        lstResults.Items.Add("----- to: ");
                        var toPerson = myLines.Persons.FirstOrDefault(e => e.Id == relItem.To.Id);
                        if (toPerson != null)
                        {
                            lstResults.Items.Add("----- LastName: " + toPerson.LastName);
                            lstResults.Items.Add("----- FirstName: " + toPerson.FirstName);
                            lstResults.Items.Add("----- Gender: " + relItem.To.Gender);
                        }
                    }


      
                }


            }
            string stopPoint;
            stopPoint = "";
        }


    }
}
