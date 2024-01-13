using Skynet.Domain.Validation;

namespace Skynet.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public double Price { get; private set; }
        public int Stoke { get; private set; }
        public string Image { get; private set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(string name, string description, double preco, int stoke, string image)
        {
            ValidationDomain(name, description, preco, stoke, image);
        }

        public Product(int id, string name, string description, double preco, int stoke, string image)
        {
            DomainValidationException.When(id < 0, "Invalid id value");
            Id = id;
            ValidationDomain(name, description, preco, stoke, image);
        }

        public void Update(string name, string description, double preco, int stoke, string image, int categoryId)
        {
            ValidationDomain(name, description, preco, stoke, image);
            CategoryId = categoryId;
        }


        private void ValidationDomain(string name, string description, double price, int stoke, string image) 
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
            DomainValidationException.When(name.Length < 3, "Invalid name, to short, minimum 3 characters");

            DomainValidationException.When(string.IsNullOrEmpty(description), "Invalid description. Description is required");
            DomainValidationException.When(description.Length < 5, "Invalid description, to short, minimum 3 characters");

            DomainValidationException.When(price < 0, "Invalid price value");

            DomainValidationException.When(stoke < 0, "Invalid stoke value");

            DomainValidationException.When(image.Length > 250, "Invalid image name, too long, maximum 250 characters");

            Name = name;
            Description = description; 
            Price = price; 
            Stoke = stoke;
            Image = image;
        }
    }
}
