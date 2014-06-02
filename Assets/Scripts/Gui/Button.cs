using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	[SerializeField]
	private string loadLevelName;
	// Use this for initialization
	void OnMouseDown () {
		Application.LoadLevel (loadLevelName);
	}
}
