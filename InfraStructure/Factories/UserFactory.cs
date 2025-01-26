using CreatingAndListingUsers.Models;

namespace CreatingAndListingUsers.Factories
{
    public static class UserFactory
    {
        public static UserRegistrationForm Create()
        {
            return new UserRegistrationForm();
        }

        public static UserEntity Create(UserRegistrationForm form)
        {
            return new UserEntity()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = form.FirstName,
                LastName = form.LastName,
                Email = form.Email,
                PhoneNumber = form.PhoneNumber,
                City = form.City,
                ZipCode = form.ZipCode,
                StreetAddress = form.StreetAddress,

            };
        }

        public static User Create(UserEntity entity)
        {
            return new User()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                City = entity.City,
                ZipCode = entity.ZipCode,
                StreetAddress = entity.StreetAddress,
            };
        }
    }





}
