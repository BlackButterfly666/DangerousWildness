using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
	[SerializeField] AnimationCurve volCurve;
	[SerializeField] AudioMixer mainMixer;
	[SerializeField] AudioClip[] mods;
	AudioSource musicSource;
	int maxMusicIndex;
	int musicIndex = 1;
	bool musicIsPlaying;

	private void Awake()
	{
		musicSource = GetComponentInChildren<Tag_MusicSource>().GetComponent<AudioSource>();
	}

	void OnEnable()
	{
		MenuEvents.Instance.PrevTrack.AddListener(OnPrevTrack);
		MenuEvents.Instance.NextTrack.AddListener(OnNextTrack);
		MenuEvents.Instance.ChangeVolume.AddListener(OnChangeVolume);
		MenuEvents.Instance.ChangeMenu.AddListener(StartMusic);
	}

	void Start()
	{
		maxMusicIndex = mods.Length - 1;
		musicSource.clip = mods[musicIndex];
	}

	void StartMusic(ActiveMenu activeMenu)
	{
		if (!musicIsPlaying && activeMenu == ActiveMenu.Main)
		{
			musicIsPlaying = true;
			musicSource.Play();
		}
	}

	void OnPrevTrack()
	{
		musicIndex--;
		if (musicIndex < 0)
		{ musicIndex = maxMusicIndex; }

		musicSource.Stop();
		musicSource.clip = mods[musicIndex];
		musicSource.Play();
	}

	void OnNextTrack()
	{
		musicIndex++;
		if (musicIndex > maxMusicIndex)
		{ musicIndex = 0; }

		musicSource.Stop();
		musicSource.clip = mods[musicIndex];
		musicSource.Play();
	}

	void OnChangeVolume(float val)
	{
		float volume = Mathf.Lerp(-80, 0, val);
		mainMixer.SetFloat("musicVol", volume);
	}

	void PrintUnitValFromVolume()
	{
		float vol = 0;
		mainMixer.GetFloat("musicVol", out vol);
		vol = Utils.Map(vol, -80f, 0f, 0f, 1f);
	}
}

public static class Utils
{
	public static float Map(float oldVal,
		float oldMin,
		float oldMax,
		float newMin,
		float newMax)
	{
		float oldRange = oldMax - oldMin;
		float newRange = newMax - newMin;
		float newVal = (((oldVal - oldMin) / oldRange) * newRange) + newMin;
		return newVal;
	}
}