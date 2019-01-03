using System;
namespace caredoctor.Models
{
    public class PatientModel
    {
        public string otp_no { get; set; }
        public string care_id { get; set; }
        public string email { get; set; }
        public string expiry_key { get; set; }
        public string name { get; set; }
        public string mobile { get; set; }
        public string dob { get; set; }
        public string gender { get; set; }
    }
}
