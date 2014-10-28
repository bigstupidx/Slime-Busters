using UnityEngine;
using System.Collections;

public enum ControlerState{
	RandomSpawning,
	RandomGroupSpawning,
	Boss
}

public class SlimeManager : MonoBehaviour {

    public Sprite initSprite;
    public SlimeList _slimesList;
    public int maxActivesSlimes;

    [SerializeField]
    public int currentActive;

    private int startinlvl;
	private ControlerState controlerState = ControlerState.RandomSpawning;
    private SlimeController[] SlimeControlers;

#region PowerUps
    bool[] PowerupEnabled = new bool[4];//[0]Time,[1]Ice,[2]Soldier,[3]Nuke
    float[] PowerUpTimeLeft = new float[3];//[0]Time,[1]Ice,[2]Soldier
#endregion

    void Start()
    {
        SlimeControlers = GetComponentsInChildren<SlimeController>();
        for (int i = 0; i < 7; i++)
        {
            SlimeControlers[i].ParentScrip = this;
            SlimeControlers[i].name = "["+i+"]SlimeController";
        }
        startinlvl=Application.loadedLevel;
        StartCoroutine("SpawnerLoop");
		StartCoroutine("PowerUpCheckLoop");
		StartCoroutine("StateMachineLoop");
    }

	IEnumerator StateMachineLoop()
	{
		while (Application.isPlaying) {
			//yield return new WaitForSeconds(15.0f);
			int rand = Random.Range(0,20);
			if(rand < 9){
				controlerState = ControlerState.RandomSpawning;
			}else if(rand < 18){
				controlerState = ControlerState.RandomGroupSpawning;
			}else{
				controlerState = ControlerState.Boss;
			}
			Debug.Log("\n[MollControler] switch state: "+controlerState);
            yield return new WaitForSeconds(15f);
		}
		yield return null;
	}

	IEnumerator SpawnerLoop()
    {
        while (Application.isPlaying)
        {
			if(controlerState == ControlerState.RandomSpawning)
			{
	            for (int i = 0; i < 7; i++)
	            {
	                float spawnValue = Random.Range(0, 1f);
	                // Debug.Log(i+" : "+val);
	                
	                if (!SlimeControlers[i].GotSlime && currentActive < maxActivesSlimes && spawnValue < 0.8f)
	                {
	                    //set type of new slime
	                    if (Random.value < 0.4f)
	                        SlimeControlers[i].SetSlimeType((SlimeType)(Mathf.FloorToInt(Random.Range(0, 7))));
	                    else
	                        SlimeControlers[i].SetSlimeType(SlimeType.Normal);
	                    currentActive++;
	                    yield return new WaitForSeconds(0.2f);
	                }
	            }
			}
			else if(controlerState == ControlerState.RandomGroupSpawning)
			{
				float waitTime = removeAllActiveSlimes();
				//Debug.Log("\n[MollControler] waittime: "+waitTime);
				yield return new WaitForSeconds(waitTime);
				int spawnGroup = Random.Range(0, 2);
				// Debug.Log(i+" : "+val);
				
				if (spawnGroup == 0)
				{
					SlimeControlers[0].SetSlimeType(SlimeType.Bomb);
					SlimeControlers[1].SetSlimeType(SlimeType.Pinata);
					SlimeControlers[2].SetSlimeType(SlimeType.Boss);
					SlimeControlers[5].SetSlimeType(SlimeType.Normal);
					currentActive+=4;
					yield return new WaitForSeconds(2f);
				}
				else if(spawnGroup == 1)
				{
                    SlimeControlers[2].SetSlimeType(SlimeType.Bomb);
					SlimeControlers[3].SetSlimeType(SlimeType.Helmet);
                    SlimeControlers[4].SetSlimeType(SlimeType.Bomb);
					SlimeControlers[6].SetSlimeType(SlimeType.Helmet);
					yield return new WaitForSeconds(3f);
					currentActive+=4;
				}
			}
			else if(controlerState == ControlerState.Boss){
				float waitTime = removeAllActiveSlimes();
				yield return new WaitForSeconds(waitTime);

				SlimeControlers[2].SetSlimeType(SlimeType.Boss);
				currentActive+=4;
			}
			yield return new WaitForSeconds(0.2f);
            yield return new WaitForSeconds(1f);
        }

    }

	IEnumerator PowerUpCheckLoop()
    {
        while (Application.isPlaying)
        {
            for(int j = 0;j<PowerUpTimeLeft.Length;j++)
            {
                //Debug.Log(PowerUpTimeLeft[j]);
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
            /*for (int i = 0; i < 7; i++)
            {
                if (Slimes[i].SlimeDead)
                    ActiveApowerUp(Slimes[i].slimeType);
                Slimes[i].SlimeDead = false;
                Slimes[i].Frozen = PowerupEnabled[1];
                Slimes[i].time = PowerupEnabled[0];
            }*/
            yield return new WaitForSeconds(0.05f);
        }
    }

	private float removeAllActiveSlimes()
	{
		float returnNeededTime = 0;
		for (int i = 0; i < 7; i++) {
			SlimeControlers[i].DeSpawnAction();
			if(SlimeControlers[i].waitTime > returnNeededTime){
				returnNeededTime = SlimeControlers[i].waitTime;
			}
		}
		return returnNeededTime;
	}

    void ActiveApowerUp(SlimeType slimeType)
    {
		switch (slimeType)
        {
            case SlimeType.Bomb:
                break;
            case SlimeType.Boss:
                break;
            case SlimeType.Heart:
                break;
            case SlimeType.Helmet:
                break;
            case SlimeType.Ice:
                PowerupEnabled[1] = true;
                PowerUpTimeLeft[1] += 5f;
                break;
            case SlimeType.Pinata:
                break;
            case SlimeType.Time:
                PowerupEnabled[0] = true;
                PowerUpTimeLeft[0] += 0.3f;
                Debug.Log("frozenPickup");
                break;
            case SlimeType.Normal:
                break;
        }
    }
}
