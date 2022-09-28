using GedcomParser.Entities;
using GedcomParser.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GedcomSampleApp
{
    public partial class frmSample : Form
    {

        Result myLines;
        bool gedcomLoaded = false;

        public frmSample()
        {
            InitializeComponent();
        }

        private void btnPersonLooping_Click(object sender, EventArgs e)
        {
            if (gedcomLoaded == false)
            {
                MessageBox.Show("Gedcom File Not loaded!");
            }
            else
            {
                ShowProcessingStart();

                // Reset Listbox
                lstResults.Items.Clear();
                lstResults.Items.Add("People Count: " + myLines.Persons.Count.ToString());

                // Cycle through Person collection
                foreach (GedcomParser.Entities.Person item in myLines.Persons)
                {
                    lstReultsAddPersonRec("Person", item);
                    lstResults.Items.Add("--- Names Collection");
                    // Cycle throuh Names Collection
                    foreach (Name personName in item.Names)
                    {
                        lstResults.Items.Add("--- Preferred: " + personName.Preferred.ToString());
                        lstResults.Items.Add("------ Last Name: " + personName.LastName);
                        lstResults.Items.Add("------ First Name: " + personName.FirstName);
                    }
                }
                ShowProcessingEnd();
            }
        }

        private void btnPersonLoopingSpouses_Click(object sender, EventArgs e)
        {
            if (gedcomLoaded == false)
            {
                MessageBox.Show("Gedcom File Not loaded!");
            }
            else
            {
                ShowProcessingStart();

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
                            lstReultsAddPersonRec("Spouse1", fromPerson);
                        }

                        // Retrieve Spouse 2
                        lstResults.Items.Add("----- to: ");
                        var toPerson = myLines.Persons.FirstOrDefault(e => e.Id == item.To.Id);
                        if (toPerson != null)
                        {
                            lstReultsAddPersonRec("Spouse2", toPerson);
                        }
                    }

                }
                ShowProcessingEnd();
            }
        }

        private void btnPersonMarriage_Click(object sender, EventArgs e)
        {
            if (gedcomLoaded == false)
            {
                MessageBox.Show("Gedcom File Not loaded!");
            }
            else
            {
                ShowProcessingStart();

                // Reset Listbox
                lstResults.Items.Clear();
                lstResults.Items.Add("People Count: " + myLines.Persons.Count.ToString());
                lstResults.Items.Add("--- Marriage Collection");

                // Cycle through Persons
                foreach (GedcomParser.Entities.Person item in myLines.Persons)
                {
                    lstReultsAddPersonRec("Person", item);

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
                            // Get  Spouse
                            var toPerson = myLines.Persons.FirstOrDefault(e => e.Id == relItem.To.Id);
                            if (toPerson != null)
                            {
                                lstReultsAddPersonRec("to", toPerson);
                            }
                        }
                    }
                }
                ShowProcessingEnd();
            }
        }

        private void LoadRawData(string gedFile)
        {
            string[] lines = System.IO.File.ReadAllLines(gedFile);
            StringBuilder rawData = new StringBuilder();
            foreach (string line in lines)
            {
                rawData.AppendLine(line);
            }
            txtRawData.Text = rawData.ToString();
        }
        private void LoadGedComFile()
        {
            // Parse Gedcom file
            //string gedFile = @"C:\Users\deanr\source\repos\GedcomParser-master\src\GedcomParser.Test\Resources\GedcomStandard\555SAMPLE.GED";
            // string gedFile = @"C:\Family Research\DNA\TestTree.ged";
            // string gedFile = @"C:\Family Research\DNA\TestTree2.ged";

            ShowProcessingStart();

            // Load Gedcom
            string gedFile = txtFileName.Text;
            myLines = GedcomParser.Services.FileParser.ParseFromFile(gedFile);

            // Load Raw Data
            LoadRawData(gedFile);

            // Gedcom File Loaded
            lblGedComLoaded.BackColor = Color.Green;
            lblGedComLoaded.ForeColor = Color.White;
            lblGedComLoaded.Text = "GEDCom File Loaded";
            gedcomLoaded = true;

            ShowProcessingEnd();
        }

        private void btnLoadGedcomFile_Click(object sender, EventArgs e)
        {
            LoadGedComFile();

        }

        private void btnPersonChildren_Click(object sender, EventArgs e)
        {
            if (gedcomLoaded == false)
            {
                MessageBox.Show("Gedcom File Not loaded!");
            }
            else
            {
                ShowProcessingStart();

                // Reset Listbox
                lstResults.Items.Clear();
                lstResults.Items.Add("People Count: " + myLines.Persons.Count.ToString());
                lstResults.Items.Add("--- Children Collection");

                // Cycle through Persons
                foreach (GedcomParser.Entities.Person item in myLines.Persons)
                {
                    lstReultsAddPersonRec("Person", item);

                    // Get ChildRelation list by person id
                    List<ChildRelation> perRelations2 = myLines.ChildRelations.FindAll(e => e.To.Id == item.Id);
                    // Remove duplicates caused by adoption records
                    List<ChildRelation> perRelations = perRelations2.GroupBy(x => x.From.Id).Select(x => x.First()).ToList();
          
                    if (perRelations.Count > 0)
                    {
                        // Cycle through ChildRelations
                        foreach (ChildRelation relItem in perRelations)
                        {

                            // Get Child
                            var fromPerson = myLines.Persons.FirstOrDefault(e => e.Id == relItem.From.Id);
                            if (fromPerson != null)
                            {
                                lstReultsAddPersonRec("Child", fromPerson);
                            }
                        }
                    }
                }
                ShowProcessingEnd();
            }
        }

        private void btunPersonParents_Click(object sender, EventArgs e)
        {
            if (gedcomLoaded == false)
            {
                MessageBox.Show("Gedcom File Not loaded!");
            }
            else
            {
                ShowProcessingStart();

                // Reset Listbox
                lstResults.Items.Clear();
                lstResults.Items.Add("People Count: " + myLines.Persons.Count.ToString());
                lstResults.Items.Add("--- Parents Collection");

                // Cycle through Persons
                foreach (GedcomParser.Entities.Person item in myLines.Persons)
                {
                    lstReultsAddPersonRec("Person", item);

                    // Get Parent list by person id
                    List<ChildRelation> perRelations2 = myLines.ChildRelations.FindAll(e => e.From.Id == item.Id);
                    List<ChildRelation> perRelations = perRelations2.GroupBy(x => x.To.Id).Select(x => x.First()).ToList();
          
                    if (perRelations.Count > 0)
                    {
                        // Cycle through SpouseRelations
                        foreach (ChildRelation relItem in perRelations)
                        {

                            // Get Parent
                            var fromPerson = myLines.Persons.FirstOrDefault(e => e.Id == relItem.To.Id);
                            if (fromPerson != null)
                            {
                                lstReultsAddPersonRec("Parent", fromPerson);
                            }
                        }
                    }
                }
                ShowProcessingEnd();
            }
        }

        private void ShowProcessingStart()
        {
            lblProcessing.Visible = true;
            lblProcessing.Refresh();
        }
        private void ShowProcessingEnd()
        {
            lblProcessing.Visible = false;
            lblProcessing.Refresh();
        }


        private void bthPersonChildrenExtender_Click(object sender, EventArgs e)
        {
            if (gedcomLoaded == false)
            {
                MessageBox.Show("Gedcom File Not loaded!");
            }
            else
            {

                ShowProcessingStart();

                // Reset Listbox
                lstResults.Items.Clear();
                lstResults.Items.Add("People Count: " + myLines.Persons.Count.ToString());
                lstResults.Items.Add("--- Children Collection");


                // Cycle through Persons
                foreach (GedcomParser.Entities.Person item in myLines.Persons)
                {
                    lstReultsAddPersonRec("Person", item);
                    // Get Children for on indidivual person
                    List<Person> childList  = ChildRelationsExtender.getChildPersonsByID(myLines, item.Id);
                    if (childList != null)
                    {
                        // Cycle through children Persons
                        foreach (Person indChild in childList)
                        {
                            lstReultsAddPersonRec("Child", indChild);
                        }

                    }
                }
                ShowProcessingEnd();
            }
        }

        private void lstReultsAddPersonRec(string perType, Person perItem)
        {
            lstResults.Items.Add("**"+ perType +"**");
            lstResults.Items.Add("----- LastName: " + perItem.LastName);
            lstResults.Items.Add("----- FirstName: " + perItem.FirstName);
            lstResults.Items.Add("----- Gender: " + perItem.Gender);
            lstResults.Refresh();
        }

        private void btnFileChooser_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Gedcom files (*.ged)|*.ged|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = openFileDialog.FileName;
                Samples.Default.GedFileName = openFileDialog.FileName;
                Samples.Default.Save();
                ;
            }
        }

        private void frmSample_Load(object sender, EventArgs e)
        {
            txtFileName.Text = Samples.Default.GedFileName;
        }


        // ************* End
    }
}
