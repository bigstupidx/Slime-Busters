using UnityEngine;
using System.Collections;
using UnityEditor;
using Score;

[CustomEditor(typeof(BonusManager))]
public class scoreEditor : Editor {

    public override void OnInspectorGUI()
    {
        BonusManager manager = (BonusManager)target;

        manager.bonusLength = EditorGUILayout.FloatField("Bonus Lenght", manager.bonusLength);
        ProgressBar(manager.bonusTimer / manager.bonusLength, "BonusTime: " + manager.bonusTimer);
        if (GUILayout.Button("StartBonus"))
            Statics.XpBonus();

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Score: " + Statics.Score.ToString());
        EditorGUILayout.LabelField("Highscore: " + Statics.HighScore.ToString());
            
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("ScoreMulti: " + Statics.baseMulti.ToString());
        Statics.diff = (Statics.diffLevels)EditorGUILayout.EnumPopup("difficulty level", Statics.diff);
        if(GUILayout.Button("SetDifficulty"))
            Statics.SetDifficulty();

    }

    void ProgressBar(float value, string label)
    {
        // Get a rect for the progress bar using the same margins as a textfield:
        Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
        EditorGUI.ProgressBar(rect, value, label);

    }
}
