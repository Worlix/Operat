using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class TaskPointer : MonoBehaviour
{
    private Vector3 targetPosition;
    private RectTransform pointerRect;
    public GameObject target;
    private GameObject myPointer;
    private Camera uiCamera;
    private float borderSize = 150f;

    private void Awake()
    {
        myPointer = transform.Find("Pointer").gameObject;
        pointerRect = myPointer.GetComponent<RectTransform>();
        targetPosition = target.transform.position;
        uiCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toPosition = targetPosition;
        Vector3 fromPosition = Camera.main.transform.position;
        fromPosition.z = 0f;
        Vector3 dir = toPosition - fromPosition;
        float angle = UtilsClass.GetAngleFromVectorFloat(dir);
        pointerRect.localEulerAngles = new Vector3(0, 0, angle);

        Vector3 targetPositionScreenPoint = Camera.main.WorldToScreenPoint(targetPosition);
        bool isOffScreen = targetPositionScreenPoint.x <= borderSize || targetPositionScreenPoint.x >= Screen.width - borderSize || targetPositionScreenPoint.y <= borderSize || targetPositionScreenPoint.y >= Screen.height - borderSize;

        if (isOffScreen)
        {
            myPointer.SetActive(true);
            Vector3 cappedTargetScreenPosition = targetPositionScreenPoint;
            cappedTargetScreenPosition.x = Mathf.Clamp(cappedTargetScreenPosition.x, borderSize, Screen.width - borderSize);
            cappedTargetScreenPosition.y = Mathf.Clamp(cappedTargetScreenPosition.y, borderSize, Screen.height - borderSize);
            //if (cappedTargetScreenPosition.x <= borderSize) cappedTargetScreenPosition.x = borderSize;
            //if (cappedTargetScreenPosition.x >= Screen.width - borderSize) cappedTargetScreenPosition.x = Screen.width - borderSize;
            //if (cappedTargetScreenPosition.y <= borderSize) cappedTargetScreenPosition.y = borderSize;
            //if (cappedTargetScreenPosition.y >= Screen.height - borderSize) cappedTargetScreenPosition.y = Screen.height - borderSize;

            Vector3 pointerWorldPosition = uiCamera.ScreenToWorldPoint(cappedTargetScreenPosition);
            pointerRect.position = pointerWorldPosition;
            pointerRect.localPosition = new Vector3(pointerRect.localPosition.x, pointerRect.localPosition.y, 0f);
        }
        else
        {
            myPointer.SetActive(false);

            Vector3 pointerWorldPosition = uiCamera.ScreenToWorldPoint(targetPositionScreenPoint);
            pointerRect.position = pointerWorldPosition;
            pointerRect.localPosition = new Vector3(pointerRect.localPosition.x, pointerRect.localPosition.y, 0f);
        }
    }
}
