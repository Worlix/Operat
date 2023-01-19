using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DectectPlayer2 : MonoBehaviour
{

    public bool JoueurEstProche1;
    public GameObject kbIconInfo1;
	public GameObject objet1;
    public bool ampouleok;
	public int afficheampoule;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find(kbIconInfo1.name).GetComponent<SpriteRenderer>().enabled = false;
		GameObject.Find(objet1.name).GetComponent<SpriteRenderer>().enabled = false;
		JoueurEstProche1 = false;
		ampouleok = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("projecteureteint") != null){
            afficheampoule = GameObject.Find("projecteureteint").GetComponent<remplaceampoule>().ampouleaffiche;
        }
		

		if (Input.GetKeyDown(KeyCode.E) && JoueurEstProche1)
        {
			GameObject.Find(objet1.name).GetComponent<SpriteRenderer>().enabled = true;
			ampouleok = true;
		}

		if (afficheampoule==1){
			GameObject.Find(objet1.name).GetComponent<SpriteRenderer>().enabled = false;
			afficheampoule = 0;
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
