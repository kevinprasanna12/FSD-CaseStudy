namespace LMSApp.Models
{
    public enum Role { Admin, Trainer, Learner }

    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role UserRole { get; set; }
    }
}
