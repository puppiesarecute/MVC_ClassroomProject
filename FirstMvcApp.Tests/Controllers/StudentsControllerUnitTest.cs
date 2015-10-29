using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FirstMvcApp;
using FirstMvcApp.Repositories;
using FirstMvcApp.Controllers;
using FirstMvcApp.Models;
using FirstMvcApp.MyInterface;

namespace FirstMvcApp.Tests.Controllers
{
    /// <summary>
    /// Summary description for StudentsControllerUnitTest
    /// </summary>
    [TestClass]
    public class StudentsControllerUnitTest
    {
        //[TestMethod]
        //public void TestMethodEmail()
        //{
        //    Mock<IStudentsRepository> mockRepo = new Mock<IStudentsRepository>();
        //    Mock<IEmailer> fakeEmailer = new Mock<IEmailer>();
        //    StudentsController controller = new StudentsController(mockRepo.Object, fakeEmailer.Object);

        //    // Act - call the method to test
        //    Student s = new Student { FirstName = "Daniel", LastName = "Something" };
        //    controller.Create(s, null);

        //    fakeEmailer.Verify(a => a.Send("Welcome to our website..."));
        //}

        //[TestMethod]
        //public void TestStudentController()
        //{
        //    // Arrange
        //    Mock<IStudentsRepository> mockRepo = new Mock<IStudentsRepository>();
        //    //Mock<FakeEmailer> mockEmailer = new Mock<FakeEmailer>();
        //    StudentsController controller = new StudentsController(mockRepo.Object, null);

        //    // Act - call the method to test
        //    Student s = new Student { FirstName = "Daniel", LastName = "Something" };
        //    controller.Create(s, null);

        //    // Assert
        //    mockRepo.Verify(a => a.InsertOrUpdate(s));
        //}
    }
}
