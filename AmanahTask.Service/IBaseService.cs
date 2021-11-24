using AmanahTask.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmanahTask.Services
{
    public interface IBaseService<TEditViewModel, TViewModel> 
    {
        IEnumerable<TViewModel> GetList();
        TViewModel GetByID(long id);
        TEditViewModel GetEditableByID(long id);
        TEditViewModel Add(TEditViewModel model);
        TEditViewModel Edit(TEditViewModel model);
        void Remove(long id);
    }
}
