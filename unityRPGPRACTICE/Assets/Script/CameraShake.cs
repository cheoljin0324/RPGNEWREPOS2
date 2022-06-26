using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    float ShakeTime = 0.1f;
    float posDistance = 1f;

    public bool isOnShake = false;

    public void CameraShaking()
    {
        StopCoroutine("ShakeBy");
        StartCoroutine("ShakeBy");
    }

    private void LateUpdate()
    {
        if (isOnShake == true) return;
    }

    IEnumerator ShakeBy()
    {
        Vector3 StartPos = transform.position;

        isOnShake = true;

        while (ShakeTime > 0.0f)
        {
            transform.position = StartPos + Random.insideUnitSphere * posDistance;

            ShakeTime -= Time.deltaTime;

            yield return null;
        }
        ShakeTime = 0.1f;
        transform.position = StartPos;
        isOnShake = false;
    }
}
