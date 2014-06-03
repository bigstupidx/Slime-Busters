using UnityEngine;
using System.Collections;

public class MollControler : MonoBehaviour {

    [SerializeField]
    private SlimeBaseMove[] Slimes;

    public int maxActivesSlimes;
    [SerializeField]
    public int currentActive;

    private int startinlvl;

    void Start()
    {
        Slimes = GetComponentsInChildren<SlimeBaseMove>();
        for (int i = 0; i < 7; i++)
        {
            Slimes[i].ParentScrip = this;
        }
        startinlvl=Application.loadedLevel;
        StartCoroutine("loader");
    }
    
    IEnumerator loader()
    {
        while (startinlvl == Application.loadedLevel)
        {
            for (int i = 0; i < 7; i++)
            {
                float val = Random.Range(0, 10f);
                // Debug.Log(i+" : "+val);
                if (!Slimes[i].GotSlime && currentActive < maxActivesSlimes && val < 0.8f)
                {
                    Slimes[i].Slime = (SlimeBaseMove.SlimeType)(Mathf.FloorToInt(Random.Range(0, 8)));
                    Slimes[i].GetSlime();
                    currentActive++;
                    yield return new WaitForSeconds(0.2f);
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
