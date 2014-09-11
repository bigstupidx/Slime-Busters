using UnityEngine;
using System.Collections;
namespace Score
{
    public class Statics
    {

        public static int Score = 0;
        public static int HighScore = 0;

        public static int chain = 0;
        public static bool Bonus;
        public static bool bonusActivated;

        public static void AddScore(int amount)
        {
            if (!Bonus)
                Score += amount;
            else
                Score += amount * 2;

            if (Score > HighScore)
                HighScore = Score;
        }

        public static void xpbonus()
        {
            if(!Bonus)
                 bonusActivated = true;
        }
    }
}