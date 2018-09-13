using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace care_doctor
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnSignup(object sender, EventArgs e){
            LoginStack.IsVisible = false;
            SignupStack.IsVisible = true;
        }

        private void BtnRequestOtp(object sender, EventArgs e){
            txtEmailOtp.IsVisible = true;
            btnLogin.IsVisible = true;
            btnRequestOtp.IsVisible = false;
        }

        private void BtnSignupComplete(object sender, EventArgs e){
            LoginStack.IsVisible = true;
            SignupStack.IsVisible = false;
        }
    }
}
