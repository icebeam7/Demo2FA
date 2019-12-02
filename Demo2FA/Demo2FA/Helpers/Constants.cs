namespace Demo2FA.Helpers
{
    public static class Constants
    {
        public readonly static string AuthyAPIKey = "your-production-key";
        public readonly static string AuthyBaseURL = "https://api.authy.com/";

        public readonly static string AddUserURL = "protected/json/users/new";
        public readonly static string SendOTPURL = "protected/json/sms";
        public readonly static string VerifyTokenURL = "protected/json/verify";
    }
}
