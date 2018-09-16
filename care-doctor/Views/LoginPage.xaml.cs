using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using caredoctor.Models;
using caredoctor.Services;
using System.Net.Http;
using System.Net;

namespace care_doctor.Views
{
    public partial class LoginPage : ContentPage
    {
        LoginModel _login_model;
        LoginServices _login_services;

        public LoginPage()
        {
            InitializeComponent();
            _login_model = new LoginModel();
            _login_services = new LoginServices();
        }

        // Login scenario - Direct and After Signup

        public async void BtnLoginComplete()
        {
            //this._login_model.email = txtEmail.Text.ToString();
            this._login_model.otp_no = txtEmailOtp.Text.ToString();
            if (this._login_model.CheckEmptyLoginInformation())
            {
                HttpResponseMessage login_response;
                login_response = await Task.Run(async () => await _login_services.Login(_login_model));
                Console.WriteLine(login_response.StatusCode);
                if (login_response.StatusCode == HttpStatusCode.OK)
                {
                    await DisplayAlert("Care-Doctor", "Login Success", "OK");
                }
                else
                {
                    await DisplayAlert("Care-Doctor", "Login Failed. Invalid Email or OTP", "OK");
                }
            }
            else
            {
                await DisplayAlert("Care-Doctor", "Email and OTP can't be empty. Please enter valid email and OTP", "OK");
            }
        }

        public void BtnSignup(object sender, EventArgs e)
        {
            LoginStack.IsVisible = false;
            SignupStack.IsVisible = true;
        }

        // OTP Request scenario for login

        public async void BtnRequestOtp(object sender, EventArgs e)
        {
            this._login_model.email = txtEmail.Text.ToString();
            if (txtEmail.Text != null)
            {
                HttpResponseMessage request_otp_response;
                request_otp_response = await Task.Run(async () => await _login_services.RequestOTP(_login_model));
                Console.WriteLine(request_otp_response.StatusCode);
                if (request_otp_response.StatusCode == HttpStatusCode.OK)
                {
                    await DisplayAlert("Care-Doctor", "OTP has sent to your email address. Enter the OTP now", "OK");
                    txtEmailOtp.IsVisible = true;
                    btnLogin.IsVisible = true;
                    btnRequestOtp.IsVisible = false;
                }
                else
                {
                    await DisplayAlert("Care-Doctor", "Invalid email. Please enter valid email", "OK");
                }
            }
            else
            {
                await DisplayAlert("Care-Doctor", "Email can't be empty. Please enter valid email", "OK");
            }
        }

        // New user signup scenario

        public async void BtnSignupComplete(object sender, EventArgs e)
        {
            this._login_model.email = txtSignupEmail.Text;
            if (this._login_model.CheckEmptySignupInformation())
            {
                HttpResponseMessage signup_response;
                //Task<HttpResponseMessage> task = Task.Run(() => _login_services.Signup(txtSignupEmail.Text));
                //HttpResponseMessage b = task.Result;
                //Console.WriteLine(b.StatusCode);
                signup_response = await Task.Run(async () => await _login_services.Signup(_login_model));
                Console.WriteLine(signup_response.StatusCode);
                await DisplayAlert("Care-Doctor", "OTP has sent to your email address. Enter the OTP now", "OK");
            }
            else
            {
                await DisplayAlert("Care-Doctor", "Email can't be empty. Please enter valid email", "OK");
            }
            LoginStack.IsVisible = true;
            SignupStack.IsVisible = false;
            txtEmailOtp.IsVisible = true;
            txtEmail.Text = txtSignupEmail.Text;
            btnLogin.IsVisible = true;
            btnRequestOtp.IsVisible = false;
        }
    }
}
