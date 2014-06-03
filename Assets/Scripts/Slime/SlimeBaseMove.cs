using UnityEngine;
using System.Collections;

[System.Serializable]
[RequireComponent(typeof(CircleCollider2D))]
public class SlimeBaseMove : MonoBehaviour
{
#region vars
    private Animator amiTor;
    public MollControler ParentScrip;
    [SerializeField]
    private bool _GotSlime = false;
    private bool SlimeDead = true;
    public bool GotSlime
    {
        get
        {
            return _GotSlime;
        }
    }

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

    public SlimeType Slime;

    [SerializeField]
    private int HP;

    private float WaitTime = 0f; //used so animations dont cross paths
    private float ToSlow; // when zero the slime dies
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
                numbOfFrames = 9;
                break;
            case SlimeType.Boss:
                HP = 1;
                toLoad += "Boss";
                numbOfFrames = 9;
                break;
            case SlimeType.Heart:
                HP = 1;
                toLoad += "Heart";
                numbOfFrames = 9;
                break;
            case SlimeType.Helmet:
                HP = 3;
                toLoad += "Helmet";
                numbOfFrames = 9;
                ToSlow = 4f;
                break;
            case SlimeType.Ice:
                HP = 1;
                toLoad += "Ice";
                numbOfFrames = 9;
                break;
            case SlimeType.Pinata:
                HP = 1;
                toLoad += "Pinata";
                numbOfFrames = 9;
                break;
            case SlimeType.Time:
                HP = 1;
                toLoad += "Time";
                numbOfFrames = 9;
                break;
            case SlimeType.Normal:
                HP = 1;
                toLoad += "Normal";
                numbOfFrames = 9;
                break;

            default:
                 HP = 1;
                toLoad += "Normal";
                numbOfFrames = 9;
                break;
        }
        _GotSlime = true;
        SlimeDead = false;

        WaitTime = (1f / 23 * numbOfFrames);

        GameObject Go = Instantiate(Resources.Load(toLoad)) as GameObject;
        Go.transform.parent = transform;
        Go.transform.localPosition = Vector3.zero;

        amiTor = Go.GetComponent<Animator>();
        Debug.Log(amiTor);
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
                //addScore;
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
                Debug.Log("deadSlime");
            }
            else
            {
                WaitTime -= Time.deltaTime;
            }
        }
        else if (!SlimeDead && _GotSlime)
        {
            if (ToSlow <= 0)
            {
                killAction();
            }
            else
            {
                ToSlow -= Time.deltaTime;
            }
        }
    }

    void killAction()
    {
        Destroy(amiTor.gameObject, 1f);
        amiTor.SetTrigger("FinalHit");
        Destroy(amiTor.gameObject, 1f);
        SlimeDead = true;
        HP = 0;
        ParentScrip.currentActive--;
    }
}
