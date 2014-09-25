using UnityEngine;
using System.Collections;

public class SlimeTest : MonoBehaviour {
	//[SerializeField]
	//private string loadLevelName;
	// Use this for initialization
	private Animator animator;
	private bool SlimeAlive = true;
	[SerializeField]
	private RuntimeAnimatorController[] controlers;

	private void Start(){
		animator = GetComponent<Animator>();
	}

	void OnMouseDown () {
		if (SlimeAlive) {
			animator.SetTrigger ("FinalHit");
			SlimeAlive = false;
			Debug.Log("HIT TEST");
			StartCoroutine (NextSlime ());
		}
	}
	
	IEnumerator NextSlime() {
		yield return new WaitForSeconds(0.7f);
		//if (!SlimeAlive && !animator.IsInTransition(0)) {
			//animator = new Animator();
			int rand = Random.Range(0,controlers.Length);
			animator.runtimeAnimatorController = controlers[rand];
			animator.Play("Spawn", -1, 0f);
			Debug.Log("SPAWN NEW TEST");
			yield return new WaitForSeconds(0.35f);
			SlimeAlive = true;
		//}
	}
}