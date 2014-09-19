using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(TestScript))]
public class TestScriptEditor : Editor
{

    public override void OnInspectorGUI()
    {
        TestScript myTarget = (TestScript)target;
        myTarget.test = EditorGUILayout.IntSlider("test", myTarget.test, 0, 100);
        ProgressBar(myTarget.test/100f, "Test");
 
    }

     void ProgressBar (float value, string label) {
		// Get a rect for the progress bar using the same margins as a textfield:
		Rect rect = GUILayoutUtility.GetRect (18, 18, "TextField");
		EditorGUI.ProgressBar (rect, value, label);
		EditorGUILayout.Space ();
	}
}
