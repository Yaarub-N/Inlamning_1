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
        private readonly ProductService _productService; // Testa ProductService direkt

        public ProductServiceTests()
        {
            _fileServiceMock = new Mock<IFileService>();
            _productServiceMock = new Mock<IProductService>();
            _productService = new ProductService(_fileServiceMock.Object); // Instansiera ProductService med mockad IFileService
        }

        [Fact]
        public void AddAProduct__ShouldAdd_AProductAnd__ReturnTrue()
        {
            // Arrange
            var product = new Product { ProductName = "Tomat", price = 20 };
            _fileServiceMock.Setup(s => s.SaveToFile(It.IsAny<string>())).Returns(ResultResponse.Succeeded());

            // Act
            ResultResponse result = _productService.AddToList(product);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Success);
        }


        [Fact]
        public void AddAProductWhithAnEmptyName__ShouldAdd_AProductAnd__ReturnFalse()
        {
            // Arrange
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
            
            // Arrange
            var product = new Product { ProductName = "Tomat", price = 20, };
         
            var products = new List<Product> { product };
            // Act
            var json = JsonConvert.SerializeObject(products);
            _fileServiceMock.Setup(s => s.GetFromFile()).Returns(json);

            // Act
            var result= _productService.GetAllProductService();

            // Assert
            
            Assert.NotNull(result);
            Assert.Contains(result, s => s.ProductName == "Tomat");
        }

        [Fact]
        public void REmoveAProduct__Should_RemoveAProductAnd___ReturnTrue()
        {

            // Arrange
            var product = new Product {Id="1", ProductName = "Tomat", price = 20, };

            var products = new List<Product> { product };
            // Act
            var json = JsonConvert.SerializeObject(products);
            _fileServiceMock.Setup(s => s.GetFromFile()).Returns(json);

            // Act
            var result = _productService.DeleteProduct("1");

            // Assert

            Assert.True(result.Success);

            
            
        }
        [Fact]

        public void UpdateAProduct__Should_UpdateAProductAnd___ReturnTrue()
        {
          
            // Arrange
            var currentProduct = new Product { Id = "1", ProductName = "Tomat", price = 20, };
            var product=new Product { Id="1", ProductName= "RedBull" , price = 30, };
            var currentproducts = new List<Product> { currentProduct };
            var products = new List<Product> { product };


            // Act
            var json = JsonConvert.SerializeObject(currentProduct);

            _fileServiceMock.Setup(s => s.GetFromFile()).Returns(json);

           

            // Act
            var result = _productService.Update(product);
            

            // Assert

            Assert.True(result.Success);
            Assert.Equal("RedBull", currentProduct.ProductName);



        }


    }
}
