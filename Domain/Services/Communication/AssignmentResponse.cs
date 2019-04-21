using EFM_Backend.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Backend.API.Domain.Services.Communication
{
    public class AssignmentResponse : BaseResponse
    {
        public Assignment Assignment { get; set; }

        private AssignmentResponse(bool success, string message, Assignment assignment) : base(success, message)
        {
            Assignment = assignment;
        }

        public AssignmentResponse(Assignment assignment) : this(true, string.Empty, assignment) { }

        public AssignmentResponse(string message) : this(false, message, null) { }


    }
}
