﻿using Models;

namespace DataAccess;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{

    private ApplicationDbContext _db;
    public CategoryRepository(ApplicationDbContext db):base(db)
    {
        _db = db;
    } 

    public void Save()
    {
        _db.SaveChanges();
    }

    public void Update(Category obj)
    {
       _db.Category.Update(obj);
    }
}
