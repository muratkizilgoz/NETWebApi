using FiltersSample.Models;

namespace FiltersSample.Func
{
    public class Logger
    {
        public static void LogWrite(BaseFilters filter)
        {
            using (var context = new ApplicationDbContext())
            {
                if (filter is ExceptionModel ex)
                    context.ExceptionModels.Add(ex);
                else if (filter is ActionModel action) context.ActionModels.Add(action);

                context.SaveChanges();
            }
        }
    }
}