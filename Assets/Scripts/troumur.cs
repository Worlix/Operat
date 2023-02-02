using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class troumur : MonoBehaviour
{
	public bool JoueurEstProche;
	public GameObject kbIconInfo7;
	public bool scotchestla;
	public int scotchaffiche;

	// Start is called before the first frame update
	void Start()
    {
		GameObject.Find(kbIconInfo7.name).GetComponent<SpriteRenderer>().enabled = false;
		GameObject.Find("noscotch").GetComponent<SpriteRenderer>().enabled = false;
		JoueurEstProche = false;
		scotchaffiche = 0;
	}

    // Update is called once per frame
    void Update()
    {
		scotchestla = GameObject.Find("groupescotch").GetComponent<DetectPlayer>().scotchok;
		if (Input.GetKeyDown(KeyCode.E) && JoueurEstProche && scotchestla)
		{
			scotchaffiche = 1;
			GameObject.Find("noscotch").GetComponent<SpriteRenderer>().enabled = false;
			Destroy(this.gameObject, 1);
		} else if (Input.GetKeyDown(KeyCode.E) && JoueurEstProche){
			GameObject.Find("noscotch").GetComponent<SpriteRenderer>().enabled = true;
		}

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//player potentialPlayer = collision.gameObject.GetComponent<player>();
		//if (potentialPlayer == null)
		//  return;
		GameObject.Find(kbIconInfo7.name).GetComponent<SpriteRenderer>().enabled = true;
		JoueurEstProche = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		GameObject.Find(kbIconInfo7.name).GetComponent<SpriteRenderer>().enabled = false;
		JoueurEstProche = false;
	}
}
