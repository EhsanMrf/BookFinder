using Application.Contract;
using Application.Exception;
using Domain.Model.Model.Author;
using Domain.Model.Model.Author.Command;
using Domain.Model.Model.Author.IRepository;
using Domain.Model.Model.Author.Query;
using Domain.Model.Model.Author.QueryModel;
using Framework.Extensions;
using Framework.Response;

namespace Application;

public class AuthorService(IAuthorQueryRepository queryRepository, IAuthorCommandRepository commandRepository) : IAuthorService
{
    public async Task<bool> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
    {
        await GuardAssessmentOnDuplicateRecord(Guid.Empty, request.Name);
        return await commandRepository.Create(new Author(request.Name));
    }

    public async Task<ServiceResponse<Author>> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await queryRepository.Load(request.Id);
        author.ThrowIfNull(new AuthorFoundServiceException());
        await GuardAssessmentOnDuplicateRecord(author!.Id, request.Name);
        author!.Update(request.Name);
        await commandRepository.Update(author);
        return new ServiceResponse<Author>(author);
    }

    public async Task<ServiceResponse<AuthorQueryModel?>> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        var author = await queryRepository.GetById(request.Id);
        return author.ReturnDataOrInstance();
    }

    public async Task<ServiceResponse<IEnumerable<AuthorQueryModel>>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
    {
        var authors = await queryRepository.GetList();
        return authors.ReturnDataOrInstance();
    }

    public async Task<ServiceResponse<IEnumerable<AuthorBookQueryModel>>> Handle(GetAuthorBooksByAuthorId request, CancellationToken cancellationToken)
    {
        var authors = await queryRepository.GetAuthorBooksById(request.Id);
        return authors.ReturnDataOrInstance();
    }

    private async Task GuardAssessmentOnDuplicateRecord(Guid id,string name)
    {
        var hasRecordWithName = await queryRepository.HasRecordWithName(id, name);
        if (hasRecordWithName)
            throw new AuthorServiceException();
        
    }
}