using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum SlimeType
{
    Bomb = 0,
    Boss = 1,
    Heart = 2,
    Helmet = 3,
    Ice = 4,
    Pinata = 5,
    Time = 6,
    Normal = 7
}

[System.Serializable]
public class SlimeInfo {
    public int hP;
    public string LoadName;
    public int frameCount;
    public float molePopupTime;
    public SlimeInfo(int _hP, string _loadName, int _frameCount, float _molePopupTime)
    {
        hP = _hP;
        LoadName = _loadName;
        frameCount = _frameCount;
        molePopupTime = _molePopupTime;
    }
}


public class SlimeSettings{
    public static SlimeInfo GetSlimeInfo(SlimeType type){
        int hP;
        string loadName;
        int frameCount;
        float molePopupTime = 2f;
        switch (type)
        {
            case SlimeType.Bomb:
                hP = 1;
                loadName = "Bomb";
                frameCount = 24;
                break;
            case SlimeType.Boss:
                hP = 1;
                loadName = "Boss";
                frameCount = 24;
                break;
            case SlimeType.Heart:
                hP = 1;
                loadName = "Heart";
                frameCount = 24;
                break;
            case SlimeType.Helmet:
                hP = 3;
                loadName = "Helmet";
                frameCount = 24;
                molePopupTime = 4f;
                break;
            case SlimeType.Ice:
                hP = 1;
                loadName = "Ice";
                frameCount = 24;
                break;
            case SlimeType.Pinata:
                hP = 1;
                loadName = "Pinata";
                frameCount = 24;
                break;
            case SlimeType.Time:
                hP = 1;
                loadName = "Time";
                frameCount = 24;
                break;
            case SlimeType.Normal:
                hP = 1;
                loadName = "Normal";
                frameCount = 24;
                break;
            default:
                hP = 1;
                loadName = "Normal";
                frameCount = 24;
                break;
        }
        return new SlimeInfo(hP, loadName, frameCount, molePopupTime);
    }
}
