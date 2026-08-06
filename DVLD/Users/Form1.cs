using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Person.Controls;
using DVLD.Users.Controls;
using DVLD_Buisness_Layer;

namespace DVLD.Users
{
    public partial class Form1 : Form
    {
        int _UserId;
        ClsUser _User = null;
        public Form1()
        {
            InitializeComponent();
        }

        public Form1(int UserId)
        {
            InitializeComponent();
            _UserId = UserId;
            _User = ClsUser.FindUserByUserId(UserId);
            LoadData();
        }


        void LoadData()
        {
            ctrlDetails1.LoadPerson(_User.PersonId);
            userControl11.LoadUserinfo(_UserId);
        }
       

        private void userControl11_Load(object sender, EventArgs e)
        {

        }
    }
}
