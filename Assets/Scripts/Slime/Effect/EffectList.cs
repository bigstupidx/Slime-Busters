using UnityEngine;

public class EffectList : MonoBehaviour
{
    [SerializeField]
    private Effect[] effects;

    public  Effect GetEffect(EffectType type)
    {
        for (int i = 0; i < effects.Length; i++)
        {
            if (effects[i].effectType == type)
            {
                return effects[i];
            }
        }
        if (effects.Length < 1)
        {
            Debug.LogError("No Effect In List!");
        }
        Debug.LogError("Effect Not Found!");
        return effects[0];
    }
}
