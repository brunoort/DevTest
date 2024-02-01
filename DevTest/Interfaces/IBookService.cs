using System;
using DevTest.Models;
using DevTest.Models.Response;
using RestSharp;

namespace DevTest.Interfaces
{
	public interface IBookService
    {
        Task<List<BookListResponse>> GetAll();

        Task<BookListResponse> GetById(string id);

        Task<BookListResponse> Update(BookListResponse author);

        Task<BookListResponse> Create(BookCreate author);
    }
}

