﻿using Domain.Model.Model.Author.QueryModel;
using Framework.Response;
using MediatR;

namespace Domain.Model.Model.Author.Query;

public class GetAuthorByIdQuery(Guid id) : IRequest<ServiceResponse<AuthorQueryModel?>>
{
    public Guid Id { get; set; } = id;
}