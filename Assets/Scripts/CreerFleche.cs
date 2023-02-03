using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreerFleche : MonoBehaviour
{
    public GameObject pointerPrefab;
    private Transform Canva;
    private void Start()
    {
        Canva = GameObject.Find("Canvas").transform;

        GameObject newPointer = Instantiate(pointerPrefab, Canva);
        //newPointer.GetComponent<TaskPointer>().target = gameObject;
        //GameObject.FindObjectOfType<TaskPointer>().DefineTarget(gameObject);
        newPointer.GetComponent<TaskPointer>().DefineTarget(gameObject);
        //newPointer.transform.parent = GameObject.Find("Canva");
    }
}
