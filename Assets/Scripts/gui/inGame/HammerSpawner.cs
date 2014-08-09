using UnityEngine;
using System.Collections;

public class HammerSpawner : MonoBehaviour {

    [SerializeField]
    private HammerList hammers;

    private HammerControler hammerColtrol;

	void Start () {
        int currentHammerId = GameDataController.getSaveInt(SaveInt.currentHammer);
        hammerColtrol = new HammerControler(this.transform, hammers.hammers[currentHammerId].controler);
	}

    public void Update()
    {
        hammerColtrol.Tick();
    }
}
