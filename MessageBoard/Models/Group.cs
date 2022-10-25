using System;
using System.Collections.Generic;

namespace MessageBoard.Models
{
  public class Group
  {
		public Group()
		{
			this.Messages = new HashSet<Message>();
		}
    public int GroupId { get; set; }
    public string Name { get; set; }
		public ICollection<Message> Messages {get; set;}
  }
}