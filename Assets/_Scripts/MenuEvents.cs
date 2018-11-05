using UnityEngine;
using UnityEngine.Events;

public class MenuEvents : MonoBehaviour
{
	public UnityEvent StartPlaying = new UnityEvent();
	public UnityEvent<ActiveMenu> ChangeMenu = new ActiveMenuEvent();
	public UnityEvent<float> ChangeVolume = new FloatEvent();
	public UnityEvent PrintToVolToUnitVal = new UnityEvent();
	public UnityEvent PrevTrack = new UnityEvent();
	public UnityEvent NextTrack = new UnityEvent();
	public UnityEvent NextImage = new UnityEvent();

	#region Singleton
	static MenuEvents instance;
	public static MenuEvents Instance
	{
		get
		{
			if (instance == null)
			{
				instance = GameObject.FindObjectOfType<MenuEvents>();
			}
			return instance;
		}

		private set
		{
			instance = value;
		}
	}
	#endregion

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{ Destroy(gameObject); }
		else
		{ Instance = this; }
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
	}

	#region Button Invoke
	//Menu changing
	public void ToMainMenuButton() { ChangeMenu.Invoke(ActiveMenu.Main); }
	public void ToOptionsMenuButton() { ChangeMenu.Invoke(ActiveMenu.Options); }
	public void ToPauseMenuButton() { ChangeMenu.Invoke(ActiveMenu.Pause); }
	public void ToPlayButton() { ChangeMenu.Invoke(ActiveMenu.Story); }

	public void ClosePanel(GameObject go) { go.SetActive(false); }

	//Optionmenu objects
	public void VolumeSlider(float val) { ChangeVolume.Invoke(val); }
	public void VolToUnitValButton() { PrintToVolToUnitVal.Invoke(); }
	public void PrevTrackButton() { PrevTrack.Invoke(); }
	public void NextTrackButton() { NextTrack.Invoke(); }

	//
	public void SkipIntro() { StartPlaying.Invoke(); } 
	public void QuitApp() { Application.Quit(); } 
	public void NextImageButton() { NextImage.Invoke(); }
	#endregion
}

public enum ActiveMenu
{
	Start = 0,
	Main = 1,
	Options = 2,
	Pause = 3,
	Story = 4
}

[System.Serializable] public class ActiveMenuEvent : UnityEvent<ActiveMenu> { }
[System.Serializable] public class FloatEvent : UnityEvent<float> { }