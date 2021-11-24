using AutoMapper;
using AmanahTask.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmanahTask.ViewModels
{
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {
            CreateMap<BlogEditViewModel, Blog>(MemberList.None);         
            CreateMap<Blog, BlogViewModel>().AfterMap(
                            (src, dest, c) => {                               
                            }
             );
        }
    }
}
