using UnityEngine;
using System.Collections;

public class DeleteAnimationOnReady : MonoBehaviour {
	void Start () {
        GameObject.Destroy(gameObject,GetComponent<Animation>().clip.length);
	}
}
