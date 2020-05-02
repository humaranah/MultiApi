using System;

namespace MultiApi.Domain.Models
{
    public interface IIdentificable
    {
        Guid Id { get; }
    }
}
