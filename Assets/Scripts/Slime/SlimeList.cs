using UnityEngine;

public class SlimeList : MonoBehaviour
{
    [SerializeField]
    private SlimeInfo[] slimes;

    public SlimeInfo GetSlimeInfo(SlimeType type)
    {
        for (int i = 0; i < slimes.Length; i++)
        {
            if (slimes[i].slimeType == type)
            {
                return slimes[i];
            }
        }
        if (slimes.Length < 1)
        {
            Debug.LogError("No Slimes In List!");
        }
        Debug.LogError("Slime Not Found! Returnd first in list.");
        return slimes[0];
    }
}
