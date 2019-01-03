using System;
using Newtonsoft.Json;
using System.Net.Http;
using caredoctor.Models;
using System.Threading.Tasks;
using System.Text;

namespace caredoctor.Services
{
    public class LoginServices
    {
        HttpClient client;

        public LoginServices()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<HttpResponseMessage> Signup(LoginModel _login_model)
        {
            var uri = new Uri(string.Format(Constants.SIGNUP_URL));
            string jsonData = JsonConvert.SerializeObject(_login_model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            return await client.PostAsync(uri, content);
        }

        public async Task<HttpResponseMessage> Login(LoginModel _login_model)
        {
            var uri = new Uri(string.Format(Constants.LOGIN_URL));
            string jsonData = JsonConvert.SerializeObject(_login_model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            return await client.PostAsync(uri, content);
        }

        public async Task<HttpResponseMessage> RequestOTP(LoginModel _login_model)
        {
            var uri = new Uri(string.Format(Constants.REQUEST_OTP_URL));
            string jsonData = JsonConvert.SerializeObject(_login_model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            return await client.PostAsync(uri, content);
        }
    }
}
