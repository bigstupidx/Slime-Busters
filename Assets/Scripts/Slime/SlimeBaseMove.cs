using UnityEngine;
using System.Collections;

[System.Serializable]
[RequireComponent(typeof(BoxCollider2D))]
public class SlimeBaseMove : MonoBehaviour {


    private Animator amiTor;

    public enum SlimeType
    {
        Bomb=0,
        Boss=1,
        Heart=2,
        Helmet=3,
        Ice=4,
        Pinata=5,
        Time=6
    }

    [SerializeField]
    private SlimeType Slime;

    [SerializeField]
    private int HP;
    
    void Start()
    {
        amiTor = GetComponent<Animator>();
        switch (Slime)
        {
            case SlimeType.Bomb:
                HP = 1;
                break;
            case SlimeType.Boss:
                HP = 1;
                break;
            case SlimeType.Heart:
                HP = 1;
                break;
            case SlimeType.Helmet:
                HP = 1;
                break;
            case SlimeType.Ice:
                HP = 1;
                break;
            case SlimeType.Pinata:
                HP = 1;
                break;
            case SlimeType.Time:
                HP = 1;
                break;
        }
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
            HP--;
        }
        if (HP <= 0)
        {
            died();
        }
    }

    void died()
    {
        //something happens when it dies;
    }
}
