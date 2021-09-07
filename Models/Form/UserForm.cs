using Models.Enum;

namespace Models.Form
{
    public class UserForm
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public GradeType Grade { get; set; }
    }
}