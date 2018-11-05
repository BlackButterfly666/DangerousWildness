using UnityEngine;
using UnityEngine.UI;

public class TextContainerScene : MonoBehaviour
{
	//Text for Story
	public Text text04;
	public Text text05;
	public Text text06;
	public Text text07;
	public Text text08;
	public Text text09;

	public void Awake()
	{
		text04.text = "Your radio tell you some world news and so you hear about the nuclear threat. Other countries mount up there nuclear weapons.";
		text05.text = "One day you hear the sirens far away. You switch on your radio and you can hear someone telling, the military was load the big bomb to an airplane. You know this military base is only some miles away. ";
		text06.text = "The airplane leave the hangar and started. Some seconds later the airplane exploded and the nuclear radiation and the shock wave will bring massive destruction to the environment. So to your little valley too.";
		text07.text = "You know it. Immediately you take some stuff and run into your shelter. You reach it and lock the door right before the shock wave and the radiation blast your house away and burn the environment to ashes.";
		text08.text = "In the shelter you have to take a shower and after this you should take the medicine. This is a mixture of iodine for iodine blockage in the thyroid, some Prussian blue against the caesium poisoning and some medicine provided of the government in case of a nuclear event.";
		text09.text = "You will fall into stasis for a while. This will feel like dreaming, they said.";
	}
}
