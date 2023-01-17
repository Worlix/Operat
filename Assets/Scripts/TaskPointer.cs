using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class TaskPointer : MonoBehaviour
{
    public Vector3 targetPosition;
    private RectTransform pointerRect;

    private void Awake()
    {
        pointerRect = transform.Find("Pointer").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toPosition = targetPosition;
        Vector3 fromPosition = Camera.main.transform.position;
        fromPosition.z = 0f;
        Vector3 dir = toPosition - fromPosition.normalized;
        float angle = UtilsClass.GetAngleFromVectorFloat(dir);
        pointerRect.localEulerAngles = new Vector3(0, 0, angle);
    }
}
