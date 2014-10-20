using UnityEngine;

public enum SlimeType
{
    Bomb = 0,
    Normal = 1,
    Heart = 2,
    Helmet = 3,
    Ice = 4,
    Pinata = 5,
    Time = 6,
    Boss = 7
}

[System.Serializable]
public struct SlimeInfo
{
    public int hP;
    public SlimeType slimeType;
    public int frameCount;
    public float molePopupTime;
    public RuntimeAnimatorController runtimeAnimatorController;
    public GameObject particleEffect;
}
