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

            foreach (GedcomParser.Entities.Person item in myLines.Persons)
            {
       
                lstResults.Items.Add("Person Last Name: " + item.LastName);
                lstResults.Items.Add("Person First Name: " + item.FirstName);
                lstResults.Items.Add("Names Collection");
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
    }
}
