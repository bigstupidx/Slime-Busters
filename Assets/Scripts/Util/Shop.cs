using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {

    [SerializeField]
    private UILabel CostLable;

	void Start () {
        CostLable.text = "Cost:500";
	}

    public void Back()
    {
        Application.LoadLevel("MainMenu");
    }

    public void Buy()
    {
        Debug.Log("Buy");
    }

    public void Use()
    {
        Debug.Log("Use");
    }
}
