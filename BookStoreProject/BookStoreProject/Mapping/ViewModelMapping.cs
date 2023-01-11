using AutoMapper;
using BookStoreProject.Models;
using BookStoreProject.ViewModels;

namespace BookStoreProject.Mapping
{
    public class ViewModelMapping:Profile
    {
        public ViewModelMapping()
        {
            CreateMap<Book, BookViewModel>().ReverseMap();
        }
    }
}
