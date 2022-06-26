using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrapSetFriend : MonoBehaviour
{
    [SerializeField]
    private GameObject SetObstacle;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("This is my Trap");
        SetObstacle.SetActive(true);
        SetObstacle.transform.SendMessage("ShotTrap");
    }
}
