using System.Collections.Generic;

namespace AmanahTask.Services
{
    public interface IGenericService<TEditViewModel, TViewModel> 
    {
        IEnumerable<TViewModel> GetList();
        TViewModel GetByID(long id);
        TEditViewModel GetEditableByID(long id);
        TEditViewModel Add(TEditViewModel model);
        TEditViewModel Edit(TEditViewModel model);
        void Remove(long id);
    }
}
