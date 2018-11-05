using UnityEngine;

public class GameManager : MonoBehaviour
{
	//Instance and DontDestroyOnLoad for Level-, Audio- and Storymanaging

	LevelManager levelManager;
	public LevelManager LevelManager { get { return levelManager; } }

	AudioManager audioManager;
	public AudioManager AudioManager { get { return audioManager; } }

	StoryManager storyManager;
	public StoryManager StoryManager { get { return storyManager; } }

	MenuManager menuManager;
	public MenuManager MenuManager { get { return menuManager; } }

	static GameManager instance;
	public static GameManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = GameObject.FindObjectOfType<GameManager>();
				Instance.levelManager = Instance.GetComponentInChildren<LevelManager>();
				Instance.audioManager = Instance.GetComponentInChildren<AudioManager>();
				Instance.storyManager = Instance.GetComponentInChildren<StoryManager>();
				Instance.menuManager = Instance.GetComponentInChildren<MenuManager>();


				DontDestroyOnLoad(instance.gameObject);
			}
			return instance;
		}
		private set { instance = value; }
	}

	private void Awake()
	{
		levelManager = GetComponentInChildren<LevelManager>();
		audioManager = GetComponentInChildren<AudioManager>();
		storyManager = GetComponentInChildren<StoryManager>();
		menuManager = GetComponentInChildren<MenuManager>();


		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}

		else
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}
}