using Tasks.Models;
using Tasks.Repository;

namespace Tasks.Services
{
    public class TaskService
    {

        private readonly TaskRepository _repo;

        public TaskService(TaskRepository repo)
        {
            _repo = repo;
        }

        public List<TaskItem> GetTasks()
        {
            return _repo.GetTasks();
        }

        public void AddTask(TaskItem task)
        {
            _repo.AddTask(task);
        }

        public void UpdateTask(TaskItem task)
        {
            _repo.UpdateTask(task);
        }

        public void DeleteTask(int id)
        {
            _repo.DeleteTask(id);
        }

    }
}
