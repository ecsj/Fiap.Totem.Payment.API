﻿using System.Diagnostics.CodeAnalysis;

namespace Domain.Base;
[ExcludeFromCodeCoverage]

public class DomainException : Exception
{
    public DomainException() {}

    public DomainException(string message) : base(message) { }

    public DomainException(string message, Exception innerException) : base(message, innerException) { }
}
