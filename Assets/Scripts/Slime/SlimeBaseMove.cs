using UnityEngine;
using System.Collections;

public class SlimeBaseMove : MonoBehaviour {


    private Animator amiTor;

    void Start()
    {
        amiTor = GetComponent<Animator>();
    }
    
    //activated by hitRayFirere
    public void hit()
    {
        amiTor.SetTrigger("GotHit");
    }
}
