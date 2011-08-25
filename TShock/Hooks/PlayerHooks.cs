using System;
using Toaria;

namespace TerrariaAPI.Hooks
{
    public static class PlayerHooks
    {
        /// <summary>
        /// Called right before controls are handled
        /// </summary>
        public static event Action<Player> UpdatePhysics;

        public static void OnUpdatePhysics(Player player)
        {
            if (UpdatePhysics != null)
                UpdatePhysics(player);
        }
    }
}