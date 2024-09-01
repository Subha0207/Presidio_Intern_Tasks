namespace TodoApp.Models
{
    public class TodoDTO
    {
        public int TodoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime TargetDate { get; set; }
        public bool Status { get; set; } = false;
        public int UserId { get; set; }
        public string UserName { get; set; }

    }
}
