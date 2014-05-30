using UnityEngine;
using System.Collections;


public class HitRayFirere : MonoBehaviour
{
    [SerializeField]
    private string[] Message;

    void Update()
    {
        RaycastHit2D hit = new RaycastHit2D();
        Touch touch;
        if (Application.platform == RuntimePlatform.Android)
        {
            for (int i = 0; i < Input.touchCount; ++i)
            {
                if (Input.GetTouch(i).phase.Equals(TouchPhase.Began))
                {
                    touch = Input.GetTouch(i);
                    hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
                    if (hit.collider != null)
                    {
                        int l = Message.Length;
                        for (int j = 0; j < l; j++)
                        {
                            hit.transform.gameObject.SendMessage(Message[j], SendMessageOptions.DontRequireReceiver);
                        }
                    }
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null)
                {
                    int l = Message.Length;
                    for (int i = 0; i < l; i++)
                    {
                        hit.transform.gameObject.SendMessage(Message[i], SendMessageOptions.DontRequireReceiver);
                    }
                }
            }
        }
    }
}