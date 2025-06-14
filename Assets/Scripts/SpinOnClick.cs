using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinOnClick : MonoBehaviour
{
    public float rotationSpeed = 5.0f;
    public float rotationAngle = 90.0f;

    private bool isRotating = false;

    void OnMouseOver()
    {
        if (!isRotating && !GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).IsName("launch"))
        {
            if(Input.GetMouseButtonDown(0))
                StartCoroutine(RotateObjectSmoothly(rotationAngle));
            if (Input.GetMouseButtonDown(1))
                StartCoroutine(RotateObjectSmoothly(-rotationAngle));
        }
            
    }


    IEnumerator RotateObjectSmoothly(float rotationAngle)
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
