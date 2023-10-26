using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{
    public string message;
    public Text textGameObject;
    public float duration;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            textGameObject.text = message;
            textGameObject.enabled = true;
            Destroy(this.gameObject, duration);
        }
    }

    private void OnDestroy()
    {
        textGameObject.enabled = false;
    }
}
