using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBoard.Models;
using System.Linq;

namespace MessageBoard.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GroupsController : ControllerBase
	{
		private readonly MessageBoardContext _db;

		public GroupsController(MessageBoardContext db)
		{
			_db = db;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Group>>> GetGroups()
		{
			
			return await _db.Groups.Include(g => g.Messages).ToListAsync();
		}

		[HttpPost]
		public async Task<ActionResult<Group>> Post(Group group)
		{
			_db.Groups.Add(group);
			await _db.SaveChangesAsync();
			return CreatedAtAction("Post", new {id = group.GroupId}, group);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<IEnumerable<Message>>> GetGroupMessages(int id)
		{
      Group group = await _db.Groups.FindAsync(id);
			if (group == null)
			{
				return NotFound();
			}
      // return await group.Messages.ToListAsync();
			return await _db.Messages.Where(e => e.GroupId == id).ToListAsync();
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, Group group)
		{
			if (id != group.GroupId)
			{
				return BadRequest();
			}

			_db.Entry(group).State = EntityState.Modified;

			try
			{
				await _db.SaveChangesAsync();
			}
			catch(DbUpdateConcurrencyException)
			{
				if (!GroupExists(id))
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

		private bool GroupExists(int id)
		{
			return _db.Groups.Any(m => m.GroupId == id);
		}
	}
}