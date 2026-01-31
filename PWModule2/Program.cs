using PWModule2;

class Program
{
    static void Main()
    {
        UserManager userManager = new UserManager();

        userManager.AddUser("YERASSYL", "yerassyl@gmail.com", "Admin");
        userManager.AddUser("Daulet", "daulet@mail.com", "User");

        userManager.UpdateUser("NURDAULET", "yerassyl@gmail.com", "Admin");
        userManager.RemoveUser("daulet@mail.com");
    }
}
