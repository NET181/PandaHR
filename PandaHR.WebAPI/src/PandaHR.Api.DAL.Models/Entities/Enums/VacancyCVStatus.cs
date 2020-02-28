using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PandaHR.Api.DAL.Models.Entities.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum VacancyCVStatus
    {
        NotExists,
        Draft,
        CVPreparation,
        CVReadyForClient,
        CVSentToClient,
        CVConfirmedWithClient,
        Hired,
        Cancelled
    }
}
