using UnityEngine;
using System.Collections;
namespace Score
{
    public class Statics
    {
        // should be clear
        public static int Score = 0;
        public static int HighScore = 0;

        public static byte baseMulti; //dived by 10
        public static diffLevels diff = diffLevels.Easy;

        public static int chain = 0; // to be implemented
        public static bool Bonus;

        public static bool bonusActivated; //wanted it to actived from the manager

        public enum diffLevels
        {
            Easy,
            Normal,
            Hard
        }

        public static void SetDifficulty()
        {
            switch (diff)
            {
                case diffLevels.Easy:
                    baseMulti = 10;
                    break;
                case diffLevels.Normal:
                    baseMulti = 12;
                    break;
                case diffLevels.Hard:
                    baseMulti = 15;
                    break;
            }
        }

        public static void AddScore(int amount)
        {
            Debug.Log("\n[ScoreStatics] Before adding is " + Score);
            if (!Bonus)
                Score += Mathf.FloorToInt(amount * (baseMulti / 10f));
            else
                Score += Mathf.FloorToInt((amount * (baseMulti / 10f))* 2);

            if (Score > HighScore)
                HighScore = Score;

            Debug.Log("\n[ScoreStatics] New Score is " + Score);
        }

        public static void XpBonus()
        {
            if(!Bonus)
                 bonusActivated = true;
        }
    }
}