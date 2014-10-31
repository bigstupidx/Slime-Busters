using UnityEngine;
using System.Collections;
namespace gameData
{
    public class ScoreStat
    {
        // should be clear
        public static int Score = 0;
        public static int HighScore = 0;

        public static byte baseMulti; //dived by 10
        public static diffLevels diff;

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
            CustomDebug.Log("[ScoreStatics] Setting difficulty to : " + diff, CustomDebug.Users.System, CustomDebug.Level.Trace);
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
            CustomDebug.Log("[ScoreStatics] Before adding is " + Score, CustomDebug.Users.Jesse, CustomDebug.Level.Trace);
            if (!Bonus)
                Score += Mathf.FloorToInt(amount * (baseMulti / 10f));
            else
                Score += Mathf.FloorToInt((amount * (baseMulti / 10f))* 2);

            if (Score > HighScore)
                HighScore = Score;

            CustomDebug.Log("[ScoreStatics] New Score is " + Score, CustomDebug.Users.Jesse, CustomDebug.Level.Trace);
        }

        public static void XpBonus()
        {
            if(!Bonus)
                 bonusActivated = true;
        }

        public static void Save()
        {
            CustomDebug.Log("[ScoreStatics] Saved ScoreInfo", CustomDebug.Users.System, CustomDebug.Level.Info);
            PlayerPrefs.SetInt("HighScore", HighScore);

            PlayerPrefs.Save();
        }

        public static void Load()
        {
            CustomDebug.Log("[ScoreStatics] Loaded ScoreInfo", CustomDebug.Users.System, CustomDebug.Level.Info);
            HighScore = PlayerPrefs.GetInt("HighScore");
        }
    }
}