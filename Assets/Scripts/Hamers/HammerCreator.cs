using UnityEngine;
using System.Collections;

public class HammerCreator
{
	private float scale_;
    private AnimationClip clip_;
    private RuntimeAnimatorController controler_;
    public HammerCreator(RuntimeAnimatorController controler,float scale,AnimationClip clip)
    {
        clip_ = clip;
        controler_ = controler;
		scale_ = scale;
    }

    public void SetHammer(HammerData data)
    {
        clip_ = data.clip;
        controler_ = data.controler;
    }
    
    public void OnHit()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject hammer_ = new GameObject("hammer:");
            hammer_.AddComponent<SpriteRenderer>().sortingLayerName = "hammerEffects";
            hammer_.AddComponent<DeleteAnimationOnReady>();
            hammer_.AddComponent<Animation>().clip = clip_;
            hammer_.AddComponent<Animator>().runtimeAnimatorController = controler_;
            Vector3 inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			hammer_.transform.localScale = new Vector3(scale_,scale_,scale_);
            hammer_.transform.position = new Vector3(inputPos.x,inputPos.y,hammer_.transform.position.z);
        }
    }
}
