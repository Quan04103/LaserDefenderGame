using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float cameraShakeDuration = 0.5f;
    [SerializeField] float cameraShakeMagnitude = 0.1f;
    Vector3 initalPosition;
    void Start()
    {
        initalPosition = transform.position;
    }
    public void Play()
    {
        StartCoroutine(Shake());
    }
    IEnumerator Shake()
    {
        float elapsedTime = 0;
        while(elapsedTime < cameraShakeDuration)
        {
            transform.position = initalPosition + (Vector3)Random.insideUnitCircle * cameraShakeMagnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = initalPosition;

    }
}
