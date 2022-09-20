using MongoDB.Bson;

namespace PtmScreeCaptureServer.Model
{
    public class User : BaseDocument
    {
        public string UserName { get; set; } = "";
        
        public string Login { get; set; } = "";
        public string Password { get; set; } = "";

        public UserRole Role { get; set; } = new UserRole();

    }
}
