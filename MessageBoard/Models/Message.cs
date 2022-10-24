using System; 
using System.ComponentModel.DataAnnotations;

namespace MessageBoard.Models
{
  public class Message
  {
    public int MessageId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }
    public string Author { get; set; }
    public int GroupId { get; set; }
		public virtual Group Group {get; set;}
	}
}