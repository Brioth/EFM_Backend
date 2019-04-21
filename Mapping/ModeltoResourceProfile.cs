using AutoMapper;
using EFM_Backend.API.Domain.Models;
using EFM_Backend.API.Extensions;
using EFM_Backend.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Backend.API.Mapping
{
    public class ModeltoResourceProfile : Profile
    {
        public ModeltoResourceProfile()
        {
            CreateMap<Employee, EmployeeResource>();

            CreateMap<Assignment, AssignmentResource>();
            CreateMap<Assignment_Variable, AssignmentResource_Variable>();
            CreateMap<Assignment_Fixed, AssignmentResource_Fixed>()
                .ForMember(src => src.Occurence,
                            opt => opt.MapFrom(src => src.Occurence.ToDescriptionString()));

            CreateMap<EmployeeAssignment, EmployeeAssignmentResource>();
            CreateMap<EmployeeAssignment_Variable, EmployeeAssignmentResource_Variable>();
            CreateMap<EmployeeAssignment_Fixed, EmployeeAssignmentResource_Fixed>()
                .ForMember(src => src.Occurence,
                            opt => opt.MapFrom(src => src.Occurence.ToDescriptionString()));
        }
    }
}
