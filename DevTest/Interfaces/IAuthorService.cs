using System;
using DevTest.Models;
using DevTest.Models.Response;
using RestSharp;

namespace DevTest.Interfaces
{
	public interface IAuthorService
    {
        Task<List<AuthorListResponse>> GetAll();

        Task<AuthorListResponse> GetById(string id);

        Task<AuthorListResponse> Update(AuthorListResponse author);

        Task<AuthorListResponse> Create(AuthorCreate author);
    }
}

