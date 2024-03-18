using Models;

namespace DataAccess;

public interface IProductRepository : IRepository<Product>
{
    void Update(Product obj);
}
