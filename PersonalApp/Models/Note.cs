namespace PersonalApp.Models
{
	class Note 
  {
    private string title;
    private string content;
    private int priority;

    public Note(string title, string content, int priority)
    {
      this.title = title;
      this.content = content;
      this.priority = priority;
    }

    public string Title { get => title; set => title = value; }
    public string Content { get => content; set => content = value; }
    public int Priority { get => priority; set => priority = value; }
  }
}
