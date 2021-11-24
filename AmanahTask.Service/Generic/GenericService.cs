using AmanahTask.Models;
using AmanahTask.Repositories;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace AmanahTask.Services
{
    public  class GenericService<TModel, TEditViewModel, TViewModel> : IGenericService<TEditViewModel, TViewModel> where TModel : BaseModel
    {
        protected IUnitOfWork _unitOfWork;
        protected IRepository<TModel> _repository;
        public GenericService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.Repository<Repository<TModel>>();
        }
        public virtual TEditViewModel Add(TEditViewModel model)
        {
            var obj = Mapper.Map<TModel>(model);
            var attachedObj = _repository.Add(obj);
            _unitOfWork.Commit();
            return Mapper.Map<TEditViewModel>(attachedObj);
        }
        public virtual TEditViewModel Edit(TEditViewModel model)
        {
            var obj = Mapper.Map<TModel>(model);
            var attachedObj = _repository.Edit(obj);
            _unitOfWork.Commit();
            return Mapper.Map<TEditViewModel>(attachedObj);
        }
        public virtual TViewModel GetByID(long id)
        {
            var model = _repository.GetById(id);
            return Mapper.Map<TViewModel>(model);
        }
        public virtual TEditViewModel GetEditableByID(long id)
        {
            var model = _repository.GetById(id);
            return Mapper.Map<TEditViewModel>(model);
        }
        public virtual IEnumerable<TViewModel> GetList()
        {
            return _repository.GetAll().ToList().Select(x => Mapper.Map<TViewModel>(x)).ToList();
        }
        public virtual void Remove(long id)
        {
            _repository.Remove(id);
            _unitOfWork.Commit();
        }
    }
}
