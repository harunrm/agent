namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.ssp
{
    public class SSPAccountRequest
    {
        public string id { get; set; }
        public string accountId { get; set; }
        public SSPProduct product { get; set; }
        public SSPInstallmentSize size { get; set; }
    }
}