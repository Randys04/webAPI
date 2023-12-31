﻿using wepAPI;
using wepAPI.Models;
using Task = wepAPI.Models.Task;

namespace wepAPI.Services
{
    public class TaskService : ITaskService
    {
        TasksContext context;

        public TaskService(TasksContext dbcontext)
        {
            context = dbcontext;
        }

        public IEnumerable<Task> Get()
        {
            return context.Tasks;
        }

        public async System.Threading.Tasks.Task Save(Task task)
        {
            task.CreationDate = DateTime.Now;
            context.Add(task);
            await context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Update(Guid id, Task task)
        {
            var updatedTask = context.Tasks.Find(id);

            if (updatedTask != null)
            {
                updatedTask.Title = task.Title;
                updatedTask.Description = task.Description;
                updatedTask.TaskPriority = task.TaskPriority;
                updatedTask.CategoryId = task.CategoryId;

                await context.SaveChangesAsync();
            }
        }

        public async System.Threading.Tasks.Task Delete(Guid id) 
        {
            var deletedTask = context.Tasks.Find(id);

            if (deletedTask != null)
            {
                context.Remove(deletedTask);
                await context.SaveChangesAsync();
            }
        }
    }

    public interface ITaskService
    {
        IEnumerable<Task> Get();
        System.Threading.Tasks.Task Save(Task task);
        System.Threading.Tasks.Task Update(Guid id, Task task);
        System.Threading.Tasks.Task Delete(Guid id);
    }
}
