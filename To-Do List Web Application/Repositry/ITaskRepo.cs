using To_Do_List_Web_Application.Models;

namespace To_Do_List_Web_Application.Repositry
{
    public interface ITaskRepo
    {
        List<Tasks> GetAll();
        Tasks GetById(int id);
        void Insert(Tasks task);
        void Edit(int id, Tasks task);
        void Delete(int id);
        void Save();
    }
}
