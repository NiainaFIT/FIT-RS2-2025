using Model;
using Model.SearchObjects;

namespace Services
{
    public interface IProductService
    {
        public List<Product> Get(ProductSearchObject? productSearchObject);
        public Product GetById(int id);
    }
}
