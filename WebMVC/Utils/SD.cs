namespace WebMVC.Utils
{
    public class SD
    {
        public static string AuthAPIBase { get; set; }
        public static string BlogAPIBase { get; set; }
        public static string ChatAPIBase { get; set; }
        public const string TokenCookie = "JWTToken";

        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE,
        }
    }
}
