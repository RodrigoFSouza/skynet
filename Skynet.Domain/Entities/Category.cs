using Skynet.Domain.Validation;

namespace Skynet.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }
        public ICollection<Product> Products { get; set; }

        public Category(string name)
        {
            this.ValidationDomain(name);
            Name = name;
        }

        public Category(int id, string name)
        {
            DomainValidationException.When(id < 0, "Invalid Id value");
            ValidationDomain(name);
            Id = id;
            Name = name;
        }

        public void Update(string name)
        {
            ValidationDomain(name); 
            Name = name;
        }

        private void ValidationDomain(string name)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");

            DomainValidationException.When(name.Length < 3 , "Invalid name, too short, minimum 3 characteres");
        }
    }
}
