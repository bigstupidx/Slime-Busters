using UnityEngine;
using System.Collections;
using UnityEditor;
using gameData;

[CustomEditor(typeof(BonusManager))]
public class scoreEditor : Editor {

    private int scoreToAdd;
    public override void OnInspectorGUI()
    {
        BonusManager manager = (BonusManager)target;

        manager.bonusLength = EditorGUILayout.FloatField("Bonus Lenght", manager.bonusLength);
        ProgressBar(manager.bonusTimer / manager.bonusLength, "BonusTime: " + TimeCover.tostring(manager.bonusTimer));
        
        if (GUILayout.Button("StartBonus"))
            ScoreStat.XpBonus();

        EditorGUILayout.Space();
        if (GUILayout.Button("ResetScore"))
        {ScoreStat.Score = 0; ScoreStat.HighScore = 0;}
        EditorGUILayout.LabelField("Score: " + ScoreStat.Score.ToString());
        EditorGUILayout.LabelField("Highscore: " + ScoreStat.HighScore.ToString());
        if (GUILayout.Button("AddScore"))
            ScoreStat.AddScore(scoreToAdd);
        scoreToAdd = EditorGUILayout.IntField("ScoreTo Add", scoreToAdd);
            
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("ScoreMulti: " + ScoreStat.baseMulti.ToString());
        ScoreStat.diff = (ScoreStat.diffLevels)EditorGUILayout.EnumPopup("difficulty level", ScoreStat.diff);
        if(GUILayout.Button("SetDifficulty"))
            ScoreStat.SetDifficulty();

    }

    void ProgressBar(float value, string label)
    {
        // Get a rect for the progress bar using the same margins as a textfield:
        Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
        EditorGUI.ProgressBar(rect, value, label);
        EditorGUILayout.Space();
    }
}
