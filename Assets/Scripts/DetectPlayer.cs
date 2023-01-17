using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    public bool JoueurEstProche;
    public GameObject kbIconInfo;
	public GameObject objet;
	public bool scotchok;
	public int affichescotch;


	// Start is called before the first frame update
	void Start()
    {
        GameObject.Find(kbIconInfo.name).GetComponent<SpriteRenderer>().enabled = false;
		GameObject.Find(objet.name).GetComponent<SpriteRenderer>().enabled = false;
		JoueurEstProche = false;
		scotchok = false;

}

    // Update is called once per frame
    void Update()
    {
		affichescotch = GameObject.Find("trou").GetComponent<troumur>().scotchaffiche;

		if (Input.GetKeyDown(KeyCode.E) && JoueurEstProche)
        {
			GameObject.Find(objet.name).GetComponent<SpriteRenderer>().enabled = true;
			scotchok = true;
		}

		if (affichescotch==1){
			GameObject.Find(objet.name).GetComponent<SpriteRenderer>().enabled = false;
			affichescotch = 0;
		}

		print(affichescotch);


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
