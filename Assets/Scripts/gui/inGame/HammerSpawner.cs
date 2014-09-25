using UnityEngine;
using System.Collections;

public class HammerSpawner : MonoBehaviour {

    [SerializeField]
    private HammerList hammers;
	[SerializeField]
	private float hammerScale = 1;

    private HammerControler hammerColtrol;

	void Start () {
        int currentHammerId = GameDataController.getSaveInt(SaveInt.currentHammer);
        hammerColtrol = new HammerControler(this.transform, hammers.hammers[currentHammerId].controler,hammerScale);
	}

    public void Update()
    {
        hammerColtrol.Tick();
    }
}
