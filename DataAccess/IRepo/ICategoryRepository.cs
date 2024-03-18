using Models;

namespace DataAccess;

public interface ICategoryRepository : IRepository<Category>
{
       void Update(Category obj);
       void Save();
}
