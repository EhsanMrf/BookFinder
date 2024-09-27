using Domain.Model.Model.Author.IRepository;

namespace Persistence.EF.Repository.Author;

public class AuthorCommandRepository(DatabaseContext databaseContext) : IAuthorCommandRepository
{
    public async Task<bool> Create(Domain.Model.Model.Author.Author command)
    {
        databaseContext.Authors.Add(command);
        return await databaseContext.SaveChangesAsync() > 0;
    }

    public async Task<Domain.Model.Model.Author.Author> Update(Domain.Model.Model.Author.Author command)
    {
        databaseContext.Authors.Update(command);
         await databaseContext.SaveChangesAsync();
         return command;
    }
}