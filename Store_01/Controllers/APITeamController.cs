using Microsoft.AspNetCore.Mvc;
using Store_01.Reader;

namespace Store_01.Controllers
{
	public class APITeamController : ControllerBase
	{
		private readonly ITeamMemberReader memberReader;
		public APITeamController(ITeamMemberReader memberReader )
		{
			this.memberReader = memberReader;
		}
		[HttpGet]
		public IActionResult GetTeamMember()
		{
			return Ok(memberReader.GetteamMembers());
		}
		
	}
}
