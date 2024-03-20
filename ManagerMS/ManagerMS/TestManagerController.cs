using ManagerMicroservice.Controllers;
using ManagerMicroservice.Model;
using ManagerMicroService.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FakeItEasy;
using Microsoft.Extensions.Logging;

namespace TestManagerModule.Tests
{
    [TestFixture]
    class TestManagerController
    {
        Mock<IManagerRepository> mock = new Mock<IManagerRepository>();
        ManagerController controller;
        [OneTimeSetUp]
        public void SetUp()
        {
            mock = new Mock<IManagerRepository>();
        }
        private static IEnumerable<List<Customer>> GetAllCustomers_TestCase
        {
            get
            {
                yield return new List<Customer> {
                new Customer{ ContactNo = "9908765434", Name = "Demo1", EmailId = "Sd@g.com"} ,
                new Customer{ContactNo = "9908765434", Name = "Demo2", EmailId = "Sd@g.com" }
            };
            }
             
        }

        [Test]
        [TestCase]
        public void GetExectuives()
        {
            mock.Setup(x => x.GetAllExecutive());
            var fakeLogger = A.Fake<ILogger<ManagerController>>();
            controller = new ManagerController(mock.Object, fakeLogger);
            var result = controller.GetAllExecutive() as ObjectResult;
            Console.WriteLine(result.StatusCode);
            Assert.AreEqual(result.StatusCode, 200);  
        }

        

        [Test]
        [TestCase("Pooja", "9876345646", "nopqrs", "nopqrs@gmail.com")]
        public void CreateExecutive_ValidInput(string name, string contactno, string locality, string emailid)
        {
            Executive executive = new Executive
            {
                Name = name,
                ContactNo = contactno,
                Locality = locality,
                EmailId = emailid, 

            };

            mock.Setup(x => x.CreateExecutive(executive));

            controller = new ManagerController(mock.Object,null);

            var result = controller.AddExecutive(executive) as Task<ActionResult>; 
            Assert.IsNotNull(result,null);
        }

        [Test]
        [TestCase("1", "2")]
        public void AssignExecutive_ValidInput(int executiveid,int customerid)
        {
            CustomerExecutiveModel customerExecutiveModel = new CustomerExecutiveModel
            {
                 CustomerId= customerid,
                 ExecutiveId=executiveid
            };

            mock.Setup(x => x.AssignExecutive(customerExecutiveModel));

            controller = new ManagerController(mock.Object,null);

            var result = controller.AssignExecutive(customerExecutiveModel) as Task<IActionResult>; 
            Assert.IsNotNull(result, null);
        }

    }
}

