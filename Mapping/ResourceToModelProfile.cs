using AutoMapper;
using EFM_Backend.API.Domain.Models;
using EFM_Backend.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Backend.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveEmployeeResource, Employee>();

            CreateMap<SaveEmployeeAssignmentResource, EmployeeAssignment>();
            CreateMap<SaveEmployeeAssignmentResource_Variable, EmployeeAssignment_Variable>();
            CreateMap<SaveEmployeeAssignmentResource_Fixed, EmployeeAssignment_Fixed>()
                .ForMember(src => src.Occurence, opt => opt.MapFrom(src => (Occurence)src.Occurence));

            CreateMap<SaveAssignmentResource, AssignmentResource>();
            CreateMap<SaveAssignmentResource_Variable, Assignment_Variable>();
            CreateMap<SaveAssignmentResource_Fixed, Assignment_Fixed>()
                .ForMember(src => src.Occurence, opt => opt.MapFrom(src => (Occurence)src.Occurence));
        }
    }
}
