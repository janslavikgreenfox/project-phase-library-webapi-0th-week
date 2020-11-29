using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBS2;
using LBS2.DTOs.Responses;
using LBS2.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;
using Moq;
using LBS2.Services.Interfaces;
using LBS2.Databases;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiControllerTest
{
    public class ApiControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public ApiControllerTest(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task  BookAll()
        {
            //Arrange

            //Act
            var response = await factory.CreateClient().GetAsync("/book/all");
            var data = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<BookResponse>>(data);
            ;
            //Assert
        }

        [Fact]
        public void BookAllMoq()
        {
            //Arrange
            var mockBooks = new List<Book>
            {
                new Book(){Title="Alpha"},
                new Book(){Title="Bravo"},
                new Book(){Title="Charlie"}
            };
            var moqIBook = new Mock<IBook>();
            moqIBook.Setup(p => p.ReadAll()).Returns(mockBooks);

            var moqIAccount = new Mock<IAccount>();
            var moqIAuthorizationLevel = new Mock<IAuthorizationLevel>();
            var moqIBookCategories = new Mock<IBookCategories>();
            var moqIBorrowing = new Mock<IBorrowing>();
            var moqICategory = new Mock<ICategory>();
            var moqIMapper = new Mock<IMapper>();

            var apiController = new APIController(
                moqIAccount.Object,            // IAccount accountService,
                moqIAuthorizationLevel.Object, // IAuthorizationLevel authorizationLevelService,
                moqIBook.Object,               // IBook bookService,
                moqIBookCategories.Object,     // IBookCategories bookCategoryService,
                moqIBorrowing.Object,          // IBorrowing borrowingService,
                moqICategory.Object,           // ICategory categoryService,
                moqIMapper.Object);            // IMapper mapper)

            var result = apiController.AllBooksGet();
            ;
        }
    }
}
