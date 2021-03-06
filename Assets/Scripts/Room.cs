﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    public GameObject doorLeft, doorRight, doorUp, doorDown;

    public bool roomLeft, roomRight, roomUp, roomDown;
    
    public Text text;

    public int stepToStart;

    public int doorNumber;
    void Start()
    {
        doorLeft.SetActive(roomLeft);
        doorRight.SetActive(roomRight);
        doorUp.SetActive(roomUp);
        doorDown.SetActive(roomDown);
    }


    public void UpdateRoom(float xOffse, float yOffset)
    {
        stepToStart = (int)(Mathf.Abs(transform.position.x / xOffse) + Mathf.Abs(transform.position.y / yOffset));
        text.text = stepToStart.ToString();

        if(roomUp)
            doorNumber++;
        if(roomDown)
            doorNumber++;
        if(roomLeft)
            doorNumber++;
        if(roomRight)
            doorNumber++;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            CameraController.instance.CangeTarget(transform);
        }    
    }
}
