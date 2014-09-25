using UnityEngine;
using System.Collections;

public class HammerControler
{
	private float scale;
    private Transform creator;
    private GameObject hammer;
    private Animator animator;
    private RuntimeAnimatorController controler;
    public HammerControler(Transform _creator,RuntimeAnimatorController _controler,float _scale)
    {
        creator = _creator;
        controler = _controler;
		scale = _scale;
    }

    public void SetControler(RuntimeAnimatorController _controler)
    {
        controler = _controler;
    }
    
    public void Tick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hammer = new GameObject("hammer");
            hammer.AddComponent<SpriteRenderer>().sortingLayerName = "hammerEffects";
            animator = hammer.AddComponent<Animator>();
            animator.runtimeAnimatorController = controler;
            animator.SetTrigger("hit");
            Vector3 inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			hammer.transform.localScale = new Vector3(scale,scale,scale);
            hammer.transform.position = new Vector3(inputPos.x,inputPos.y,hammer.transform.position.z);
        }
    }
}
