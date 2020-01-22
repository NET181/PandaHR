using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Common
{
    public class PandaHRAutoMapper : PandaHR.Api.Common.Contracts.IMapper
    {
        private readonly IMapper _mapper;

        public PandaHRAutoMapper()
        {
            _mapper = AutoMapperConfiguration.Configure();
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _mapper.Map(source, destination);
        }
    }
}
