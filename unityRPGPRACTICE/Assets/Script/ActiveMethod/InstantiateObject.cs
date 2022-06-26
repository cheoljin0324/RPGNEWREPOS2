using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObject : MonoBehaviour
{
    public GameObject[] Enemy;
    [SerializeField]
    Transform[] EnemyPos;
    [SerializeField]
    bool[] EnemySet;
    [SerializeField]
    GameObject SetChar;
    public bool EndElement = false;

    
    public List<GameObject> EnemyList;

    private void Update()
    {
        if(EndElement==true && EnemyList.Count == 0)
        {
            Debug.Log("�������� Ŭ����");
            GameManager.Instance.EndState();
            GameManager.Instance.freshTime();
            EndElement = false;
        }
    }

    public void EnemyInst()
    {
        GameManager.Instance.SetMobAmount();
        int SetEnemy = Random.RandomRange(0, Enemy.Length);
        GameObject EnemyOb = Instantiate(Enemy[SetEnemy]);
        EnemyOb.transform.position = transform.position;
        EnemyList.Add(EnemyOb);

        EnemyOb.GetComponent<EnemyTest>().targetCharacter = SetChar;
        EnemyOb.GetComponent<EnemyTest>().targetTransform = SetChar.transform;
        EnemyOb.GetComponent<EnemyTest>().InstOb = gameObject;
        EnemyOb.GetComponent<EnemyTest>().ID = EnemyList.Count;
        EnemyOb.transform.position = new Vector3(Random.RandomRange(transform.position.x - 10, transform.position.x + 10), transform.position.y, Random.RandomRange(transform.position.z - 10, transform.position.z + 10));

        GameManager.Instance.EnemyObList.Add(EnemyOb);
        EndElement = true;
    }

    void SetRemoveList(GameObject EnemyOb)
    {
        EnemyList.Remove(EnemyOb);
    }
}
