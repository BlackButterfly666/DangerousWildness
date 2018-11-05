using UnityEngine;

public class MenuManager : MonoBehaviour
{
	public RectTransform startMenu;
	public RectTransform mainMenu;
	public RectTransform optionsMenu;
	public RectTransform pauseMenu;
	public RectTransform storyMenu;
	MenuEvents menuEvents;

	private void OnEnable()
	{
		menuEvents = GetComponent<MenuEvents>();
		menuEvents.ChangeMenu.AddListener(SetActiveMenu);
	}

	private void OnDisable()
	{
		menuEvents.ChangeMenu.RemoveListener(SetActiveMenu);
	}

	public void SetActiveMenu(ActiveMenu activeMenu)
	{
		switch (activeMenu)
		{
			case ActiveMenu.Start:
				startMenu.SetAsLastSibling();
				break;
			case ActiveMenu.Main:
				mainMenu.SetAsLastSibling();
				break;
			case ActiveMenu.Options:
				optionsMenu.SetAsLastSibling();
				break;
			case ActiveMenu.Pause:
				pauseMenu.SetAsLastSibling();
				break;
			case ActiveMenu.Story:
				storyMenu.SetAsLastSibling();
				break;
			default:
				break;
		}
	}
}