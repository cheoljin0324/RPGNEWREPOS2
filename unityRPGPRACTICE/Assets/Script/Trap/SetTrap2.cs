using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SetTrap2 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] EnTrap;
    [SerializeField]
    private Transform[] EnPos;

    void ShotTrap()
    {
        for(int i = 0; i<EnTrap.Length; i++)
        {
            EnTrap[i].transform.DOMove(EnPos[i].transform.position,0.5f, false);
        }
    }
}
