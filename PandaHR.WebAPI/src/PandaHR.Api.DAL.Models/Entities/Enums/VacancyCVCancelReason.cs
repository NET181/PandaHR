using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PandaHR.Api.DAL.Models.Entities.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum VacancyCVCancelReason
    {
        RejectedByClient,
        RejectedByHR,
        PersonRefused,
        CallLater
    }
}
