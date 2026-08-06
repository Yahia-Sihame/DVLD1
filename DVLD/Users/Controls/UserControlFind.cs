using DVLD.Person.Controls;
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
    public partial class UserControlFind : UserControl
    {
         ClsUser _user ;
        public UserControlFind()
        {
            InitializeComponent();
        }

        void initialize()
        {

            lblUserID.Text = "???";
            lblUserName.Text = "???";
            lblIsActive.Text = "???";
        }

        public  void LoadUserinfo(int UserId)
        {
            bool isExist = ClsUser.IsUserExist(UserId);
            if (isExist == true)
            {
                _user = ClsUser.FindUserByUserId(UserId);
                load();
            }
            else
            {
                initialize();
            } 
                
        }
        void load()
        {
            lblUserID.Text = _user.UserId.ToString();
            lblUserName.Text = _user.UserName.ToString();
            lblIsActive.Text = _user.IsActive.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
