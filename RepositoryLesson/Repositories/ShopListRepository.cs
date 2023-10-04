using RepositoryLesson.Interfaces;
using RepositoryLesson.Models;
using System.Security.Claims;

namespace RepositoryLesson.Repositories
{
    public class ShopListRepository : GenericRepository<Lists> , IShopListRepository
    {


        public ShopListRepository(ShoppingDbContext context) : base(context) { }

        public Lists AddList(Lists list,int userId)
        {

            Lists nList = new Lists();
            nList.ListStatus = 0;
            nList.ListName = list.ListName;
            nList.UserId = userId;
            return nList;
        }
    }
}
