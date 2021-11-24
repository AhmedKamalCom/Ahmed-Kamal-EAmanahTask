
using AmanahTask.Models;
using AmanahTask.Repositories;
using AmanahTask.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AmanahTask.Services
{
    public class BlogService : GenericService<Blog,BlogEditViewModel,BlogViewModel>,  IBlogService
    {

        public BlogService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public PagingViewModel Get(string name = "", string orderBy = "ID", bool isAscending = false, int pageIndex = 1, int pageSize = 20)
        {
            var list = _repository.GetAll();
            if (!string.IsNullOrEmpty(name))
                list = list.Where(x => x.Title.Contains(name) );
            int records = list.Count();
            if (records <= pageSize || pageIndex <= 0) pageIndex = 1;
            int pages = (int)Math.Ceiling((double)records / pageSize);
            int excludedRows = (pageIndex - 1) * pageSize;
            IEnumerable<BlogViewModel> result = new List<BlogViewModel>();
            var items = list.OrderByPropertyName(orderBy, isAscending).Skip(excludedRows).Take(pageSize);
            result = items.ToList().Select(x=>Mapper.Map<BlogViewModel>(x)).ToList();
            return new PagingViewModel() { PageIndex = pageIndex, PageSize = pageSize, Result = result, Records = records, Pages = pages };
        }
    }
}
