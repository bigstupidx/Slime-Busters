using UnityEngine;
using System.Collections;

public class InGameGui : MonoBehaviour {
    
    [SerializeField]
	private GameObject PauseMenu;
	
	private TweenScale MenuTween;
	
	// Use this for initialization
	private void Start () {
		MenuTween = PauseMenu.GetComponent<TweenScale>();
		
	}
	
	// Called by button in scene
	public void PauseButtonClicked () {
		Debug.Log("[InGameGui]Pause Button Pressed");
		MenuTween.Toggle();
        if(Time.timeScale > 0){
            Time.timeScale = 0;
			PauseMenu.SetActive(true);
        }else{
			StartCoroutine("SetMenuUnactive");
            Time.timeScale = 1;
        }
	}

	public void MenuButtonClicked () {
		Time.timeScale = 1;
		Debug.Log("[InGameGui]Menu Button Pressed");
		Application.LoadLevel ("MainMenu");
	}
	
	IEnumerator SetMenuUnactive() {
		yield return new WaitForSeconds(0.5f);
		Debug.Log ("setfalse");
		PauseMenu.SetActive (false);
	}
}
