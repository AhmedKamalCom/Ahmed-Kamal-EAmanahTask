using AutoMapper;
using AmanahTask.Models;
using AmanahTask.Repositories;
using AmanahTask.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmanahTask.Services
{
    public  class GenericService<TModel, TEditViewModel, TViewModel> : IBaseService<TEditViewModel, TViewModel> where TModel : BaseModel
    {
        protected IUnitOfWork _unitOfWork;
        protected IRepository<TModel> _repository;
        public GenericService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
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
        //public void GenerateCode(TEditViewModel model)
        //{
        //    var code = "";
        //    if (IsCodeExist(model.ID, model.Code))
        //        throw new Exception($"Please Choose anther Code ");
        //    if (string.IsNullOrEmpty(model.Code))
        //    {

        //        var i = 0;
        //        do
        //        {
        //            i += 1;
        //            code = (_repository.GetAll().Where(x => !x.IsDeleted).Count() + i).ToString();
        //        } while (IsCodeExist(model.ID, code));
        //    }

        //    model.Code = code;

        //}
        //public bool IsCodeExist(long id, string Code)
        //{
        //    var code = _repository.GetAll().Any(x => !x.IsDeleted && x.ID != id && x.Code == Code);
        //    return code;


        //}
    }
}
