namespace ChatAPI.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = "";
        public string Text { get; set; } = "";
    }
}