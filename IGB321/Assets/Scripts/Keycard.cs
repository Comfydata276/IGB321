using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : MonoBehaviour
{
    public bool greenKeycard;
    public bool blueKeycard;

    private GameManager gameManager;

    public void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        transform.Rotate(0, 100 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if (blueKeycard)
            {
                gameManager.blueDoorsOpen = true;
            } 
            else if (greenKeycard)
            {
                gameManager.greenDoorsOpen = true;
            }

            Destroy(gameObject);
        }
    }
}
