﻿using Messaging.Shared.Abstractions;

namespace Messaging.Shared.Pagination;

public interface IPagedQuery<T> : IQuery<T>
{
    int Page { get; set; }
    int Results { get; set; }
}