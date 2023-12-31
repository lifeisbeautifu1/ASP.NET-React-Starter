using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;


namespace Backend.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UsersController : ControllerBase
	{
		private readonly ApiDbContext _context;
		public UsersController(ApiDbContext context)
		{
			_context = context;
		}

		[HttpGet(Name = "getAllUsers")]
		public async Task<IActionResult> GetUsers()
		{
			var user = new User()
			{
				Name = "John Doe",
				Email = "johndoe@gmail.com"
			};

			_context.Add(user);

			await _context.SaveChangesAsync();

			var allUsers = await _context.Users.ToListAsync();

			return Ok(allUsers);
		}

		[HttpGet("test")]
		public string Test()
		{
			return "test!!!!";
		}

		[HttpGet("hello")]
		public string Hello()
		{
			return "hello!";
		}

		[HttpGet("helloagain")]
		public string HelloAgain()
		{
			return "hello again!";
		}
	}
}
