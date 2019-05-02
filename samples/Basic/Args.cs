namespace Basic
{
    internal class Args
    {
        public AddUserCommand AddUser { get; set; }

        public class AddUserCommand
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
