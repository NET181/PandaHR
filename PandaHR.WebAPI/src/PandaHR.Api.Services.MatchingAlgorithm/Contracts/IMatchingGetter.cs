namespace PandaHR.Api.Services.MatchingAlgorithm.Contracts
{
    public interface IMatchingGetter<T>
    {
        int GetMatching(ISkillSetModel<T> skillSet);
    }
}
