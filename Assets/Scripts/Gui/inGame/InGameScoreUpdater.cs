using UnityEngine;
using System.Collections;
using gameData;

public class InGameScoreUpdater : MonoBehaviour {

    UILabel label;
    void Start()
    {
        label = GetComponent<UILabel>();
    }
	void Update () {
        label.text = "Score: " + ScoreStat.Score + "\n HighScore: " + ScoreStat.HighScore;
	}
}
