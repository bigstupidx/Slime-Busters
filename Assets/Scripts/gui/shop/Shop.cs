using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {
    [SerializeField]
    private HammerList hammers;
    [SerializeField]
    private UILabel CostLable;
    [SerializeField]
    private UILabel MoneyLable;
    [SerializeField]
    private GameObject hammerButton;
    [SerializeField]
    private GameObject hammerButtonContainer;
    //private UIPanel hammerPannel;

	[SerializeField]
	private float hammerScale = 0.2777f;
    private int currentHammerId = 0;
    private int currentHammerPreviewId = 0;
    private int p_money = 3294;
    private HammerControler hammerColtrol;

    void Start () {
        UpdateCostMoneyLabels();
        //hammerPannel = hammerButtonContainer.GetComponent<UIPanel>();
        for (int i = 0; i < hammers.hammers.Length; i++)
        {
            AddHammerButton(270 - (95 * i), hammers.hammers[i].name,i);
        }
		hammerColtrol = new HammerControler(this.transform, hammers.hammers[0].controler,hammerScale);
		//set active hammer
        Debug.Log("Start");
        HammerToggleClicked(GameDataController.getSaveInt(SaveInt.currentHammer));
		Debug.Log (GameDataController.getSaveInt(SaveInt.currentHammer));

	}
    public void HammerButtonClick(int clickedId)
    {
        currentHammerPreviewId = clickedId;
        UpdateCostMoneyLabels();
        Debug.Log("button " + clickedId + " clicked\n name:" + hammers.hammers[clickedId].name);
    }

    public void HammerToggleClicked(int newCurrentHammerId)
    {
        UpdateCostMoneyLabels();
        currentHammerId = newCurrentHammerId;
        Debug.Log("toggle " + currentHammerId + " toggled\n name:" + hammers.hammers[currentHammerId].name);
        hammerColtrol.SetControler(hammers.hammers[currentHammerId].controler);
        GameDataController.setSaveInt(SaveInt.currentHammer, newCurrentHammerId);
    }

    public void UpdateCostMoneyLabels()
    {
        CostLable.text = "Cost: " + hammers.hammers[currentHammerPreviewId].cost;
        MoneyLable.text = "Money: " + p_money.ToString();
    }

	

    private delegate void TextAppendDelegate(string txt, string text);

    private void AddHammerButton(int y,string name,int id)
    {
        GameObject newButton = (GameObject)GameObject.Instantiate(hammerButton, Vector3.zero, Quaternion.identity);
       
        UILabel newLable = newButton.transform.GetChild(0).gameObject.GetComponent<UILabel>();
        newLable.text = name;

        UIButton newUIButton = newButton.GetComponent<UIButton>(); 
        newButton.GetComponent<HammerButton>().initButton(id,this);
        EventDelegate newEvent = new EventDelegate(newButton.GetComponent<HammerButton>(), "ButtonClick");
        newUIButton.onClick.Add(newEvent);

        UIButton newToggle = newButton.transform.GetChild(1).gameObject.GetComponent<UIButton>();
        newEvent = new EventDelegate(newButton.GetComponent<HammerButton>(), "ToggleClick");
        newToggle.onClick.Add(newEvent);

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

    public void Update()
    {
        hammerColtrol.Tick();
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
