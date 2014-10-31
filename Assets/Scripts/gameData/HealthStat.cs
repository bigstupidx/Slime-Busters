using UnityEngine;
using System.Collections;

namespace gameData
{
    public class HealthStat
    {
        public static int health = 0;
        public static int maxHealth = 3;

        public static bool dead = false;

        public static void takeDamage(int dmg)
        {
            if (dmg < 0)
            {
                CustomDebug.Log("[HealtStatic] don't try negative damage. Use addHealth instead", CustomDebug.Users.System,CustomDebug.Level.Warn);
                return;
            }

            if (health > dmg)
                health -= dmg;
            else
                dead = true;
        }

        public static void addHealth(int heal)
        {
            if (heal < 0)
            {
                CustomDebug.Log("[HealtStatic] don't use negative healing. Use takeDamage instead", CustomDebug.Users.System, CustomDebug.Level.Warn);
                return;
            }

            if (health + heal > maxHealth)
                health = maxHealth;
            else if (health + heal < maxHealth)
                health += heal;
        }
    }
}