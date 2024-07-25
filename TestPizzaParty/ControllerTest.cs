using PizzaParty.Models;
using PizzaParty.Controllers;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace TestPizzaParty
{
    public class ControllerTest

    {
                private List<PizzaPerson> GetAllPerson()
                {
                    return new List<PizzaPerson>
                {
                    new PizzaPerson { CustomerID = 1, Name = "Pittsburgh Nate"},
                    new PizzaPerson { CustomerID = 2, Name = "Greenbay Jim"}
                };
                }



                [Fact]
                public void Index_ReturnsViewResult_WithListOfPerson()

                { 
                // Arrange
                var mockRepo = new Mock<IPersonRepository>();
                mockRepo.Setup(repo => repo.GetAllPerson())
                    .Returns(GetAllPerson());
                var controller = new PersonController(mockRepo.Object);

                // Act
                var result = controller.Index();

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<IEnumerable<PizzaPerson>>(
                    viewResult.ViewData.Model);
                Assert.Equal(2, model.Count());


                }


           

            
                [Fact]
                public void ViewPerson_ReturnsNotFoundResult_WhenPersonNotFound()
                {
                //Arrange
                var mockRepo = new Mock<IPersonRepository>();
                mockRepo.Setup(repo => repo.GetPerson(1)).Returns((PizzaPerson)null);
                var controller = new PersonController(mockRepo.Object);

                //Act
                var result = controller.ViewPerson(1);

                //Assert
                Assert.IsType<NotFoundResult>(result);

                }
            


           
                [Fact]
                public void ViewPerson_ReturnsViewResult_WithPerson()
                {
                //Arrange
                var mockRepo = new Mock<IPersonRepository>();
                var testPerson = new PizzaPerson { CustomerID = 1, Name = "Pittsburgh Nate" };
                mockRepo.Setup(repo => repo.GetPerson(1))
                    .Returns(testPerson);
                var controller = new PersonController(mockRepo.Object);

                //Act
                var result = controller.ViewPerson(1);

                //Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<PizzaPerson>(viewResult.ViewData.Model);
                Assert.Equal(testPerson, model);

                }

            



    }


}