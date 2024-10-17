using Moq;
using Newtonsoft.Json;
using Resources.Interface;
using Resources.Models;
using Resources.Response;
using Resources.Services;


namespace Resources.Tests
{
    public class ProductServiceTests
    {
        private readonly Mock<IFileService> _fileServiceMock;
        private readonly Mock<IProductService> _productServiceMock;
        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _fileServiceMock = new Mock<IFileService>();
            _productService = new ProductService(_fileServiceMock.Object);
            _productServiceMock = new Mock<IProductService>();

        }

        [Fact]
        public void AddAProduct__ShouldAdd_AProductAnd__ReturnTrue()
        {
            // arrange
            var product = new Product { ProductName = "Tomat", price = 20 };
            _fileServiceMock.Setup(s => s.SaveToFile(It.IsAny<string>())).Returns(ResultResponse.Succeeded);

            // Act
            ResultResponse result = _productService.AddToList(product);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Success);
        }


        [Fact]
        public void AddAProductWhithAnEmptyName__ShouldAdd_AProductAnd__ReturnFalse()
        {
            // arrange
            var product = new Product { ProductName = "", price = 20, };
            _fileServiceMock.Setup(s => s.SaveToFile(It.IsAny<string>())).Returns(ResultResponse.Succeeded());

            // Act
            ResultResponse result = _productService.AddToList(product);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.Success);
        }

        [Fact]
        public void GetAllProducts__Should_GetAllProductAnd___ReturnNotNull()
        {

            // arrange
            var product = new Product { ProductName = "Tomat", price = 20, };

            var products = new List<Product> { product };
         
            var json = JsonConvert.SerializeObject(products);
            _fileServiceMock.Setup(s => s.GetFromFile()).Returns(json);

            // Act
            var result = _productService.GetAllProductService();

            // Assert

            Assert.NotNull(result);
            Assert.Contains(result, s => s.ProductName == "Tomat");
        }

        [Fact]
        public void REmoveAProduct__Should_RemoveAProductAnd___ReturnTrue()
        {

            // arrange
            var product = new Product { Id = "1", ProductName = "Tomat", price = 20, };

            var products = new List<Product> { product };
    
            var json = JsonConvert.SerializeObject(products);
            _fileServiceMock.Setup(s => s.GetFromFile()).Returns(json);

            // Act
            var result = _productService.DeleteProduct("1");

            // Assert

            Assert.True(result.Success);



        }

        // This mock file service is a solution provided by ChatGPT.
        // It is used to test product updates and file operations without affecting real files.
        // I am not using Mock in other cases because it wasn't working correctly during testing.


        public class MockFileService : IFileService
        {
            private string _fileContent = string.Empty; 

            public string GetFromFile()
            {
                
                return _fileContent;
            }

            public ResultResponse SaveToFile(string content)
            {
                
                _fileContent = content;
                return ResultResponse.Succeeded();
            }
        }

        [Fact]
        public void UpdateAProductWithoutMock__Should_UpdateAProductAnd___ReturnTrue()
        {
            // arrange
            var productService = new ProductService(new MockFileService());
            var currentProduct = new Product { Id = "1", ProductName = "Tomat", price = 20 };
            productService.AddToList(currentProduct);

            var updatedProduct = new Product { Id = "1", ProductName = "RedBull", price = 50 };

            // Act
            var result = productService.Update(updatedProduct);

            // Assert
            Assert.True(result.Success);

           
            var updatedProducts = productService.GetAllProductService();
            var updatedProductInList = updatedProducts.FirstOrDefault(p => p.Id == "1");
            Assert.NotNull(updatedProductInList);
            Assert.Equal("RedBull", updatedProductInList.ProductName);
            Assert.Equal(50, updatedProductInList.price);
        }
    }
}