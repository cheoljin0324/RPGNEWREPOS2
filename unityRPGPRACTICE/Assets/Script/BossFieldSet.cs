using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossFieldSet : MonoBehaviour
{
    [SerializeField]
    private GameObject[] SetWall;
    [SerializeField]
    private Transform[] SetWall1;

    IEnumerator ShotTrap()
    {
        for(int i = 0; i<SetWall.Length; i++)
        {
            SetWall[i].transform.DOMove(SetWall1[i].transform.position, 0.5f, false);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
