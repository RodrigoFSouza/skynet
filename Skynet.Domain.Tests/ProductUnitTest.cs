using FluentAssertions;
using Skynet.Domain.Entities;

namespace Skynet.Domain.Tests
{
    public class ProductUnitTest
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99, 10, "Product image");

            action.Should()
                .NotThrow<Skynet.Domain.Validation.DomainValidationException>();
        }

        [Fact]
        public void CreateProduct_WithNegativeIdValue_ResultDomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99, 10, "Product image");

            action.Should()
                .Throw<Skynet.Domain.Validation.DomainValidationException>()
                .WithMessage("Invalid Id value");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_ResultDomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99, 10, "Product image");

            action.Should()
                .Throw<Skynet.Domain.Validation.DomainValidationException>()
                .WithMessage("Invalid name, to short, minimum 3 characters");
        }

        [Fact]
        public void CreateProduct_LargeNameValue_ResultDomainExceptionLargeName()
        {
            Action action = () => new Product(1, "Produto com nome muito grande, Produto com nome muito grande, Produto com nome muito grande, Produto com nome muito grande. Produto com nome muito grande", "Product Description", 9.99, 10, "Product image");

            action.Should()
                .Throw<Skynet.Domain.Validation.DomainValidationException>()
                .WithMessage("Invalid name, to large, maximum 120 characters");
        }

        [Fact]
        public void CreateProduct_NullImageValue_ResultNoDomainException()
        {
            Action action = () => new Product(1, "Produto Name", "Product Description", 9.99, 10, null);

            action.Should()
                .NotThrow<Skynet.Domain.Validation.DomainValidationException>();
        }

        [Fact]
        public void CreateProduct_WithNullName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Produto Name", "Product Description", 9.99, 10, null);

            action.Should()
                .NotThrow<NullReferenceException>();
        }

        [Fact]
        public void CreateProduct_EmptyImageValue_ResultNoDomainException()
        {
            Action action = () => new Product(1, "Produto Name", "Product Description", 9.99, 10, "");

            action.Should()
                .NotThrow<Skynet.Domain.Validation.DomainValidationException>();
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_ResultDomainValidationNegativeValue(int value)
        {
            Action action = () => new Product(1, "Produto Name", "Product Description", 9.99, value, "Product Image");

            action.Should()
                .Throw<Skynet.Domain.Validation.DomainValidationException>()
                .WithMessage("Invalid stoke value");
        }

        [Theory]
        [InlineData(-9.2)]
        public void CreateProduct_InvalidPriceValue_ResultDomainValidationNegativeValue(int value)
        {
            Action action = () => new Product(1, "Produto Name", "Product Description", value, 10, "Product Image");

            action.Should()
                .Throw<Skynet.Domain.Validation.DomainValidationException>()
                .WithMessage("Invalid price value");
        }
    }
}
