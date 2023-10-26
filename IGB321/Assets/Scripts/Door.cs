using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator doorAnimator;
    private GameManager gameManager;

    public bool greenDoor;
    public bool blueDoor;

    public bool doorLocked;

    public void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void Update()
    {
        // This code is shit but I literally could not be bothered 
        if (greenDoor && !gameManager.greenDoorsOpen)
        {
            doorLocked = true;
        }
        else if (blueDoor && !gameManager.blueDoorsOpen)
        {
            doorLocked = true;
        }
        else
        {
            doorLocked = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if (!doorLocked)
            {
                doorAnimator.SetTrigger("Open");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if (!doorLocked)
            {
                doorAnimator.SetTrigger("Close");
            }
        }
    }
}
