using Store_01.Models;

namespace Store_01.Reader
{
	public class TeamMemberReader : ITeamMemberReader
	{
		private readonly StoreContext store;
		public TeamMemberReader(StoreContext store)
		{
			this.store = store;	
		}

		public List<TeamMember> GetteamMembers()
		{
			return store.TeamMembers.Select(m => m).ToList();
		}
	}
}
