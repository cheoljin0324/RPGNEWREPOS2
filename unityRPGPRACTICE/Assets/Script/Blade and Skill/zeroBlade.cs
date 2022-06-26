using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class zeroBlade : AttackBlade
{
    Test PlayerT;
    [SerializeField]
    private GameObject ShildSet;
    public float coolTime = 8.0f;

    GameObject Shild;

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

        if(GameManager.Instance.SkillIn == true && GameManager.Instance.nowState == GameManager.GameState.EndGame)
        {
            coolTime = 0.0f;
            Destroy(Shild);
        }

        if (Input.GetKey(KeyCode.E)&& GameManager.Instance.SkillIn == false&&coolTime<=0.0f)
        {
            GameManager.Instance.SkillIn = true;
            Skill1();
        }
    }

    IEnumerator SetShild()
    {
        Shild = Instantiate(ShildSet,GameObject.Find("Player_Unity").transform);
        Shild.transform.localScale = new Vector3(0, 0, 0);
        Shild.transform.position = gameObject.transform.position;
        Shild.GetComponent<MeshRenderer>().material.color = new Color(1, 236 / 255f, 0, 0.1f);

        Shild.transform.DOScale(new Vector3(3, 3, 3), 1);

        coolTime = 8.0f;

        yield return new WaitForSeconds(5f);
        Shild.GetComponent<MeshRenderer>().material.DOFade(0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Destroy(Shild);
        GameManager.Instance.SkillIn = false;
    }


    protected override void Skill1()
    {
        StartCoroutine(SetShild());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (PlayerT.isAttack == true)
            {
                CameraShake.CameraShaking();
                other.gameObject.SendMessage("Damage", PlayerT.attack);
            }
        }
    }
}