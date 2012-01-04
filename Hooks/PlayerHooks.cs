using System;
using Toaria;
namespace Hooks
{
	public static class PlayerHooks
	{
		public static event Action<Player> UpdatePhysics;
		public static void OnUpdatePhysics(Player player)
		{
			if (PlayerHooks.UpdatePhysics != null)
			{
				PlayerHooks.UpdatePhysics(player);
			}
		}
	}
}
