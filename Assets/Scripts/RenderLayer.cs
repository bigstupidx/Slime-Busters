using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class RenderLayer : MonoBehaviour {

	[SerializeField]
    private string layer;
    [SerializeField]
    private int sortingOrder;
	void Start () {
            renderer.sortingLayerName = layer;

            renderer.sortingOrder = sortingOrder;

        if (Application.isPlaying)
            Destroy(this);
	}
}
