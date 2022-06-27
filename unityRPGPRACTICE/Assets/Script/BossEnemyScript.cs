using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BossEnemyScript : MonoBehaviour
{
    [SerializeField]
    private GameObject darkSword;
    [SerializeField]
    private GameObject darkSword2;
    private Vector3 darkSwordTransform;
    private Vector3 darkSwordTransform2;

    public GameObject CanvasMap;
    public GameObject DamageText;

    public int hp = 2000;
    public int setCoin = 10000;

    Test playerT;

    [SerializeField]
    GameObject targetTransform;

    private void Start()
    {
        playerT = GameObject.Find("Player_Unity").GetComponent<Test>();
        CanvasMap = GameObject.Find("Canvas");
        darkSwordTransform = new Vector3(darkSword.transform.position.x, darkSword.transform.position.y, darkSword.transform.position.z);
        darkSwordTransform2 = new Vector3(darkSword2.transform.position.x, darkSword2.transform.position.y, darkSword2.transform.position.z);
        StartCoroutine(PlayerAttack());
    }

    IEnumerator PlayerAttack()
    {
        while (true)
        {
            int a = Random.RandomRange(0,3);
            int b = Random.RandomRange(0, 3);
            yield return new WaitForSeconds(5f);
            GameObject TargetSet = Instantiate(targetTransform);
            TargetSet.transform.position = playerT.transform.position;
            darkSword.transform.DOMove(new Vector3(TargetSet.transform.position.x+a, TargetSet.transform.position.y, TargetSet.transform.position.z), 2.5f, false);
            darkSword2.transform.DOMove(new Vector3(TargetSet.transform.position.x + b, TargetSet.transform.position.y, TargetSet.transform.position.z), 2.5f, false) ;
            yield return new WaitForSeconds(3f);
            coolBalde(TargetSet);
        }
    }

    void Damage(int damage)
    {
        hp -= damage;
        Debug.Log(hp);
        if (hp <= 0)
        {
            Destroy(gameObject);
            GameObject.Find("EnemyManager").GetComponent<EnemyManager>().DelEnemy();
            GameManager.Instance.userData.coin += setCoin;
            GameManager.Instance.EndState();
        }
        GameObject TextImpact = Instantiate(DamageText, CanvasMap.transform);
        TextImpact.GetComponent<Text>().text = "-" + damage.ToString();
        TextImpact.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        TextImpact.transform.DOMoveY(TextImpact.transform.position.y + 300, 3f);
        TextImpact.GetComponent<Text>().DOFade(0f, 3f);
        StartCoroutine(DesTextDamage(TextImpact));
        Debug.Log("ÇÑ´ë¸¦ ÃÆ´Ù");
    }

    IEnumerator DesTextDamage(GameObject gameOb)
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameOb);
    }


    void coolBalde(GameObject target)
    {
        darkSword.transform.DOMove(darkSwordTransform, 2f, false);
        darkSword2.transform.DOMove(darkSwordTransform2, 2f, false);
        Destroy(target);
    }

}
