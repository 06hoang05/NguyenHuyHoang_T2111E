namespace WebApi.Models
{
    public class UpdatePasswordModel
    {
        public long StudentId { get; set; }
        public string Password { get; set; }
        public string OldPassword { get; set; }
    }
}
