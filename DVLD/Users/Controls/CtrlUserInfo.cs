using DVLD_Buisness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Users.Controls
{
    public partial class CtrlUserInfo : UserControl
    {
        public CtrlUserInfo()
        {
            InitializeComponent();
        }

        private void userControlFind1_Load(object sender, EventArgs e)
        {

        }

        private void ctrlDetails1_Load(object sender, EventArgs e)
        {

        }


        public void LoadAllUserInfo(int UserId)
        {
            ctrlDetails1.LoadPerson(ClsUser.FindUserByUserId(UserId).PersonId);
            userControlFind1.LoadUserinfo(UserId);
        }
    }
}
