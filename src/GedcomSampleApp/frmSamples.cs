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
            var myLines = GedcomParser.Services.FileParser.ParseFromFile(@"C:\Users\deanr\source\repos\GedcomParser-master\src\GedcomParser.Test\Resources\GedcomStandard\555SAMPLE.GED");

            foreach (GedcomParser.Entities.Person item in myLines.Persons)
            {
                // debug.(item.LastName);
                Debug.WriteLine(item.LastName);
                Debug.WriteLine(item.FirstName);
                foreach (Name personName in item.Names)
                {
                    Debug.WriteLine(personName.LastName);
                    Debug.WriteLine(personName.FirstName);
                    Debug.WriteLine(personName.Preferred.ToString());
                }
            }
            string stopPoint;
            stopPoint = "";
        }
    }
}
