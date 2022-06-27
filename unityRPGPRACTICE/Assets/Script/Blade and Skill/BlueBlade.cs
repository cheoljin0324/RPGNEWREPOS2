using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBlade : AttackBlade
{
    Test PlayerT;
    [SerializeField]
    private ParticleSystem BlueBladeDamageImapact;

    private void Start()
    {
        CameraShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
        PlayerT = GetComponentInParent<Test>();
    }


    protected override void Skill1()
    {
        Debug.Log("BlueSword Active");
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject Impact;
        if (other.CompareTag("Enemy") || other.CompareTag("BossEnemy"))
        {
            if (PlayerT.isAttack == true)
            {
                CameraShake.CameraShaking();
                other.gameObject.SendMessage("Damage", PlayerT.attack);
                Impact = Instantiate(BlueBladeDamageImapact.gameObject, gameObject.transform);
                Impact.transform.position = new Vector3(other.transform.position.x, other.transform.position.y + 1f, other.transform.position.z);
                ParticleSystem PartcleImpact = Impact.GetComponent<ParticleSystem>();
                PartcleImpact.gameObject.SetActive(true);
                PartcleImpact.Play();
                StartCoroutine(DEsEffect(PartcleImpact));
            }
        }
    }
    
    IEnumerator DEsEffect(ParticleSystem Part)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(Part);
    }
}
