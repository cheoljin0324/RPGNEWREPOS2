using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SetTrap5 : MonoBehaviour
{
    [SerializeField]
    private GameObject Trap5;
    [SerializeField]
    private Transform TrapTransform;

    void ShotTrap()
    {
        Trap5.SetActive(true);
        StartCoroutine(SetTransformCoroutine());
    }

    IEnumerator SetTransformCoroutine()
    {
        Trap5.transform.DOMove(TrapTransform.position, 2f, false);
        yield return new WaitForSeconds(2f);

        Trap5.gameObject.SetActive(false);
    }
}
