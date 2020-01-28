namespace PandaHR.Api.DAL.Models
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
    }
}
