using To_Do_List_Web_Application.Models;

namespace To_Do_List_Web_Application.Repositry
{
    public interface IAccountRepository
    {
        Users Find(string userName, string password);

    }
}
