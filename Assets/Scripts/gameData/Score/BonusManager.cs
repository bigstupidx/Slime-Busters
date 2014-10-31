using UnityEngine;
using System.Collections;
namespace gameData
{
    public class BonusManager : MonoBehaviour
    {
        public float bonusTimer;
        public float bonusLength=30f;

        void Start()
        {
            ScoreStat.SetDifficulty();
            ScoreStat.Load();
            ScoreStat.Score = 0;
        }

        void Update()
        {
            if (ScoreStat.bonusActivated)
            {
                ScoreStat.bonusActivated = false;
                ScoreStat.Bonus = true;
                bonusTimer = bonusLength;
            }

            if (ScoreStat.Bonus)
            {
                if (bonusTimer <= 0)
                {
                    ScoreStat.Bonus = false;
                    return;
                }
                bonusTimer -= Time.deltaTime;
                if (bonusTimer < 0f)
                    bonusTimer = 0;
            }
        }

        void OnDestory()
        {
            ScoreStat.Save();
        }
    }
}