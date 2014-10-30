using UnityEngine;
using System.Collections;
using gameData;
using System.Collections.Generic;
public class Hearts : MonoBehaviour {

    [SerializeField]
    private Sprite heart;

    [SerializeField]
    private Color DeadHeart;

    private List<SpriteRenderer> hearts = new List<SpriteRenderer>(); 
	void Start () {
	    
	}
	
	
	void Update () {
	
	}

    void CreateNewHeart()
    {

    }
}
