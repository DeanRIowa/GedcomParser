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

        Result myLines;

        public frmSample()
        {
            InitializeComponent();
        }

        private void btnPersonLooping_Click(object sender, EventArgs e)
        {

            // Reset Listbox
            lstResults.Items.Clear();
            lstResults.Items.Add("People Count: " + myLines.Persons.Count.ToString());

            // Cycle through Person collection
            foreach (GedcomParser.Entities.Person item in myLines.Persons)
            {
                lstResults.Items.Add("**Person**");
                lstResults.Items.Add("Person Last Name: " + item.LastName);
                lstResults.Items.Add("Person First Name: " + item.FirstName);
                lstResults.Items.Add("--- Names Collection");
                // Cycle throuh Names
                foreach (Name personName in item.Names)
                {
                    lstResults.Items.Add("--- Preferred: " + personName.Preferred.ToString());
                    lstResults.Items.Add("------ Last Name: " + personName.LastName);
                    lstResults.Items.Add("------ First Name: " + personName.FirstName);
                }
            }
        }

        private void btnPersonLoopingSpouses_Click(object sender, EventArgs e)
        {

            // Reset Listbox
            lstResults.Items.Clear();
            lstResults.Items.Add("Spouse Count: " + myLines.SpouseRelations.Count.ToString());

            // Cycle through SpouseRelations
            foreach (GedcomParser.Entities.SpouseRelation item in myLines.SpouseRelations)
            {
                if (item.Marriage.Count > 0)
                {
                    // Cycle through Marriage
                    foreach (DatePlace perMarriage in item.Marriage)
                    {
                        lstResults.Items.Add("**Marriage**");
                        lstResults.Items.Add("--- Date: " + perMarriage.Date.ToString());
                        lstResults.Items.Add("--- Place: " + perMarriage.Place?.ToString());
                    }
                    // Spouse 1
                    var fromPerson = myLines.Persons.FirstOrDefault(e => e.Id == item.From.Id);
                    if (fromPerson != null)
                    {
                        lstResults.Items.Add("----- LastName: " + fromPerson.LastName);
                        lstResults.Items.Add("----- FirstName: " + fromPerson.FirstName);
                    }

                    lstResults.Items.Add("----- Gender: " + item.From.Gender);
                    // Retrieve Spouse 2
                    lstResults.Items.Add("----- to: ");
                    var toPerson = myLines.Persons.FirstOrDefault(e => e.Id == item.To.Id);
                    if (toPerson != null)
                    {
                        lstResults.Items.Add("----- LastName: " + toPerson.LastName);
                        lstResults.Items.Add("----- FirstName: " + toPerson.FirstName);
                    }
                    lstResults.Items.Add("----- Gender: " + item.To.Gender);
                }

            }
        }

        private void btnPersonMarriage_Click(object sender, EventArgs e)
        {

            // Reset Listbox
            lstResults.Items.Clear();
            lstResults.Items.Add("People Count: " + myLines.Persons.Count.ToString());
            lstResults.Items.Add("--- Marriage Collection");

            // Cycle through Persons
            foreach (GedcomParser.Entities.Person item in myLines.Persons)
            {
                lstResults.Items.Add("**Person**");
                lstResults.Items.Add("Person Last Name: " + item.LastName);
                lstResults.Items.Add("Person First Name: " + item.FirstName);
                lstResults.Items.Add("Person Gender: " + item.Gender);

                // Get SpouseRelation list by person id
                List<SpouseRelation> perRelations = myLines.SpouseRelations.FindAll(e => e.From.Id == item.Id);
                //Marriage
                if (perRelations.Count > 0)
                {
                    // Cycle through SpouseRelations
                    foreach (SpouseRelation relItem in perRelations)
                    {
                        // Cycle through Marriage
                        foreach (DatePlace marrItem in relItem.Marriage)
                        {
                            lstResults.Items.Add("**Marriage**");
                            lstResults.Items.Add("--- Date: " + marrItem.Date.ToString());
                            lstResults.Items.Add("--- Place: " + marrItem.Place.ToString());
                        }
                        // Get Spouse their Spouse
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
        }

        private void btnLoadGedcomFile_Click(object sender, EventArgs e)
        {
            // Parse Gedcom file
            string gedFile = @"C:\Users\deanr\source\repos\GedcomParser-master\src\GedcomParser.Test\Resources\GedcomStandard\555SAMPLE.GED";
            // string gedFile = @"C:\Family Research\DNA\TestTree.ged";
            myLines = GedcomParser.Services.FileParser.ParseFromFile(gedFile);
            MessageBox.Show("Gedcom File Loaded");
        }
    }
}
