using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	[SerializeField]
	private string loadLevelName;
	// Use this for initialization
	private Animator animator;

	private void Start(){
		animator = GetComponent<Animator>();
	}

	IEnumerator SwitchScene() {
		//Debug.Log ("Load: "+loadLevelName);
		yield return new WaitForSeconds(0.7f);
		Application.LoadLevel (loadLevelName);
	}

	void OnMouseDown () {
        if(animator!=null){
		    animator.SetTrigger ("FinalHit");
        }
        EventHandeler.CallOnHitSlime();
		StartCoroutine (SwitchScene ());
	}


	
}
