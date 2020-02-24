namespace PandaHR.Api.Services.MatchingAlgorithm.Contracts
{
    public interface IBaseModel<T>
    {
        T Id { get; set; }
    }
}
