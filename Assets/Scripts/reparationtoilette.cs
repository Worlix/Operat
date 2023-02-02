using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reparationtoilette : MonoBehaviour
{
    public bool JoueurEstProche1;
	public GameObject kbIconInfo1;
	public GameObject toilettechange;


    // Start is called before the first frame update
    void Start()
    {
		GameObject.Find(kbIconInfo1.name).GetComponent<SpriteRenderer>().enabled = false;
		GameObject.Find(toilettechange.name).GetComponent<SpriteRenderer>().enabled = false;
		JoueurEstProche1 = false;
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.E) && JoueurEstProche1)
		{
			GameObject.Find(toilettechange.name).GetComponent<SpriteRenderer>().enabled = true;
			GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find(kbIconInfo1.name).GetComponent<SpriteRenderer>().enabled = false;

			Destroy(this.gameObject,1);
		}

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		GameObject.Find(kbIconInfo1.name).GetComponent<SpriteRenderer>().enabled = true;
		JoueurEstProche1 = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		GameObject.Find(kbIconInfo1.name).GetComponent<SpriteRenderer>().enabled = false;
		JoueurEstProche1 = false;
	}
}

