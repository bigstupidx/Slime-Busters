using UnityEngine;
using System.Collections;
namespace Score
{
    public class BonusManager : MonoBehaviour
    {
        float bonusTimer;
        [SerializeField]
        float bonusLength=30f;

        void Start()
        {
            Statics.SetDifficulty();
        }

        void Update()
        {
            if (Statics.bonusActivated)
            {
                Statics.bonusActivated = false;
                Statics.Bonus = true;
                bonusTimer = bonusLength;
            }

            if (Statics.Bonus)
            {
                if (bonusTimer <= 0)
                {
                    Statics.Bonus = false;
                    return;
                }
                bonusTimer -= Time.deltaTime;
            }
        }
    }
}