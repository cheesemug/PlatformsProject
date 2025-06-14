using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinOnClick : MonoBehaviour
{
    public float rotationSpeed = 5.0f;
    public float rotationAngle = 90.0f;

    private bool isRotating = false;

    void OnMouseDown()
    {
        if (!isRotating && !GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).IsName("launch"))
        {
            StartCoroutine(RotateObjectSmoothly());
        }
    }

    IEnumerator RotateObjectSmoothly()
    {
        isRotating = true;

        float timeElapsed = 0f;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = transform.rotation * Quaternion.AngleAxis(rotationAngle, transform.up);

        while (timeElapsed < 1.0f)
        {
            timeElapsed += Time.deltaTime * rotationSpeed;
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, timeElapsed);
            yield return null;
        }

        transform.rotation = endRotation;
        isRotating = false;
    }
}
