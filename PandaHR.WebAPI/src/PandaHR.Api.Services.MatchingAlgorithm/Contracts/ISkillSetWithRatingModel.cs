namespace PandaHR.Api.Services.MatchingAlgorithm.Contracts
{
    public interface ISkillSetWithRatingModel<T> : ISkillSetModel<T>
    {
        public int Rating { get; set; }
    }
}
