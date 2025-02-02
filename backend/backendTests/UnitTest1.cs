using backend.Models;

namespace backendTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            const string expected = "Name";
            Product sut = new Product();

            // Act
            sut.Name = "Name";
            string actual = sut.Name;
            // Assert

            Assert.Equal(expected, actual);
        }
    }
}