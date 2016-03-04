using MISL.Ababil.Agent.Infrastructure.Models.domain.models.nominee;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.termaccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.dto
{
    public class TermAccountRequestDto
    {
        public TermAccountInformation termAccountInformation;
        public List<NomineeInformationTemp> nominees;
        public CommentDto commentDto;
    }
}