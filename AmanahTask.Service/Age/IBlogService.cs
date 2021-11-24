using AmanahTask.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmanahTask.Services
{
    public interface IBlogService : IBaseService<BlogEditViewModel, BlogViewModel>
    {
        PagingViewModel Get(string name = "", string orderBy = "ID", bool isAscending = false, int pageIndex = 1, int pageSize = 20);
    }
}
