using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundries : MonoBehaviour
{
    [SerializeField] private GameObject leftSide;
    [SerializeField] private GameObject rightSide;

    public static float ScreenBoundryOffsetX;
    // Start is called before the first frame update
    void Start()
    {
        float tempX = Vector3.Distance(Camera.main.ScreenToWorldPoint(Vector3.zero), Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0) * .5f));
        float tempY = Vector3.Distance(Camera.main.ScreenToWorldPoint(Vector3.zero), Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0) * .5f));
        
        ScreenBoundryOffsetX = tempX;
        
        leftSide.transform.position = new Vector3(-tempX, tempY, 0);
        rightSide.transform.position = new Vector3(tempX, tempY, 0);
    }
}
