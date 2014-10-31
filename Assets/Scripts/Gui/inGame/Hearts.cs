using UnityEngine;
using System.Collections;
using gameData;
using System.Collections.Generic;
public class Hearts : MonoBehaviour {

    [SerializeField]
    private Sprite heart;

    [SerializeField]
    private Color DeadColour= Color.gray;
    [SerializeField]
    private Color AliveColour = Color.red;

    [SerializeField]
    Vector2 placementOffset = new Vector2(0.55f,0);

    private List<SpriteRenderer> spRenders = new List<SpriteRenderer>();

    private int cHealth = 0;
    private int Activehearts;
	void Start () 
    {
            while (HealthStat.health < HealthStat.maxHealth)
            {
                HealthStat.health++;

                CreateNewHeart();
            }

            cHealth = HealthStat.maxHealth;
    }
	
	
	void Update () 
    {
        if (HealthStat.health != cHealth)
        {
            int health = HealthStat.health;
            int diff = health - health;

            if (diff<0)
            {
                spRenders[Activehearts - 1].color =DeadColour;
                Activehearts--;
            }
            else if (diff > 0)
            {
                spRenders[Activehearts - 1].color = AliveColour;
                Activehearts++;
            }
            cHealth = health;
        }
	}

    void CreateNewHeart()
    {
        GameObject g = new GameObject();
        g.transform.parent = transform;
        g.transform.localScale = new Vector3(1, 1, 1);
        g.layer = 8;
        g.name = "Heart";
        int renders = spRenders.Count;
        g.transform.localPosition = new Vector3(placementOffset.x * renders, placementOffset.y * renders);
        g.AddComponent<SpriteRenderer>();

        SpriteRenderer sprRen = g.GetComponent<SpriteRenderer>();
        sprRen.sprite = heart;
        sprRen.color = AliveColour;
        sprRen.sortingOrder = 10;
        spRenders.Add(sprRen);
    }
}
