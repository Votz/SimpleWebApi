namespace SimpleWebApi.Domain.Entities
{
    public class Grade : BaseEntity
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public ICollection<Student> Students { get; set; }

    }
}
