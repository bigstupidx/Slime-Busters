using UnityEngine;
using System.Collections;

public enum ScreenId
{
	StartScreen =	 0,
	GameGui =		 1
}

[System.Serializable]
public class GUiData
{
	public int currentActive;
	public GUiScreen[] screens;
}

[System.Serializable]
public class GUiScreen
{
	public GUiButton[] buttons;
}

[System.Serializable]
public class GUiButton
{
	public Sprite sprite;
	public float x;
	public float y;
	public int orderInLayer;
	public string name;
	public bool button = false;
}

