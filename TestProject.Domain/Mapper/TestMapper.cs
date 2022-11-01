global using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Domain.Entities;
using TestProject.Domain.ViewModels;

namespace TestProject.Domain.Mapper
{
    public class TestMapper:Profile
    {
        public TestMapper()
        {
            CreateMap<BasicInfo, BasicInfoViewModel>().ReverseMap();

        }
    }
}
