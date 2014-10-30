using UnityEngine;
using System.Collections;

public enum SaveInt{
	money,
	currentHammer
}

public class GameDataController
{
	public static int getSaveInt(SaveInt saveInt){
        CustomDebug.Log("[load]" + saveInt +" "+PlayerPrefs.GetInt (saveInt.ToString()));
		return PlayerPrefs.GetInt (saveInt.ToString());
	}

	public static void setSaveInt(SaveInt saveInt, int value){
        CustomDebug.Log("[save]" + saveInt + " " + value );
		PlayerPrefs.SetInt (saveInt.ToString(),value);

        PlayerPrefs.Save();
	}
}

