using System;
using Microsoft.Unity.VisualStudio.Editor;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Represebts the current vital statistics of some game entity.
    /// </summary>
    public class Health : MonoBehaviour

        /// to allow the player to have multiple tries when playing a level, we can introduce a health bar. in this case, hearts on the top left corner
        /// let's allow for 5 hearts, each heart can have 2 hp points, which will total for 10 hp.
        /// when the player encounters a slime, it will lose 2 hp; 1 heart will be lost.
    {
        /// <summary>
        /// The maximum hit points for the entity.
        /// </summary>
        public int maxHearts = 5;

        /// <summary>
        /// Indicates if the entity should be considered 'alive'.
        /// </summary>
        public bool IsAlive => currentHearts > 0;

        int currentHearts;

        ///add the hearts
        /// choice of blender image file for the hearts
        public Image[] hearts;
       
        /// <summary>
        /// Event triggered when health reaches zero (player dies).
        /// </summary>
        public event Action OnDeath;

        void Awake()
        {
            // Initialize the player's hearts to the max number of hearts
            currentHearts = maxHearts;

            // Update heart visuals initially
            //UpdateHeartUI();
        }

        /// <summary>
        /// Increment the player's health by one heart (if possible).
        /// </summary>
        public void Increment()
        {
            if (currentHearts < maxHearts)
            {
                currentHearts++;
                //UpdateHeartUI();
            }
        }

        /// <summary>
        /// Decrease the player's health by one heart (if possible).
        /// </summary>
        public void Decrement()
        {
            if (currentHearts > 0)
            {
                currentHearts--;
                //UpdateHeartUI();

                if (currentHearts == 0)
                {
                    // Trigger death event when health reaches zero
                    OnDeath?.Invoke();
                }
            }
        }

        /// <summary>
        /// Apply damage to the player, decreasing hearts.
        /// </summary>
        public void TakeDamage(int damage)
        {
            for (int i = 0; i < damage; i++)
            {
                // Decrement a heart for each damage unit
                Decrement();
            }
        }

        /// <summary>
        /// Update the UI to reflect the current health status.
        /// Commented out since missing files
        /// </summary>
        //private void UpdateHeartUI()
        //{
        //    for (int i = 0; i < hearts.Length; i++)
        //    {
        //        // Full heart for alive, empty for dead, or half heart depending on the player's health
        //        if (i < currentHearts)
        //        {
        //            hearts[i].enabled = true; // Show heart
        //        }
        //        else
        //        {
        //            hearts[i].enabled = false; // Hide heart
        //        }
        //    }
        //}
    }
}
