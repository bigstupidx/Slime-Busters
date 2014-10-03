using UnityEngine;
using System.Collections;

[System.Serializable]
[RequireComponent(typeof(CircleCollider2D))]
public class SlimeMoveBase : MonoBehaviour
{
#region Normal vars
    public MollControler ParentScrip;
    public bool SlimeDead = false;

    [SerializeField]
    private int orderLayer;
    private bool _GotSlime = false;
    private SlimeInfo slimeInfo;
    private int hp;
    private SlimeType slimeType_;
    private Vector3 OffSet;
    private float privateWaitTime = 0f; //used so animations dont cross paths
    private float molePopupTime; // when zero the slime dies
    private Animator animator;
#endregion

#region Getter/Setter
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
            return slimeType_;
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
        slimeType_ = type;
        slimeInfo = ParentScrip._slimesList.GetSlimeInfo(type);
        hp = slimeInfo.hP;
        molePopupTime = slimeInfo.molePopupTime;

        _GotSlime = true;
        SlimeDead = false;

        privateWaitTime = (1f / GameSettings.animationFPS * slimeInfo.frameCount);
        GameObject newSlime = new GameObject("slime");
        SpriteRenderer newSprite = newSlime.AddComponent<SpriteRenderer>();
        newSprite.sprite = ParentScrip.initSprite;
        newSprite.sortingOrder = orderLayer;
        animator = newSlime.AddComponent<Animator>();
        animator.runtimeAnimatorController = slimeInfo.runtimeAnimatorController;
        newSlime.transform.parent = transform;
        newSlime.transform.localPosition = OffSet;
    }

    //activated by hitRayFirere
    public void hit()
    {
        if (_GotSlime && animator != null)
        {
            if (hp > 1)
            {
                Handheld.Vibrate();
                animator.SetTrigger("GotHit");
				Debug.Log("GotHit");
                hp --;
            }
            else
            {
                Handheld.Vibrate();
                killAction();
				Debug.Log("FinalHit");
                animator.SetTrigger("FinalHit");
                SlimeDead = true;
                //addScore;
            }
            if (particleSystem != null)
            {
                particleSystem.Emit(20);
            }
        }
    }

    private void Update()
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

    private void killAction()
    {
        if (animator != null)
        {
            animator.SetTrigger("FinalHit");
            Destroy(animator.gameObject, privateWaitTime);
            if (slimeInfo.particleEffect != null)
            {
                GameObject.Instantiate(slimeInfo.particleEffect, transform.position, Quaternion.identity);
            }
        }
        SlimeDead = true;
        hp = 0;
        ParentScrip.currentActive--;
    }

	public void DeSpawnAction()
	{
        if (animator != null)
		{
            animator.SetTrigger("DeSpawn");
            Destroy(animator.gameObject, privateWaitTime);
		}
		SlimeDead = true;
		hp = 0;
		ParentScrip.currentActive--;
	}
}
