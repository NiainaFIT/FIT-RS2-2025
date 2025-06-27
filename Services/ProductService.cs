using Model;
using Model.SearchObjects;

namespace Services
{
    public class ProductService : IProductService
    {
        public List<Product> products = new List<Product>();

        public ProductService()
        {
            products.AddRange(new List<Product>
{
                    new Product { Id = 1, Name = "Laptop", Code = "PRD001", Description = "High-performance laptop" },
                    new Product { Id = 2, Name = "Smartphone", Code = "PRD002", Description = "Latest model smartphone" },
                    new Product { Id = 3, Name = "Keyboard", Code = "PRD003", Description = "Mechanical keyboard" },
                    new Product { Id = 4, Name = "Mouse", Code = "PRD004", Description = "Wireless mouse" },
                    new Product { Id = 5, Name = "Monitor", Code = "PRD005", Description = "4K Ultra HD monitor" }
                });
        }
        public List<Product> Get(ProductSearchObject? search)
        {
           

            var queriable = products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Code))
            {
                queriable = queriable.Where(x => x.Code == search.Code);
            }

            if (!string.IsNullOrWhiteSpace(search?.CodeGTE))
            {
                queriable = queriable.Where(x => x.Code.StartsWith(search.CodeGTE));
            }
            if (!string.IsNullOrWhiteSpace(search?.FTS))
            {
                queriable = queriable
                    .Where(x => x.Code.Contains(search.FTS, StringComparison.CurrentCultureIgnoreCase) || (x.Name != null && x.Name.Contains(search.FTS, StringComparison.CurrentCultureIgnoreCase)));
            }

            return queriable.ToList();
        }

        public Product GetById(int id) => products.FirstOrDefault(x => x.Id == id);
    }
}
