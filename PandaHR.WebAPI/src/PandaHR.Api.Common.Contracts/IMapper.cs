using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Common.Contracts
{
    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}
