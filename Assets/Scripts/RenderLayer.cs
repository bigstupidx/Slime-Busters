﻿using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class RenderLayer : MonoBehaviour {

	[SerializeField]
    private string layer;
    [SerializeField]
    private int sortingOrder;
	void Start () {
            GetComponent<Renderer>().sortingLayerName = layer;

            GetComponent<Renderer>().sortingOrder = sortingOrder;

        if (Application.isPlaying)
            Destroy(this);
	}
}
