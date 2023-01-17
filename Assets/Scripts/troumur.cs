using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class troumur : MonoBehaviour
{
	public bool JoueurEstProche;
	public GameObject kbIconInfo;
	public bool scotchestla;
	public int scotchaffiche;

	// Start is called before the first frame update
	void Start()
    {
		GameObject.Find(kbIconInfo.name).GetComponent<SpriteRenderer>().enabled = false;
		JoueurEstProche = false;
		scotchaffiche = 0;
	}

    // Update is called once per frame
    void Update()
    {
		scotchestla = GameObject.Find("Triangle").GetComponent<DetectPlayer>().scotchok;
		if (Input.GetKeyDown(KeyCode.E) && JoueurEstProche && scotchestla)
		{
			
			scotchaffiche = 1;
			Destroy(this.gameObject);
		}

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//player potentialPlayer = collision.gameObject.GetComponent<player>();
		//if (potentialPlayer == null)
		//  return;
		GameObject.Find(kbIconInfo.name).GetComponent<SpriteRenderer>().enabled = true;
		JoueurEstProche = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		GameObject.Find(kbIconInfo.name).GetComponent<SpriteRenderer>().enabled = false;
		JoueurEstProche = false;
	}
}
