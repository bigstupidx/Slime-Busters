using UnityEngine;
using System.Collections;

[System.Serializable]
[RequireComponent(typeof(CircleCollider2D))]
public class SlimeMoveBase : MonoBehaviour
{
    public enum LayerOrder
    {
        Front = 0,
        middle = 1,
        back = 2
    }

#region Normal vars

    private Animator amiTor;

    public MollControler ParentScrip;

    [SerializeField]
    private bool _GotSlime = false;
    public bool SlimeDead = false;

    private Vector3 OffSet;

    [SerializeField]
    private LayerOrder layer;
    private SlimeType privateSlimeType;
    [SerializeField]
    private SlimeInfo slimeInfo;

    //[SerializeField]
    //private int HP;

    private float privateWaitTime = 0f; //used so animations dont cross paths
    private float molePopupTime; // when zero the slime dies

    public bool GotSlime
    {
        get
        {
            return _GotSlime;
        }
    }
    public SlimeType slimeType
    {
        get
        {
            return privateSlimeType;
        }
    }
	public float waitTime
	{
		get{
			return privateWaitTime;
		}
	}

#endregion

#region Powerup var's

    public bool Frozen;
    public bool time;

#endregion

    public void SetSlimeType(SlimeType type)
    {
        string loadDir = "Slimes/";
        string loadPath;
        //int numbOfFrames = 1; // frames in death animation;

        slimeInfo = SlimeSettings.GetSlimeInfo(type);
        molePopupTime = slimeInfo.molePopupTime;
        loadPath = loadDir + slimeInfo.LoadName;
        _GotSlime = true;
        SlimeDead = false;

        privateWaitTime = (1f / GameSettings.animationFPS * slimeInfo.frameCount);

        GameObject newSlime = Instantiate(Resources.Load(loadPath)) as GameObject;
        newSlime.name = "Slime";
        newSlime.transform.parent = transform;
        newSlime.transform.localPosition = OffSet;

        SpriteRenderer spr = newSlime.GetComponent<SpriteRenderer>();
        switch (layer){
            case LayerOrder.Front:
                spr.sortingOrder = 4;
                break;
            case LayerOrder.middle:
                spr.sortingOrder = 2;
                break;
            case LayerOrder.back:
                spr.sortingOrder = 0;
                break;
        }
        
        amiTor = newSlime.GetComponent<Animator>();

    }

    //activated by hitRayFirere
    public void hit()
    {
        if (_GotSlime && amiTor != null)
        {
            if (slimeInfo.hP > 1)
            {
                Handheld.Vibrate();
                amiTor.SetTrigger("GotHit");
				Debug.Log("GotHit");
                slimeInfo.hP --;
            }
            else
            {
                Handheld.Vibrate();
                killAction();
				Debug.Log("FinalHit");
                amiTor.SetTrigger("FinalHit");
                SlimeDead = true;
                //addScore;
            }
            if (particleSystem != null)
            {
                particleSystem.Emit(20);
            }
        }
    }

    void Update()
    {
        if (SlimeDead&&_GotSlime)
        {
            if (privateWaitTime < 0)
            {
                SlimeDead = true;
                _GotSlime = false;
            }
            else
            {
                privateWaitTime -= Time.deltaTime;
            }
        }
        else if (!SlimeDead && _GotSlime&&!Frozen)
        {
            if (!time&&molePopupTime <= 0)
            {
				DeSpawnAction();
                time = true;
            }
            else
            {
                molePopupTime -= Time.deltaTime;
            }
        }
    }

    void killAction()
    {
        if (amiTor != null)
        {
            amiTor.SetTrigger("FinalHit");
            Destroy(amiTor.gameObject, privateWaitTime);
        }
        SlimeDead = true;
        slimeInfo.hP = 0;
        ParentScrip.currentActive--;
    }

	public void DeSpawnAction()
	{
		if (amiTor != null)
		{
			amiTor.SetTrigger("DeSpawn");
			Destroy(amiTor.gameObject, privateWaitTime);
		}
		SlimeDead = true;
		slimeInfo.hP = 0;
		ParentScrip.currentActive--;
	}
}
