﻿namespace Messaging.Shared.Contexts.Accessors;

public interface IContextAccessor
{
    IContext? Context { get; set; }
}