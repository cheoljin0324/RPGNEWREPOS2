using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBlade : MonoBehaviour
{
    Test PlayerT;
    protected CameraShake CameraShake;

    private void Start()
    {
        CameraShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
        PlayerT = GetComponentInParent<Test>();
    }

    private void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Skill1();
        }
    }

    protected virtual void Skill1()
    {
        Debug.Log("skill1 Active");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")||other.CompareTag("BossEnemy"))
        {
            if(PlayerT.isAttack == true)
            {
                CameraShake.CameraShaking();
                other.gameObject.SendMessage("Damage", PlayerT.attack);
            }
           
        }
    }

}
