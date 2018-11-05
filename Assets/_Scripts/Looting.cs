using UnityEngine;

public class Looting : MonoBehaviour
{
	//GameObjects with sprites in Valley/HUD/Panel
	public GameObject plant;
	public GameObject food;
	public GameObject seeds;
	public GameObject clothes;
	public GameObject water;
	public GameObject radio;

	//GameObjects Storypanel in Valley/Canvas
	public GameObject storyPanel01;
	public GameObject storyPanel02;
	public GameObject storyPanel03;
	public GameObject storyPanel04;
	public GameObject storyPanel05;
	public GameObject storyPanel06;

	StoryManagerScene storyMS;

	public Tag_Sprite tags; //tag-script

	public int counter;
	bool story01 = false;
	bool story02 = false;

	public void Update()
	{
		CountingItem();
	}

	public void CountingItem()
	{

		if (counter == 2 && !story01)
		{
			storyPanel01.gameObject.SetActive(true);
			story01 = true;
		}

		if (counter == 5 && !story02)
		{
			storyPanel02.transform.SetAsLastSibling();
			storyPanel02.gameObject.SetActive(true);
			story02 = true;
		}
	}

	public void OnTriggerStay(Collider other) //Objectcollider in Scene at Valley/ItemGet
	{
		bool plantGet = false;
		bool foodGet = false;
		bool seedsGet = false;
		bool clothesGet = false;
		bool waterGet = false;
		bool radioGet = false;

		if (Input.GetKeyDown(KeyCode.Q))
		{
			if (tags.tagCheck == true) //tag-script on GameObjects
			{
				if (other.gameObject.tag == "plant" && plantGet == false)
				{
					plant.SetActive(true);
					plantGet = true;
					counter++;
					Destroy(other.gameObject);
				}
				else if (other.gameObject.tag == "seeds" && seedsGet == false)
				{
					seeds.SetActive(true);
					seedsGet = true;
					counter++;
					Destroy(other.gameObject);
				}
				else if (other.gameObject.tag == "food" && foodGet == false)
				{
					food.SetActive(true);
					foodGet = true;
					counter++;
					Destroy(other.GetComponent<BoxCollider>());
				}
				else if (other.gameObject.tag == "clothes" && clothesGet == false)
				{
					clothes.SetActive(true);
					clothesGet = true;
					counter++;
					Destroy(other.GetComponent<BoxCollider>());
				}
				else if (other.gameObject.tag == "water" && waterGet == false)
				{
					water.SetActive(true);
					waterGet = true;
					counter++;
					Destroy(other.GetComponent<BoxCollider>());
				}
				else if (other.gameObject.tag == "radio" && radioGet == false)
				{
					radio.SetActive(true);
					radioGet = true;
					counter++;
					Destroy(other.gameObject);

					if (story01 == true)
					{
						if (story02 == true)
						{
							storyPanel03.gameObject.SetActive(true);
						}

						else
						{
							storyPanel02.gameObject.SetActive(true);
							storyPanel03.gameObject.SetActive(true);
						}
					}

					else
					{
						storyPanel01.gameObject.SetActive(true);
						storyPanel02.gameObject.SetActive(true);
						storyPanel03.gameObject.SetActive(true);
					}
				}
			}
		}
	}

	public void NextPanel04()
	{
		storyPanel04.transform.SetAsLastSibling();
		storyPanel04.gameObject.SetActive(true);
	}

	public void NextPanel05()
	{
		storyPanel05.transform.SetAsLastSibling();
		storyPanel05.gameObject.SetActive(true);
		storyPanel04.gameObject.SetActive(false);
	}

	public void NextPanel06()
	{
		storyPanel06.transform.SetAsLastSibling();
		storyPanel06.gameObject.SetActive(true);
		storyPanel04.gameObject.SetActive(false);
	}
}