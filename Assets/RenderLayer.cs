using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class RenderLayer : MonoBehaviour {

	[SerializeField]
	private string layer;
	void Start () {
		renderer.sortingLayerName = layer;
	}
}
