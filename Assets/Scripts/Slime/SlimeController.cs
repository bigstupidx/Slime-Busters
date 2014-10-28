using UnityEngine;
using System.Collections;

[System.Serializable]
[RequireComponent(typeof(CircleCollider2D))]
public class SlimeController : MonoBehaviour
{
    public SlimeManager ParentScrip;
    
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
    private bool SlimeDead_ = false;

    public EffectManager effectManager;
    public bool Frozen;
    public bool time;

    public bool SlimeDead{
        get{
            return SlimeDead_;
        }
    }
    public bool GotSlime {
        get { 
            return _GotSlime; 
        }
    }
    public SlimeType slimeType {
        get { 
            return slimeType_; 
        }
    }
	public float waitTime{
		get{ 
            return privateWaitTime; 
        }
	}

    public void SetSlimeType(SlimeType type)
    {
        slimeType_ = type;
        slimeInfo = ParentScrip._slimesList.GetSlimeInfo(type);
        hp = slimeInfo.hP;
        molePopupTime = slimeInfo.molePopupTime;

        _GotSlime = true;
        SlimeDead_ = false;

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
            EventHandeler.CallOnHitSlime();
            if (hp > 1)
            {
                animator.SetTrigger("GotHit");
                hp --;
            }
            else
            {
                killAction();
                //addScore;
            }
        }
    }

    private void Update()
    {
        if (SlimeDead&&_GotSlime)
        {
            if (privateWaitTime < 0)
            {
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
            if (!SlimeDead && (slimeInfo.particleEffect != null))
            {
                Debug.Log("killAction type:"+slimeInfo.slimeType);
                if (slimeInfo.slimeType == SlimeType.Bomb)
                {
                    StartCoroutine(InstantiateDelay(slimeInfo.particleEffect, 0.25f));
                }
                else if (slimeInfo.slimeType == SlimeType.Pinata)
                {
                    StartCoroutine(InstantiateDelay(slimeInfo.particleEffect, 0.2f));
                }
                else
                {
                    GameObject.Instantiate(slimeInfo.particleEffect, transform.position, Quaternion.identity);
                }
            }
        }
        SlimeDead_ = true;
        hp = 0;
        ParentScrip.currentActive--;
    }

    IEnumerator InstantiateDelay(GameObject spawnGameObject, float delay)
    {
        yield return new WaitForSeconds(delay);
        GameObject.Instantiate(spawnGameObject, transform.position, Quaternion.identity);
    }

	public void DeSpawnAction()
	{
        if (animator != null)
		{
            animator.SetTrigger("DeSpawn");
            Destroy(animator.gameObject, privateWaitTime);
		}
		SlimeDead_ = true;
		hp = 0;
		ParentScrip.currentActive--;
	}
}
