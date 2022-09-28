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
                    lstReultsAddPersonRec("Person",0, item);
                    lstReultsAddLine("Names Collection", 2);
                    // Cycle throuh Names Collection
                    foreach (Name personName in item.Names)
                    {
                        lstReultsAddLine("Preferred: " + personName.Preferred.ToString(), 3);
                        lstReultsAddLine("Last Name: " + personName.LastName, 3);
                        lstReultsAddLine("First Name: " + personName.FirstName, 3);
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
                            lstReultsAddLine("Marriage", 2);
                            lstReultsAddLine("Date: " + perMarriage.Date.ToString(), 2);
                            lstReultsAddLine("Place: " + perMarriage.Place.ToString(), 2);
                        }
                        // Spouse 1
                        var fromPerson = myLines.Persons.FirstOrDefault(e => e.Id == item.From.Id);
                        if (fromPerson != null)
                        {
                            lstReultsAddPersonRec("Spouse1",2, fromPerson);
                        }

                        // Retrieve Spouse 2
                        lstReultsAddLine("to:", 2);
                        var toPerson = myLines.Persons.FirstOrDefault(e => e.Id == item.To.Id);
                        if (toPerson != null)
                        {
                            lstReultsAddPersonRec("Spouse2",2, toPerson);
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
                    lstReultsAddPersonRec("Person",0, item);

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
                                lstReultsAddLine("Marriage", 2);
                                lstReultsAddLine("Date: " + marrItem.Date.ToString(), 2);
                                lstReultsAddLine("Place: " + marrItem.Place.ToString(), 2);

                            }
                            // Get  Spouse
                            var toPerson = myLines.Persons.FirstOrDefault(e => e.Id == relItem.To.Id);
                            if (toPerson != null)
                            {
                                lstReultsAddPersonRec("to", 2,toPerson);
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
                    lstReultsAddPersonRec("Person", 0,item);

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
                                lstReultsAddPersonRec("Child",2, fromPerson);
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
                    lstReultsAddPersonRec("Person",0, item);

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
                                lstReultsAddPersonRec("Parent",2, fromPerson);
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
                    lstReultsAddPersonRec("Person",0, item);
                    // Get Children for on indidivual person
                    List<Person> childList  = ChildRelationsExtender.getChildPersonsByID(myLines, item.Id);
                    if (childList != null)
                    {
                        // Cycle through children Persons
                        foreach (Person indChild in childList)
                        {
                            lstReultsAddPersonRec("Child",2, indChild);
                        }

                    }
                }
                ShowProcessingEnd();
            }
        }

        private void lstReultsAddLine(string line, int tabsCount)
        {
            string tabs = new string('\t', tabsCount);
            lstResults.Items.Add(tabs + line);

            lstResults.Refresh();
        }
        private void lstReultsAddPersonRec(string perType, int tabsCount,Person perItem)
        {
            string tabs = new string('\t', tabsCount);
            string tabs2 = new string('\t', tabsCount+1);
            lstResults.Items.Add(tabs + perType);
            lstResults.Items.Add(tabs2 + "LastName: " + perItem.LastName);
            lstResults.Items.Add(tabs2 + "FirstName: " + perItem.FirstName);
            lstResults.Items.Add(tabs2 + "Gender: " + perItem.Gender);
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
                // Gedcom File Loaded
                lblGedComLoaded.BackColor = Color.Red;
                lblGedComLoaded.ForeColor = Color.White;
                lblGedComLoaded.Text = "GEDCom File not Loaded";
                gedcomLoaded = false;
                ;
            }
        }

        private void frmSample_Load(object sender, EventArgs e)
        {
            txtFileName.Text = Samples.Default.GedFileName;
        }

        private void btnPersonsParentsExtender_Click(object sender, EventArgs e)
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
                    lstReultsAddPersonRec("Person",0, item);

                    // Get Parents for on indidivual person
                    List<Person> parentList = ParentExtender.getParentsPersonsByID(myLines, item.Id);
                    if (parentList != null)
                    {
                        // Cycle through children Persons
                        foreach (Person indChild in parentList)
                        {
                            lstReultsAddPersonRec("Parent", 2,indChild);
                        }

                    }
                }
                ShowProcessingEnd();
            }
        }

        private void btunPersonSiblings_Click(object sender, EventArgs e)
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
                lstResults.Items.Add("--- Sibling Collection");

                // Cycle through Persons
                foreach (GedcomParser.Entities.Person item in myLines.Persons)
                {
                    lstReultsAddPersonRec("Person",0, item);


                    // Get SiblingRelation list by person id
                    List<SiblingRelation> perRelations2 = myLines.SiblingRelations.FindAll(e => e.To.Id == item.Id);
                    // Remove duplicates caused by adoption records
                    List<SiblingRelation> perRelations = perRelations2.GroupBy(x => x.From.Id).Select(x => x.First()).ToList();

                    if (perRelations.Count > 0)
                    {
                        // Cycle through SiblingRelations
                        foreach (SiblingRelation relItem in perRelations)
                        {

                            // Get Sibling
                            var fromPerson = myLines.Persons.FirstOrDefault(e => e.Id == relItem.From.Id);
                            if (fromPerson != null)
                            {
                                lstReultsAddPersonRec("Sibling", 2,fromPerson);
                            }
                        }
                    }
                }
                ShowProcessingEnd();
            }
        }


        // ************* End
    }
}
