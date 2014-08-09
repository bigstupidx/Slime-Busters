using UnityEngine;
using System.Collections;

public class InGameGuiLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Application.LoadLevelAdditive("InGameGui");
	}
}
