
using AmanahTask.Services;
using AmanahTask.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AmanahTask.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BlogController : BaseController
    {
        private ResultViewModel _resultViewModel;
        private readonly IBlogService _service;
        public BlogController(IBlogService service)
        {
            _service = service;
            _resultViewModel = new ResultViewModel();

        }
        /// <summary>
        /// Retrieves objects By filter 
        /// </summary>
        [HttpGet]
        [Route("Get")]
        public ResultViewModel Get(string name = "", string orderBy = "ID", bool isAscending = false, int pageIndex = 1, int pageSize = 20)
        {
            try
            {
                _resultViewModel.Data = _service.Get(name, orderBy, isAscending, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
               _resultViewModel =  _resultViewModel.Create(false, ex.Message);
            }
            return _resultViewModel;

        }
        /// <summary>
        /// Retrieves all objects 
        /// </summary>
        [HttpGet]
        [Route("GetList")]
        public ResultViewModel GetList()
        {

            try
            {
                _resultViewModel.Data = _service.GetList();
            }
            catch (Exception ex)
            {
               _resultViewModel =  _resultViewModel.Create(false, ex.Message);
            }
            return _resultViewModel;
        }
        /// <summary>
        /// Retrieves a specific object by id
        /// </summary>

        [HttpGet]
        [Route("GetByID/{id}")]
        public ResultViewModel GetByID(long id)
        {
            try
            {
                _resultViewModel.Data = _service.GetByID(id);
            }
            catch (Exception ex)
            {
               _resultViewModel =  _resultViewModel.Create(false, ex.Message);
            }
            return _resultViewModel;
        }
        /// <summary>
        /// Retrieves a specific object To Edit by id
        /// </summary>

        [HttpGet]
        [Route("GetEditableByID/{id}")]
        public ResultViewModel GetEditableByID(long id)
        {

            try
            {
                _resultViewModel.Data = _service.GetEditableByID(id);
            }
            catch (Exception ex)
            {
               _resultViewModel =  _resultViewModel.Create(false, ex.Message);
            }
            return _resultViewModel;
        }

        /// <summary>
        /// add new object
        /// </summary>
        [HttpPost]
        [Route("Post")]
        public ResultViewModel Post([FromBody] BlogEditViewModel viewModel)
        {
            try
            {
                _resultViewModel = _resultViewModel.Create(true, /*SharedResource.SuccessfullyCreated*/ "SuccessfullyCreated", _service.Add(viewModel));
            }
            catch (Exception ex)
            {
               _resultViewModel =  _resultViewModel.Create(false, ex.Message);
            }
            return _resultViewModel;
        }

        [HttpPut]
        [Route("Put")]
        public ResultViewModel Put([FromBody] BlogEditViewModel viewModel)
        {
            try
            {
                _resultViewModel = _resultViewModel.Create(true, "SuccessfullyUpdated" /*SharedResource.SuccessfullyUpdated*/, _service.Edit(viewModel));
            }
            catch (Exception ex)
            {
               _resultViewModel =  _resultViewModel.Create(false, ex.Message);
            }
            return _resultViewModel;
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public ResultViewModel Delete(long id)
        {

            try
            {
                _service.Remove(id);
                _resultViewModel.Message = "SuccessfullyDeleted" /*SharedResource.SuccessfullyDeleted*/;
            }
            catch (Exception ex)
            {
               _resultViewModel =  _resultViewModel.Create(false, ex.Message);
            }
            return _resultViewModel;
        }
    }
}
