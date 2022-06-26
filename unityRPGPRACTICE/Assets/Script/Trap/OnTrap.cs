using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrap : MonoBehaviour
{
    [SerializeField]
    private int poinNumber;
    bool setTrap = false;

    EnemyManager dungeonManager;

    private void Start()
    {
        dungeonManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (setTrap == false)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("This is my Trap");
                gameObject.transform.parent.SendMessage("ShotTrap");
                if (dungeonManager.theDungeon != EnemyManager.DungeonState.Game)
                {
                    GameObject.Find("EnemyManager").GetComponent<EnemyManager>().InstantObject(poinNumber);
                }
                setTrap = true;
            }
          
        }
        

    }
}
