using UnityEngine;

public class Scene01 : MonoBehaviour {

	MenuEvents menuEvents;
	public Looting looting;

	public float timer = 1800f;
	public bool alive = true;

	public void Update()
	{
		timer -= Time.deltaTime;
		if (timer <= 0f) { alive = false;  Xx(); }
	}

	public void Xx()
	{
		if (alive == false)
		{
			looting.NextPanel04();
			timer = 1000;
		}
	}

	public void ExplosionTimer()
	{
		Debug.Log("exploded");
		timer = 30f;
	}

	public void Final()
	{
		if (alive == true) { looting.NextPanel05(); }
		if (alive == false) { looting.NextPanel06(); }
	}

	//uncomment to see the timer for debug-reasons
	private void OnGUI()
	{
		//GUILayout.Label(timer.ToString());
	}
}
