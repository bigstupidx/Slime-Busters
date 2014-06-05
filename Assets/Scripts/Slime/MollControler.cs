using UnityEngine;
using System.Collections;

public class MollControler : MonoBehaviour {

    [SerializeField]
    private SlimeBaseMove[] Slimes;

    public int maxActivesSlimes;
    [SerializeField]
    public int currentActive;

    private int startinlvl;

    #region PowerUps
    bool[] PowerupEnabled = new bool[4];//[0]Time,[1]Ice,[2]Soldier,[3]Nuke

    float[] PowerUpTimeLeft = new float[3];//[0]Time,[1]Ice,[2]Soldier


    #endregion
    void Start()
    {
        Slimes = GetComponentsInChildren<SlimeBaseMove>();
        for (int i = 0; i < 7; i++)
        {
            Slimes[i].ParentScrip = this;
        }
        startinlvl=Application.loadedLevel;
        StartCoroutine("Spawner");
        StartCoroutine("PowerUpCheck");
    }
    
    IEnumerator Spawner()
    {
        while (Application.isPlaying)
        {
            for (int i = 0; i < 7; i++)
            {
                float val = Random.Range(0, 10f);
                // Debug.Log(i+" : "+val);
                
                if (!Slimes[i].GotSlime && currentActive < maxActivesSlimes && val < 0.8f)
                {
                    if (Random.value < 0.1f)
                        Slimes[i].Slime = (SlimeBaseMove.SlimeType)(Mathf.FloorToInt(Random.Range(0, 8)));
                    else
                        Slimes[i].Slime = SlimeBaseMove.SlimeType.Ice;
                    Slimes[i].GetSlime();
                    currentActive++;
                    yield return new WaitForSeconds(0.2f);
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator PowerUpCheck()
    {
        while (Application.isPlaying)
        {
            for(int j = 0;j<PowerUpTimeLeft.Length;j++)
            {
                Debug.Log(PowerUpTimeLeft[j]);
                if (PowerUpTimeLeft[j] > 0f)
                {
                    PowerUpTimeLeft[j] -= 0.05f;
                }
                else
                {
                    PowerupEnabled[j] = false;
                    PowerUpTimeLeft[j] = 0f;
                }
            }
            for (int i = 0; i < 7; i++)
            {
                if (Slimes[i].SlimeDead)
                    ActiveApowerUp(Slimes[i].Slime);
                Slimes[i].SlimeDead = false;
                Slimes[i].Frozen = PowerupEnabled[1];
                Slimes[i].time = PowerupEnabled[0];
            }
            yield return new WaitForSeconds(0.05f);
        }
    }

    void ActiveApowerUp(SlimeBaseMove.SlimeType Slime)
    {
        switch (Slime)
        {
            case SlimeBaseMove.SlimeType.Bomb:
                break;
            case SlimeBaseMove.SlimeType.Boss:
                break;
            case SlimeBaseMove.SlimeType.Heart:
                break;
            case SlimeBaseMove.SlimeType.Helmet:
                break;
            case SlimeBaseMove.SlimeType.Ice:
                PowerupEnabled[1] = true;
                PowerUpTimeLeft[1] += 5f;
                break;
            case SlimeBaseMove.SlimeType.Pinata:
                break;
            case SlimeBaseMove.SlimeType.Time:
                PowerupEnabled[0] = true;
                PowerUpTimeLeft[0] += 0.3f;
                Debug.Log("frozenPickup");
                break;
            case SlimeBaseMove.SlimeType.Normal:
                break;
        }
    }
}
