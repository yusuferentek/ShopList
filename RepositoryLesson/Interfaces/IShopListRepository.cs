using RepositoryLesson.Models;

namespace RepositoryLesson.Interfaces
{
    public interface IShopListRepository : IGenericRepository<Lists>
    {
        Lists AddList(Lists list,int userId);

    }
}
