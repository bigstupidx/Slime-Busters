using UnityEngine;
using System.Collections;

namespace Health
{
    public class Statics
    {
        public static int health = 0;
        public static int maxHealth = 3;

        public static bool dead = false;

        public static void takeDamage(int dmg)
        {
            if (dmg < 0)
            {
                Debug.LogError("don't try negative damage. Use addHealth instead");
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
                Debug.LogWarning("don't use negative healing. Use takeDamage instead");
                return;
            }

            if (health + heal > maxHealth)
                health = maxHealth;
            else if (health + heal < maxHealth)
                health += heal;
        }
    }
}