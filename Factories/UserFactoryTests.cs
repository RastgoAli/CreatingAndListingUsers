
using CreatingAndListingUsers.Factories;
using CreatingAndListingUsers.Models;

namespace Tests.Factories
{
    public class UserFactoryTests
    {
        [Fact]
        public void Create_ShouldReturnUserRegistrationForm()
        {
            //Act
            var result = UserFactory.Create();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<UserRegistrationForm>(result);
        }

        [Fact]
        public void Create_ShouldReturnUserEntity()
        {
            //Arrange
            var userRegistrationForm = new UserRegistrationForm()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "John.doe@domain.se",
                PhoneNumber = "1234567890",
                City = "Stockholm",
                ZipCode = "123456798",
                StreetAddress = "Huvudgatan 123"
            };

            //Act
            var result = UserFactory.Create(userRegistrationForm);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<UserEntity>(result);
            Assert.NotEmpty(result.Id);
            Assert.Equal(userRegistrationForm.FirstName, result.FirstName);
            Assert.Equal(userRegistrationForm.LastName, result.LastName);
            Assert.Equal(userRegistrationForm.Email, result.Email);
            Assert.Equal(userRegistrationForm.PhoneNumber, result.PhoneNumber);
            Assert.Equal(userRegistrationForm.City, result.City);
            Assert.Equal(userRegistrationForm.ZipCode, result.ZipCode);
            Assert.Equal(userRegistrationForm.StreetAddress, result.StreetAddress);
        }

        [Fact]
        public void Create_ShouldReturnUser()
        {
            // Arrange
            var entity = new UserEntity
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "John",
                LastName = "Doe",
                Email = "John.doe@domain.se",
                PhoneNumber = "1234567890",
                City = "Stockholm",
                ZipCode = "123456798",
                StreetAddress = "Huvudgatan 123"
            };

            // Act
            var result = UserFactory.Create(entity);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<User>(result);
            Assert.Equal(entity.Id, result.Id);
            Assert.Equal(entity.FirstName, result.FirstName);
            Assert.Equal(entity.LastName, result.LastName);
            Assert.Equal(entity.Email, result.Email);
            Assert.Equal(entity.PhoneNumber, result.PhoneNumber);
            Assert.Equal(entity.City, result.City);
            Assert.Equal(entity.ZipCode, result.ZipCode);
            Assert.Equal(entity.StreetAddress, result.StreetAddress);
        }
    }
}
