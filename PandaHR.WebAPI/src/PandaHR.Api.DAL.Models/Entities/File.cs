namespace PandaHR.Api.DAL.Models.Entities
{
    public class File : BaseEntity, ISoftDeletable
    {
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}