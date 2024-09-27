
using Domain.Model.Model.Author.QueryModel;
using Framework.TransientService;

namespace Domain.Model.Model.Author.IRepository;

public interface IAuthorQueryRepository : ITransientService
{
    Task<AuthorQueryModel?> GetById(Guid id);
    Task<Author?> Load(Guid id);
    Task<IEnumerable<AuthorQueryModel>> GetList();
    Task<IEnumerable<AuthorBookQueryModel>> GetAuthorBooksById(Guid id);
    Task<Guid?> GetAuthorId(Guid id);
    Task<bool> HasRecordWithName(Guid id, string name);
}