using UnityEngine;
using System.Collections;

[System.Serializable]
[RequireComponent(typeof(BoxCollider2D))]
public class SlimeBaseMove : MonoBehaviour {


    private Animator amiTor;
    private GameObject Go;

    public enum SlimeType
    {
        Bomb=0,
        Boss=1,
        Heart=2,
        Helmet=3,
        Ice=4,
        Pinata=5,
        Time=6,
        Normal=7
    }

    [SerializeField]
    private SlimeType Slime;

    [SerializeField]
    private int HP;
    
    void Start()
    {
        
        string toLoad ="Slimes/";
        switch (Slime)
        {
            case SlimeType.Bomb:
                HP = 1;
                toLoad += "Bomb";
                break;
            case SlimeType.Boss:
                HP = 1;
                toLoad += "Boss";
                break;
            case SlimeType.Heart:
                HP = 1;
                toLoad += "Heart";
                break;
            case SlimeType.Helmet:
                HP = 1;
                toLoad += "Helmet";
                break;
            case SlimeType.Ice:
                HP = 1;
                toLoad += "Ice";
                break;
            case SlimeType.Pinata:
                HP = 1;
                toLoad += "Pinata";
                break;
            case SlimeType.Time:
                HP = 1;
                toLoad += "Time";
                break;
            case SlimeType.Normal:
                toLoad+="Normal";
                break;
        }

        
        Go = Instantiate(Resources.Load(toLoad)) as GameObject;
        Go.transform.parent = transform;
        Go.transform.localPosition = Vector3.zero;

        amiTor = Go.GetComponent<Animator>();
        Debug.Log(amiTor);
    }
    
    //activated by hitRayFirere
    public void hit()
    {
        if (HP > 1)
        {
            amiTor.SetTrigger("GotHit");
            
            HP--;
        }
        else
        {
            amiTor.SetTrigger("FinalHit");
            Destroy(amiTor.gameObject, 1f);
            HP--;
            died();
        }
    }

    void died()
    {
        Destroy(Go, 1f);
    }
}
