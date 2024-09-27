using Domain.Model.Model.Author;
using Domain.Model.Model.Author.Command;
using Domain.Model.Model.Author.Query;
using Domain.Model.Model.Author.QueryModel;
using Framework.Response;
using Framework.TransientService;
using MediatR;

namespace Application.Contract;

public interface IAuthorService :
    IRequestHandler<AddAuthorCommand,bool>,
    IRequestHandler<UpdateAuthorCommand, ServiceResponse<Author>>,
    IRequestHandler<GetAuthorByIdQuery, ServiceResponse<AuthorQueryModel?>>,
    IRequestHandler<GetAuthorsQuery, ServiceResponse<IEnumerable<AuthorQueryModel>>>,
    IRequestHandler<GetAuthorBooksByAuthorId, ServiceResponse<IEnumerable<AuthorBookQueryModel>>>,
    ITransientService;