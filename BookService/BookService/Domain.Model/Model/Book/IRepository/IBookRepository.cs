
using Domain.Model.Model.Book.QueryModel;
using Framework.TransientService;

namespace Domain.Model.Model.Book.IRepository;

public interface IBookQueryRepository : ITransientService
{
    Task<BookQueryModel?> GetById(Guid id, CancellationToken cancellationToken);
    Task<Book?> Load(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<BookQueryModel>> GetList(CancellationToken cancellationToken);
}