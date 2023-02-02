using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class remplaceampoule : MonoBehaviour
{

    public bool JoueurEstProche1;
	public GameObject kbIconInfo1;
	public GameObject ampoulechange;
	public bool ampouleestla;
	public int ampouleaffiche;

    // Start is called before the first frame update
    void Start()
    {
		GameObject.Find(kbIconInfo1.name).GetComponent<SpriteRenderer>().enabled = false;
		GameObject.Find(ampoulechange.name).GetComponent<SpriteRenderer>().enabled = false;
		GameObject.Find("noampoule").GetComponent<SpriteRenderer>().enabled = false;
		JoueurEstProche1 = false;
		ampouleaffiche = 0;
	}

    // Update is called once per frame
    void Update()
    {
		ampouleestla = GameObject.Find("lotampoule").GetComponent<DectectPlayer2>().ampouleok;
		if (Input.GetKeyDown(KeyCode.E) && JoueurEstProche1 && ampouleestla)
		{
			ampouleaffiche = 1;
			GameObject.Find(ampoulechange.name).GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("noampoule").GetComponent<SpriteRenderer>().enabled = false;
			GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find(kbIconInfo1.name).GetComponent<SpriteRenderer>().enabled = false;
			Destroy(this.gameObject,1);
		} else if (Input.GetKeyDown(KeyCode.E) && JoueurEstProche1){
			GameObject.Find("noampoule").GetComponent<SpriteRenderer>().enabled = true;
		}

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//player potentialPlayer = collision.gameObject.GetComponent<player>();
		//if (potentialPlayer == null)
		//  return;
		GameObject.Find(kbIconInfo1.name).GetComponent<SpriteRenderer>().enabled = true;
		JoueurEstProche1 = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		GameObject.Find(kbIconInfo1.name).GetComponent<SpriteRenderer>().enabled = false;
		JoueurEstProche1 = false;
	}
}
