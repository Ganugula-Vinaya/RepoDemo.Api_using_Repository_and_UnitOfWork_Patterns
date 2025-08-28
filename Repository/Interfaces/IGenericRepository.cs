//The Objective of creating a repository is to provide a centralized location for 
//data access logic, promoting separation of concerns and making the application easier to maintain and test.

using System.Linq.Expressions; //for specifying query Filters

namespace RepoDemo.Api.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
        //we are calling this class as IGenericRepository as it is a generic interface for all repositories
    {

        Task<T> GetByIdAsync(int id); // at run time <t> will be replaced with the actual entity type
        //we are using 
        //this method will help us in retrieving all entities
        Task<IEnumerable<T>> GetAllAsync();


        Task AddAsync(T entity);
        //this method will help us in adding a new entity in async manner

        Task UpdateAsync(T entity);
        //this method will help us in updating an existing entity in async manner

        Task DeleteAsync(int id);
        //this method will help us in deleting an existing entity in async manner

        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        //this method will help us in finding entities based on a specific condition
    }
}

//All the methods that are defined in this interface will help us in performing CRUD operations on the entities.//
//Here entities refer to the objects that are being managed by the application, such as products, orders, customers, etc.
//so by defining these