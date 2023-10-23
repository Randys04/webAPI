
using wepAPI;
using wepAPI.Models;

namespace wepAPI.Services
{
    public class CategoryService : ICategoryService
    {
        TasksContext context;

        public CategoryService(TasksContext dbcontext)
        {
            context = dbcontext;
        }

        public IEnumerable<Category> Get()
        {
            return context.Categories;
        }

        public async System.Threading.Tasks.Task Save(Category category) 
        {
            context.Add(category);
            await context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Update(Guid id,Category category)
        {
            var updatedCategory = context.Categories.Find(id);

            if (updatedCategory != null)
            {
                updatedCategory.Name = category.Name;
                updatedCategory.Description = category.Description;
                updatedCategory.Weight = category.Weight;

                await context.SaveChangesAsync();
            }
        }

        public async System.Threading.Tasks.Task Delete(Guid id, Category category)
        {
            var deletedCategory = context.Categories.Find(id);

            if (deletedCategory != null)
            {
                context.Remove(deletedCategory);

                await context.SaveChangesAsync();
            }
        }

    }

    public interface ICategoryService 
    {
        IEnumerable<Category> Get();
        System.Threading.Tasks.Task Save(Category category);
        System.Threading.Tasks.Task Update(Guid id, Category category);
        System.Threading.Tasks.Task Delete(Guid id, Category category);
    }
}
