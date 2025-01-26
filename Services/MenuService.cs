using CreatingAndListingUsers.Factories;
using CreatingAndListingUsers.Models;
using System.Runtime.CompilerServices;

namespace CreatingAndListingUsers.Services
{
    public class MenuService
    {
        private UserService _userService = new UserService();
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine($"{"1.",-2} Create New User");
            Console.WriteLine($"{"2.",-2} View Users");
            Console.WriteLine($"{"Q.",-2} Quit Application");
            Console.WriteLine("----------------------------------");
            Console.Write("Choose Your Meny Options: ");
            var userOption = Console.ReadLine()!;

            MenySelector(userOption);
        }

        private void MenySelector(string userOption)
        {
            switch (userOption.ToLower())
            {
                case "1":
                    CreateUser();
                    break;
                case "2":
                    ViewUsers();
                    break;
                case "q":
                    QuitConsole();
                    break;
                default:
                    InvalidOptions();
                    Menu();
                    break;
            }
        }
        private void CreateUser()
        {
            UserRegistrationForm userRegistrationForm = UserFactory.Create();
            UserEntity user = new();

            Console.WriteLine($"CREATE USER \n----------------------------------");
            Console.Write("Enter Your First Name: ");
            userRegistrationForm.FirstName = Console.ReadLine()!;
            Console.Write("Enter Your Last Name: ");
            userRegistrationForm.LastName = Console.ReadLine()!;
            Console.Write("Enter Your Email: ");
            userRegistrationForm.Email = Console.ReadLine()!;
            Console.Write("Enter Your Phone Number: ");
            userRegistrationForm.PhoneNumber = Console.ReadLine()!;
            Console.Write("Enter Your Street Address: ");
            userRegistrationForm.StreetAddress = Console.ReadLine()!;
            Console.Write("Enter Your City: ");
            userRegistrationForm.City = Console.ReadLine()!;
            Console.Write("Enter Your Zip Code: ");
            userRegistrationForm.ZipCode = Console.ReadLine()!;


            bool result = _userService.Create(userRegistrationForm);
            if (result)
            {
                Dialog("User was successfully created.");
                Menu();
            }
            else
            {
                Dialog("User could not be created successfully, try again.");
                Menu();
            }

            _userService.Add(user);
        }
        private void ViewUsers()
        {
            Console.Clear();
            Console.WriteLine($"ALL USERS \n----------------------------------");

            var users = _userService.GetAll();
            foreach (var user in users)
            {
                Console.WriteLine($"{"ID:",-25}{user.Id}");
                Console.WriteLine($"{"Name:",-25}{user.FirstName} {user.LastName}");
                Console.WriteLine($"{"Email:",-25}{user.Email}");
                Console.WriteLine($"{"Street Address:",-25}{user.StreetAddress}");
                Console.WriteLine($"{"City and Zipcode:",-25}{user.City} {user.ZipCode}");
                Console.WriteLine($"{"Phone Number:",-25}{user.PhoneNumber}");
                Console.WriteLine("----------------------------------");
            }

            Console.ReadKey();
            Menu();
        }
        private void QuitConsole()
        {
            Console.Clear();
            Console.Write("Are you sure you want to exit this application? (yes/no): ");
            var option = Console.ReadLine()!;

            if (option.Equals("yes", StringComparison.CurrentCultureIgnoreCase))
            {
                Environment.Exit(0);
            }
            else if (option.Equals("no", StringComparison.CurrentCultureIgnoreCase))
            {
                Menu();
            }
            else
            {
                InvalidOptions();
                QuitConsole();
            }
        }
        private void InvalidOptions()
        {
            Console.WriteLine("You Must enter a valid option");
            Console.ReadKey();
            
        }
        private void Dialog(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Console.ReadKey();
        }












    }

}
