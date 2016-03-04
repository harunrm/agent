using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.dto
{
    public class ApplicationStatusChangeDto
    {
        public long applicationId { get; set; }
        public CommentDto commentDto { get; set; }
    }
}
