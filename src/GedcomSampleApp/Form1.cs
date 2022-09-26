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
                foreach (DatePlace resPlace in item.Residence)
                {
                    Debug.WriteLine(resPlace.Date);
                    Debug.WriteLine(resPlace.Description);
                    Debug.WriteLine(resPlace.Place);
                }
            }
            string stopPoint;
            stopPoint = "";
        }
    }
}
