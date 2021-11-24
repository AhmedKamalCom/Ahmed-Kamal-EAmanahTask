using AmanahTask.ViewModels;

namespace AmanahTask.Services
{
    public interface IBlogService : IGenericService<BlogEditViewModel, BlogViewModel>
    {
        PagingViewModel Get(string name = "", string orderBy = "ID", bool isAscending = false, int pageIndex = 1, int pageSize = 20);
    }
}
