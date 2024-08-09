﻿using MediatR;
using Said_Store.Application.DTOs;
using Said_Store.Shared;
using Said_Store.Shared.Abstractions.Application.Queries;

namespace Said_Store.Application.Queries.OrderItemQueries
{
    public record GetAllOrdersQuery() : IQuery<List<OrderDto>>;
}
