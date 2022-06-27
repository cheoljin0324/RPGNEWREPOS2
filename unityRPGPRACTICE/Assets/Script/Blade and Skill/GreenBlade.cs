using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GreenBlade : AttackBlade
{
    Test PlayerT;
    public Transform PlayerTransform;
    [SerializeField]
    private GameObject SetOb;
    public float coolTime = 8.0f;

    private void Start()
    {
        coolTime = 0.0f;
        CameraShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
        PlayerT = GetComponentInParent<Test>();
    }

    private void Update()
    {
        Debug.Log(coolTime);
        if (coolTime >= 0.0f)
        {
            coolTime -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.E)&& coolTime <= 0.0f)
        {
            Skill1();
        }
        if (GameManager.Instance.SkillIn == true)
        {
            StartCoroutine(Delay());
        }

    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.SkillIn = false;
    }


    protected override void Skill1()
    {
        PlayerTransform = GameObject.Find("Player_Unity").GetComponent<Transform>();
        GameManager.Instance.SkillIn = true;
        float Setx = Input.GetAxis("Vertical");
        float Sety = Input.GetAxis("Horizontal");
        Debug.Log(PlayerTransform.position);
        PlayerTransform.DOMove(new Vector3(PlayerTransform.localPosition.x+(Sety*10), PlayerTransform.position.y, PlayerTransform.localPosition.z+(Setx*10)),0.5f,false);
        Debug.Log(PlayerTransform.position);
        StartCoroutine(Copy());
        coolTime = 8.0f;
    }




    IEnumerator Copy()
    {
        while(GameManager.Instance.SkillIn==true){
            yield return new WaitForFixedUpdate();
            GameObject Desh;

            Desh = Instantiate(SetOb);
            Desh.transform.position = PlayerTransform.position;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("BossEnemy"))
        {
            if (PlayerT.isAttack == true)
            {
                CameraShake.CameraShaking();
                other.gameObject.SendMessage("Damage", PlayerT.attack);
            }
        }
    }
}