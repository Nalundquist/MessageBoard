using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBoard.Models;
using System.Linq;
using System;

namespace MessageBoard.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessagesController : ControllerBase
	{
		private readonly MessageBoardContext _db;

		public MessagesController(MessageBoardContext db)
		{
			_db = db;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Message>>> Get()
		{
			return await _db.Messages.ToListAsync();
		}

		[HttpPost]
		public async Task<ActionResult<Message>> Post(Message message)
		{
			// Group group = _db.Groups.FirstOrDefault(g => g.GroupId == message.GroupId);
			// message.Group = group;
			message.Date = DateTime.Now;
			_db.Messages.Add(message);
			await _db.SaveChangesAsync();
			return CreatedAtAction("Post", new {id = message.MessageId}, message);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Message>> GetMessage(int id)
		{
			Message message = await _db.Messages.FindAsync(id);
			if (message == null)
			{
				return NotFound();
			}
			return CreatedAtAction(nameof(GetMessage), new { id = message.MessageId }, message);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, Message message)
		{
			if (id != message.MessageId)
			{
				return BadRequest();
			}

			_db.Entry(message).State = EntityState.Modified;

			try
			{
				await _db.SaveChangesAsync();
			}
			catch(DbUpdateConcurrencyException)
			{
				if(!MessageExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}
			return NoContent();
		}

		private bool MessageExists(int id)
		{
			return _db.Messages.Any(m => m.MessageId == id);
		}
	}
}