using UnityEngine;
using System.Collections;

namespace gameData
{
    public class CoinsStat
    {
        public static int coins = 0;

        const int ScoreToCoints = 5;

        public static void AddNewCoins(int value)
        {
            coins += Mathf.FloorToInt(value / 5);
        }
    }
}
