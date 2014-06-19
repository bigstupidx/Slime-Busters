using UnityEngine;
using System.Collections;

 public class HammerButton:MonoBehaviour
{
    private int id;
    private Shop shop;
     public void initButton(int _id,Shop _shop)
     {
         id = _id;
         shop = _shop;
         //Debug.Log(id+" "+shop);
     }

     public void ButtonClick()
     {
         shop.HammerButtonClick(id);
     }

     public void ToggleClick()
     {
         shop.HammerToggleClicked(id);
     }
}
