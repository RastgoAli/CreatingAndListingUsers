using CreatingAndListingUsers.Factories;
using CreatingAndListingUsers.Models;
using InfraStructure.Services;
using System.ComponentModel;
using System.Diagnostics;

namespace CreatingAndListingUsers.Services
{
    public class UserService
    {
        public List<UserEntity> _users = [];
        private readonly FileService _fileService = new();

        public void Add(UserEntity user)
        {
            _users.Add(user);
        }

        public bool Create(UserRegistrationForm form)
        {
            try
            {
                UserEntity userEntity = UserFactory.Create(form);

                _users.Add(userEntity);
                _fileService.SaveListToFile(_users);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
        public IEnumerable<UserEntity> GetAll()
        {
            _users = _fileService.GetAllUsers();
            return _users;
        }

    }
}
