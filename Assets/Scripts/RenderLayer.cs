using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class RenderLayer : MonoBehaviour {

	[SerializeField]
    private string layer;
    [SerializeField]
    private int sortingOrder;
	void Start () {
        if (layer != null)
        {
            renderer.sortingLayerName = layer;
        }
        if (sortingOrder != null)
        {
            renderer.sortingOrder = sortingOrder;
        }
        if (Application.isPlaying)
            Destroy(this);
	}
}
