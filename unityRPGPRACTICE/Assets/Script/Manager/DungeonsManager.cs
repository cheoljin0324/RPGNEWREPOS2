using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonsManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> dungeonsSet;
    [SerializeField]
    GameObject nowDungeons;
    private void Start()
    {
        
    }

    void InstDungeons(int dungeonsNumber)
    {
        nowDungeons = Instantiate(dungeonsSet[dungeonsNumber]);
    }
}
