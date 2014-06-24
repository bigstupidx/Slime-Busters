using UnityEngine;
using System.Collections;

[System.Serializable]
[RequireComponent(typeof(CircleCollider2D))]
public class SlimeBaseMove : MonoBehaviour
{
#region Normal vars
    private Animator amiTor;
    public MollControler ParentScrip;
    [SerializeField]
    private bool _GotSlime = false;
    public bool SlimeDead = false;
    public bool GotSlime
    {
        get
        {
            return _GotSlime;
        }
    }

    private Vector3 OffSet;

    public enum SlimeType
    {
        Bomb = 0,
        Boss = 1,
        Heart = 2,
        Helmet = 3,
        Ice = 4,
        Pinata = 5,
        Time = 6,
        Normal = 7
    }

    public enum Layer
    {
        Front=0,
        middle=1,
        back=2
    }

    [SerializeField]
    private Layer layer;

    public SlimeType Slime;

    [SerializeField]
    private int HP;

    private float WaitTime = 0f; //used so animations dont cross paths
    private float ToSlow; // when zero the slime dies
#endregion
    #region Powerup var's
    public bool Frozen;
    public bool time;
    #endregion
    public void GetSlime()
    {
        string toLoad = "Slimes/";
        int numbOfFrames = 1; // frames in death animation;

        ToSlow = 2f;

        switch (Slime)
        {
            case SlimeType.Bomb:
                HP = 1;
                toLoad += "Bomb";
                numbOfFrames = 24;
                break;
            case SlimeType.Boss:
                HP = 1;
                toLoad += "Boss";
                numbOfFrames = 24;
                break;
            case SlimeType.Heart:
                HP = 1;
                toLoad += "Heart";
                numbOfFrames = 24;
                break;
            case SlimeType.Helmet:
                HP = 3;
                toLoad += "Helmet";
                numbOfFrames = 24;
                ToSlow = 4f;
                break;
            case SlimeType.Ice:
                HP = 1;
                toLoad += "Ice";
                numbOfFrames = 24;
                break;
            case SlimeType.Pinata:
                HP = 1;
                toLoad += "Pinata";
                numbOfFrames = 24;
                break;
            case SlimeType.Time:
                HP = 1;
                toLoad += "Time";
                numbOfFrames = 24;
                break;
            case SlimeType.Normal:
                HP = 1;
                toLoad += "Normal";
                numbOfFrames = 24;
                break;
            default:
                 HP = 1;
                toLoad += "Normal";
                numbOfFrames = 24;
                break;
        }
        _GotSlime = true;
        SlimeDead = false;

        WaitTime = (1f / 23 * numbOfFrames);

        GameObject Go = Instantiate(Resources.Load(toLoad)) as GameObject;
        Go.name = "Slime";
        Go.transform.parent = transform;
        Go.transform.localPosition = Vector3.zero+OffSet;

        SpriteRenderer spr = Go.GetComponent<SpriteRenderer>();
        switch (layer){
            case Layer.Front:
                spr.sortingOrder = 4;
                break;
            case Layer.middle:
                spr.sortingOrder = 2;
                break;
            case Layer.back:
                spr.sortingOrder = 0;
                break;
        }
        
        amiTor = Go.GetComponent<Animator>();

    }

    //activated by hitRayFirere
    public void hit()
    {
        if (_GotSlime && amiTor != null)
        {
            if (HP > 1)
            {
                amiTor.SetTrigger("GotHit");
                HP--;
            }
            else
            {
                killAction();
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
            if (WaitTime < 0)
            {
                SlimeDead = true;
                _GotSlime = false;
            }
            else
            {
                WaitTime -= Time.deltaTime;
            }
        }
        else if (!SlimeDead && _GotSlime&&!Frozen)
        {
            if (!time&&ToSlow <= 0)
            {
                killAction();
                time = true;
            }
            else if (!time&&ToSlow <= -5)
            {
                killAction();
                time = true;
            }
            else
            {
                ToSlow -= Time.deltaTime;
            }
        }
    }

    void killAction()
    {
        if (amiTor != null)
        {
            amiTor.SetTrigger("FinalHit");
            Destroy(amiTor.gameObject, WaitTime);
        }
        SlimeDead = true;
        HP = 0;
        ParentScrip.currentActive--;
    }
}
