using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public const string level01 = "Valley";

	private void OnEnable()
	{
		MenuEvents.Instance.StartPlaying.AddListener(ChangeScene);
	}

	private void OnDisable()
	{
		if (MenuEvents.Instance != null)
		{ MenuEvents.Instance.StartPlaying.RemoveListener(ChangeScene); }
	}

	public void ChangeScene()
	{
		SceneManager.LoadScene(level01);
		StartCoroutine(ResubscribeCO());
	}

	public void ChangeScene(string sceneName) { }

	IEnumerator ResubscribeCO()
	{
		int frameCounter = 2;
		while (frameCounter > 0)
		{
			frameCounter--;
			yield return null;
		}
		MenuEvents.Instance.StartPlaying.AddListener(ChangeScene);
	}
}
