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

     public void buttonClick()
     {
         shop.HammerButtonClick(id);
     }

     public void buttonToggle()
     {
         shop.HammerButtonToggle(id);
     }
}
