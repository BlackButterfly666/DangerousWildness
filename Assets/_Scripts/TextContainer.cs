using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextContainer : MonoBehaviour //script for texts to easy changing things
{
	//Text for Story
	public Text text01;
	public Text text02;
	public Text text03;

	//text for movement and gameplay
	public Text textkeys01;
	public Text textkeys02;
	public Text textkeys03;
	public Text textkeys04;
	public Text textkeys05;
	public Text textkeys06;
	public Text textkeys07;
	public Text textkeys08;

	public void Awake()
	{
		text01.text = "These days are war days. The Great War lasts for more than 9 years and there is no end in sight. Otherwise the world is perfectly normal. ";
		text02.text = "You live somewhere in america, in a little valley, in a small house, where you processing your little garden for some food.";
		text03.text = "Walter. Before the war began, Paige, Walters wife, your wife, lives here in the small house too. She's a loving wife, but she went sad. Five years ago she died at cancer.";
	
		textkeys01.text = "move left | move back | move right";
		textkeys02.text = "move forward";
		textkeys03.text = "collect things";
		textkeys04.text = "run";
		textkeys05.text = "jump";
		textkeys06.text = "unlock Cursor";
		textkeys07.text = "close Game";
		textkeys08.text = "lock Cursor";
	}
}
