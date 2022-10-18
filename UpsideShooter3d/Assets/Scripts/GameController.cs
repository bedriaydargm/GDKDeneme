using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private float firstTouchX;
    private float currentTouchX;
    private Camera _cam;

    private void Start()
    {
        _cam = Camera.main;
    }

    Vector3 tempPos;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!GameManager.instance.isGamePlaying)
                GameManager.instance.GameStart();

            firstTouchX = _cam.ScreenToWorldPoint(Input.mousePosition).x;
            currentTouchX = firstTouchX;

            tempPos = _player.transform.position;
        }
        else if (Input.GetMouseButton(0))
        {
            currentTouchX = _cam.ScreenToWorldPoint(Input.mousePosition).x;

            tempPos += new Vector3((currentTouchX - firstTouchX)*3, 0, 0);
            tempPos.x = Mathf.Clamp(tempPos.x, -ScreenBoundries.ScreenBoundryOffsetX, ScreenBoundries.ScreenBoundryOffsetX);
            _player.transform.position = tempPos;
            
            firstTouchX = currentTouchX;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            firstTouchX = 0;
            currentTouchX = 0;
        }
    }
}
