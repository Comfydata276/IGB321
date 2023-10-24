using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirlockTriggerController : MonoBehaviour
{
    public TetherController tetherController;
    private bool tetheractive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && tetheractive == false)
        {
            tetherController.ActivateTether();
            tetheractive = true;
        }

        else if (other.CompareTag("Player") && tetheractive == true)
        {
            tetherController.DeactivateTether();
            tetheractive = false;
        }
    }
}
