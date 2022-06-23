using BookMyShowApi.Models;

namespace BookMyShowApi.Repository
{
    public interface IAppRepository
    {
        //UserModel Register(UserModel user);

        List<UserModel> Get();

        UserModel GetOne(int id);

        void Delete(int id);
        
        
    }
}
