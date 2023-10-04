using Microsoft.EntityFrameworkCore;
using To_Do_List_Web_Application.Models;

namespace To_Do_List_Web_Application.Repositry
{
    public class TaskRepo:ITaskRepo
    {
        SysContext sys;
        public TaskRepo(SysContext _sys)
        {
            sys = _sys;
            
        }
        public List<Tasks> GetAll()
        {
            return sys.Tasks.ToList();
        }
        public Tasks GetById(int id)
        {
            return sys.Tasks.FirstOrDefault(d => d.Id == id);
        }
        public void Insert(Tasks task)
        {
            sys.Tasks.Add(task);
        }
        public void Edit(int id, Tasks task)
        {
            sys.Entry(task).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Tasks task = GetById(id);

            sys.Tasks.Remove(task);//hard delet
        }
        public void Save()
        {
            sys.SaveChanges();
        }
    }
}
