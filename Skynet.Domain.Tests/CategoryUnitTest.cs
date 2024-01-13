using FluentAssertions;
using Skynet.Domain.Entities;

namespace Skynet.Domain.Tests
{
    public class CategoryUnitTest
    {
        [Fact]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");

            action.Should()
                .NotThrow<Skynet.Domain.Validation.DomainValidationException>();
        }

        [Fact]
        public void CreateCategory_WithNegativeIdValue_ResultDomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");

            action.Should()
                .Throw<Skynet.Domain.Validation.DomainValidationException>()
                .WithMessage("Invalid Id value");
        }

        [Fact]
        public void CreateCategory_ShortNameValue_ResultDomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca");

            action.Should()
                .Throw<Skynet.Domain.Validation.DomainValidationException>()
                .WithMessage("Invalid name, too short, minimum 3 characteres");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_ResultDomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");

            action.Should()
                .Throw<Skynet.Domain.Validation.DomainValidationException>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact]
        public void CreateCategory_WithNullNameValue_ResultDomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");

            action.Should()
                .Throw<Skynet.Domain.Validation.DomainValidationException>()
                .WithMessage("Invalid name. Name is required");
        }

    }
}