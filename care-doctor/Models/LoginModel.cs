using System;
namespace caredoctor.Models
{
    public class LoginModel
    {
        public string otp_no { get; set; }
        public string care_id { get; set; }
        public string email { get; set; }
        public string expiry_key { get; set; }

        public bool CheckEmptySignupInformation()
        {
            if (!this.email.Equals(""))
                return true;
            else
                return false;
        }

        public bool CheckEmptyLoginInformation()
        {
            if (!this.email.Equals("") && !this.otp_no.Equals(""))
                return true;
            else
                return false;
        }
    }
}
