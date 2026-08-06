using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Person
{
    public partial class DetailsPerson : Form
    {
        public DetailsPerson()
        {
            InitializeComponent();
        }

        public DetailsPerson(int Id)
        {
            InitializeComponent();
            ctrlDetails1.LoadPerson(Id);
        }

        private void DetailsPerson1_Load(object sender, EventArgs e)
        {

        }
    }
}
