using Models;

namespace DataAccess;

public class ProductRepository : Repository<Product>, IProductRepository
{
 private ApplicationDbContext _db;
    public ProductRepository(ApplicationDbContext db):base(db)
    {
        _db = db;
    }

    public void Update(Product obj)
    {
       _db.Product.Update(obj);
    }
}
