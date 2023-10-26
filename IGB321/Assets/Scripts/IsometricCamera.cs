using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricCamera : MonoBehaviour {

    public GameObject player;

    public float height;
    public float zDisp;

    public float cameraSpeed = 1.0f;
    private Vector3 newCamPos;

    public float shakeDuration;
    public float shakeStrength;
    public AnimationCurve shakeCurve;

    // Use this for initialization
    void Start () {
        transform.position = new Vector3(transform.position.x, height, transform.position.z - zDisp);
	}

    // Update is called once per frame
    void Update () {

        //If Player Alive...
        if (player) {
            CameraMovement();
        }

        if (Random.Range(0, 2000) == 1)
        {
            DoShake(0.05f, 0.3f);
        }
        else if (Random.Range(0, 100) == 1)
        {
            DoShake(0.0025f, 1);
        }
    }


    //Camera Pans (Lerps) towards position above player avatar
    void CameraMovement() {

        newCamPos = player.transform.position;

        newCamPos.y = player.transform.position.y + height;
        newCamPos.z = player.transform.position.z - zDisp;

        transform.position = Vector3.Lerp(transform.position, newCamPos, cameraSpeed * Time.deltaTime);
    }

    IEnumerator Shaking()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            startPosition = transform.position;
            elapsedTime += Time.deltaTime;
            float strength = shakeCurve.Evaluate(elapsedTime / shakeDuration);
            transform.position = startPosition + Random.insideUnitSphere * (strength * shakeStrength);
            yield return null;
        }

        transform.position = startPosition;
    }

    public void DoShake(float strength, float duration)
    {
        shakeStrength = strength;
        shakeDuration = duration;

        StartCoroutine(Shaking());
    }
}
