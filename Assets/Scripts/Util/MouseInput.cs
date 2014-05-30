using UnityEngine;
using System.Collections;

public class MouseInput
{
	public static Vector2 getMouseWorldPosition2D(){
		Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		Vector2 mousePos2D = new Vector2(mouseRay.origin.x,mouseRay.origin.y);
		return mousePos2D;
	}

	public static bool check2dHit(Rect rec,Vector2 point){
		bool hit = false;
		Debug.Log (rec);
		Debug.Log (point);
		if (rec.x < point.x && (rec.x + rec.width) > point.x && rec.y < point.y && (rec.y + rec.height) > point.y) {
			hit = true;
		}
		return hit;
	}
}

