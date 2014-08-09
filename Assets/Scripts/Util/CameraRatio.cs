using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class CameraRatio : MonoBehaviour
{
	void Start () {
        Camera.main.aspect = 16f / 9f;
	}
}
