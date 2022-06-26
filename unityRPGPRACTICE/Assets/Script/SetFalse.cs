using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SetFalse : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(FalseOb());
    }

    IEnumerator FalseOb()
    {
        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.DOFade(0f, 0.2f);
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
