namespace MM.RequestResponseMiddleware.TestAPI.Models
{
    public class UserLoginResponseModel
    {
        public bool Success { get; set; }
        public string UserEmail { get; set; } = null!;
    }
}
