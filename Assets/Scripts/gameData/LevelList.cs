using UnityEngine;
using System.Collections;

public class LevelList : MonoBehaviour {
    [SerializeField]
    private GameObject[] levels;

    private void Start(){
        GameObject.Instantiate(levels[(int)Random.Range(0,levels.Length)],Vector3.zero,Quaternion.identity);
    }
}
