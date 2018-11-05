﻿using UnityEngine;

public class StoryManager : MonoBehaviour
{
	[SerializeField] GameObject[] images;
	int imageIndex;
	int maxImageIndex;

	MenuEvents menuEvents;

	void Awake() { maxImageIndex = images.Length - 1; }
	void OnEnable() { MenuEvents.Instance.NextImage.AddListener(OnNextImage); }

	public void OnNextImage()
	{
		images[imageIndex].SetActive(false);
		imageIndex++;

		if (imageIndex < 0) { imageIndex = maxImageIndex; }
		else if (imageIndex > maxImageIndex) { imageIndex = 0; }

		images[imageIndex].SetActive(true);
	}
}