using AutoMapper;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Common.Transforms.CVMapping
{
    public class EntitiesToDALDomain: Profile
    {
        public EntitiesToDALDomain()
        {
            //CreateMap<CV, CVLowInfoDAL_DTO> cycle dependency if adding DAL link
        }
    }
}
