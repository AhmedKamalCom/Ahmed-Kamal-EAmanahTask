using AmanahTask.Models;
using AutoMapper;

namespace AmanahTask.ViewModels
{
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {
            CreateMap<BlogEditViewModel, Blog>(MemberList.None);         
            CreateMap<Blog, BlogEditViewModel>(MemberList.None);
            CreateMap<Blog, BlogViewModel>(MemberList.None);
        }
    }
}
