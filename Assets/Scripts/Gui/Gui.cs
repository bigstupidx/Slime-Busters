using UnityEngine;
//using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Gui : MonoBehaviour {
	[SerializeField]
	private GUiData guiData;

	[HideInInspector]
	[SerializeField]
	private List<GameObject> currentGuiGameObjects;

	[HideInInspector]
	[SerializeField]
	private GUiButton[] currentButtons;

	[SerializeField]
	private GameObject guiHolder;

	public void Start(){

		ClearCurrentGui();
		//print ("start-------"+currentGuiGameObjects.Count);
		//if (!Application.isPlaying) {
		LoadGui ();
		//}

	}

	public void Update(){
		UpdateGuiPosition ();
		UpdateGuiInput ();
	}

	public void LoadGui(){
		currentGuiGameObjects = new List<GameObject> ();
		//currentButtons.Clone(guiData.screens [guiData.currentActive].buttons);
		for (int i = 0; i < guiData.screens [guiData.currentActive].buttons.Length; i++) {
			string newbuttonName = "button"+i.ToString();
			GameObject newButton = new GameObject (newbuttonName);
			newButton.transform.position = new Vector3(guiData.screens [guiData.currentActive].buttons[i].x,currentButtons[i].y,0);
			SpriteRenderer Render = newButton.AddComponent<SpriteRenderer>();
			Render.sprite = guiData.screens [guiData.currentActive].buttons[i].sprite;
			Render.sortingLayerID = guiData.screens [guiData.currentActive].buttons[i].orderInLayer;

			newButton.transform.parent = guiHolder.transform;
			currentGuiGameObjects.Add(newButton);
		}
	}
	
	private void UpdateGuiInput(){
		if(Input.GetMouseButtonDown(0)){
			Vector2 mousePos = MouseInput.getMouseWorldPosition2D ();
			print ("input");
			for (int i = 0; i < currentGuiGameObjects.Count; i++) {
				bool hit = MouseInput.check2dHit(currentGuiGameObjects[i].GetComponent<SpriteRenderer>().sprite.rect,mousePos);
				print ("button: "+i+" hit: "+hit);
			}
		}
	}
		
	private void UpdateGuiPosition(){
		//currentButtons = guiData.screens [guiData.currentActive].buttons;
		for (int i = 0; i < guiData.screens [guiData.currentActive].buttons.Length; i++) {
			currentGuiGameObjects[i].transform.position = new Vector3(guiData.screens [guiData.currentActive].buttons[i].x
			                                                          ,guiData.screens [guiData.currentActive].buttons[i].y,0);
			currentGuiGameObjects[i].GetComponent<Renderer>().sortingOrder = guiData.screens [guiData.currentActive].buttons[i].orderInLayer;
		}
	}

	private void OnDisable(){
		if (guiHolder != null) {

		}
	}

	private void ClearCurrentGui(){
		//print ("destroy:"+guiHolder);
		//GameObject.DestroyImmediate( guiHolder );
		for (int i = 0; i < currentGuiGameObjects.Count; i++) {
			//print (i);
			GameObject.DestroyImmediate( currentGuiGameObjects[i] );
		}
		//currentButtons = new GUiButton[0];
	}

}
