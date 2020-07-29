using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    public GameObject doorLeft, doorRight, doorUp, doorDown;

    public bool roomLeft, roomRight, roomUp, roomDown;
    
    public Text text;

    public int stepToStart;
    void Start()
    {
        doorLeft.SetActive(roomLeft);
        doorRight.SetActive(roomRight);
        doorUp.SetActive(roomUp);
        doorDown.SetActive(roomDown);
    }


    public void UpdateRoom()
    {
        stepToStart = (int)(Mathf.Abs(transform.position.x / 15) + Mathf.Abs(transform.position.y / 9));
        text.text = stepToStart.ToString();
    }
}
