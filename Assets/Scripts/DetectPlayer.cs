using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    public bool JoueurEstProche;
    public GameObject kbIconInfo;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find(kbIconInfo.name).GetComponent<SpriteRenderer>().enabled = false;
        JoueurEstProche = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && JoueurEstProche)
        {
			
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
