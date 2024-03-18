namespace DataAccess;

public interface IUnitOfWork
{
    ICategoryRepository Category { get; }

    void Save();
}
