using System;
using Moq;
using NUnit.Framework;
using TestFormService.Contract;
using TestFormService.Implementation;

namespace TestFormService.Tests
{
    [TestFixture]
    public class ProfileServiceTests
    {
        private ProfileService _underTest;
        private Mock<IProfileRepository> _profileRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _profileRepositoryMock= new Mock<IProfileRepository>();
               _underTest = new ProfileService(_profileRepositoryMock.Object);
        }

        [Test]
        public void Constructor_Test()
        {
            Assert.Throws<ArgumentNullException>(() => new ProfileService(null));
        }

        [Test]
        public void Save_Test()
        {
            var profile = new Profile {FirstName = "TestFirstName", LastName = "Name"};
            _underTest.Save(profile);
            _profileRepositoryMock.Verify(m=>m.Save(It.Is<Profile>(p=>p.FirstName == profile.FirstName && p.LastName == profile.LastName)), Times.Once);
        }
    }
}
