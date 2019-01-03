using System;
namespace caredoctor.Services
{
    public static class Constants
    {
        public static string BASE_URL = "http://localhost:8080";
        public static string SIGNUP_URL = BASE_URL + "/signup";
        public static string LOGIN_URL = BASE_URL + "/login";
        public static string REQUEST_OTP_URL = BASE_URL + "/request_otp";

        public static string UPDATE_PATIENT_LIST_URL = BASE_URL + "/update_patient_list";

        public static string PATIENT_DATABASE = "patients";
        public static string SYNC_GATEWAY_USERNAME = "sync_gateway";
        public static string SYNC_GATEWAY_PASSWORD = "test@123";
        public static string REPLICATOR_URL = "ws://localhost:4984/patients";
    }
}
