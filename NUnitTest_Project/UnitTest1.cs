using Ehealthcare.Api.Controllers;
using Ehealthcare.Entities;
using EHealthcare.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using ProjectManagement.Api.Controllers;
using ProjectManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NUnitTest_Project
{
    [TestFixture]
    public class Class1
    {
        Mock<IBaseRepository<Product>> ProductRepo { get; set; }
        
        [SetUp]
        public void Setup()
        {
            ProductRepo = new Mock<IBaseRepository<Product>>();
        }
       
        [Test]
        public void GetAllMedstest()
        {
            var obj = new Product { Name = "Nutriosys Isabgol", CompanyName = "Company1", Price = 525, ImageUrl = "https://m.media-amazon.com/images/I/51inZITDWAL._AC_UL320_.jpg" };
            var p = ObjectExtensionMethods.ToQueryable(obj);
            ProductRepo.Setup(repo => repo.Get())
            .Returns(p);
            MedicineController MedicineRequest = new MedicineController(ProductRepo.Object);
            List<Product> Meds = MedicineRequest.GetAll();
            Console.WriteLine(Meds.Count + " Medicine found");
            Assert.IsTrue(Meds.Count > 0);
        }

      

    }
}