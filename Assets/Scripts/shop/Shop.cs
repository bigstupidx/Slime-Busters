using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {
    [SerializeField]
    private HammerList hammers;
    [SerializeField]
    private UILabel CostLable;
    [SerializeField]
    private GameObject hammerButton;
    [SerializeField]
    private GameObject hammerButtonContainer;
    private UIPanel hammerPannel;

    private int currentHammerId;

    public void SetActiveHammer(int newCurrentHammerId)
    {
        currentHammerId = newCurrentHammerId;
        Debug.Log("button " + currentHammerId + " clicked\n name:"+hammers.hammers[currentHammerId].name);
    }


	void Start () {
        CostLable.text = "Cost:500";
        hammerPannel = hammerButtonContainer.GetComponent<UIPanel>();
        //hammerPannel.
        for (int i = 0; i < hammers.hammers.Length; i++)
        {
            AddHammerButton(270 - (95 * i), hammers.hammers[i].name,i);
        }
	}

    private delegate void TextAppendDelegate(string txt, string text);

    private void AddHammerButton(int y,string name,int id)
    {
        GameObject newButton = (GameObject)GameObject.Instantiate(hammerButton, Vector3.zero, Quaternion.identity);
        UILabel newLable = newButton.transform.GetChild(0).gameObject.GetComponent<UILabel>();
        UIButton newUIButton = newButton.GetComponent<UIButton>();
        newButton.GetComponent<HammerButton>().initButton(id,this);
        EventDelegate newEvent = new EventDelegate(newButton.GetComponent<HammerButton>(), "buttonClick");
        //newEvent.
        newUIButton.onClick.Add(newEvent);
        newLable.text = name;
        newButton.name = "Hammer Button"+name;
        newButton.transform.parent = hammerButtonContainer.transform;
        newButton.GetComponent<UISprite>().leftAnchor.target = hammerButtonContainer.transform;
        newButton.GetComponent<UISprite>().rightAnchor.target = hammerButtonContainer.transform;
        newButton.transform.localPosition = new Vector3(0, y, 9);
        newButton.transform.localScale = new Vector3(1, 1, 1);
    }

    public void HammerButtonEvent(int n)
    {
        Debug.Log("HammerButtonEvent: "+n);
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
