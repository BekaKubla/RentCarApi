namespace RentCarApi.Models
{
    public class MainEntity
    {
        public int Id { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreateDate { get; private set; }

        public void Delete()
        {
            IsDeleted = true;
        }
        public void Active()
        {
            IsDeleted = false;
        }
    }
}
