
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
        // Retrieves objects By filter 
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
       
        // Retrieves all objects 
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

        // Retrieves a specific object by id
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

        // Retrieves a specific object To Edit by id
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

        // add new object
        [HttpPost]
        [Route("Post")]
        public ResultViewModel Post([FromBody] BlogEditViewModel viewModel)
        {
            try
            {
                _resultViewModel = _resultViewModel.Create(true, "Successfully Created", _service.Add(viewModel));
            }
            catch (Exception ex)
            {
               _resultViewModel =  _resultViewModel.Create(false, ex.Message);
            }
            return _resultViewModel;
        }

        // Edit object
        [HttpPut]
        [Route("Put")]
        public ResultViewModel Put([FromBody] BlogEditViewModel viewModel)
        {
            try
            {
                _resultViewModel = _resultViewModel.Create(true, "Successfully Updated" , _service.Edit(viewModel));
            }
            catch (Exception ex)
            {
               _resultViewModel =  _resultViewModel.Create(false, ex.Message);
            }
            return _resultViewModel;
        }

        // Delete object
        [HttpDelete]
        [Route("Delete/{id}")]
        public ResultViewModel Delete(long id)
        {
            try
            {
                _service.Remove(id);
                _resultViewModel.Message = "Successfully Deleted";
            }
            catch (Exception ex)
            {
               _resultViewModel =  _resultViewModel.Create(false, ex.Message);
            }
            return _resultViewModel;
        }
    }
}
