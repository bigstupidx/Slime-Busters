using UnityEngine;
using System.Collections;

public class HammerSpawner : MonoBehaviour {

    [SerializeField]
    private HammerList hammers;
	[SerializeField]
	private float hammerScale = 1;

    private HammerCreator hammerCreator_;

    public HammerCreator hammerCreator
    {
        get
        {
            if (hammerCreator_ == null)
            {
                int currentHammerId = GameDataController.getSaveInt(SaveInt.currentHammer);
                hammerCreator_ = new HammerCreator(hammers.hammers[currentHammerId].controler, hammerScale, hammers.hammers[currentHammerId].clip);
            }
            return hammerCreator_;
        }
    }

    void OnEnable()
    {
        EventHandeler.OnHitSlime += OnHit;
    }

    void OnDisable()
    {
        EventHandeler.OnHitSlime -= OnHit;
    }

    void OnHit()
    {
        hammerCreator.OnHit();
    }
}
