using UnityEngine;

public class Bunkercollider : MonoBehaviour {

	public Scene01 scene01;
	public Looting loot;

	public void OnTriggerEnter(Collider other)
	{
		if (loot.counter >= 4 && scene01.alive == true)
		{
			loot.NextPanel04();
		}
	}
}
