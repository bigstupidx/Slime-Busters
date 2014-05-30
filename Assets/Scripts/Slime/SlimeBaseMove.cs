using UnityEngine;
using System.Collections;

public class SlimeBaseMove : MonoBehaviour {


    private Animator amiTor;

    void Start()
    {
        amiTor = GetComponent<Animator>();
    }

    public void hit()
    {
        amiTor.SetTrigger("GotHit");
    }
}
