namespace LivingAsIntern.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string[] Tags { get; set; }
        public DateTime CreatedAt { get; set; }
        public string textHTML { get; set; }
        public string textMarkDown { get; set; }
    }
}
