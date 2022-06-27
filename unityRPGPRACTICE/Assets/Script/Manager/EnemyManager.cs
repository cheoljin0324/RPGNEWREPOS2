using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public enum DungeonState {Idle, Start, Game, End }
    [SerializeField]
    private GameObject[] Mob;
    [SerializeField]
    private Transform[] setTransform;
    [SerializeField]
    private GameObject CharOb;
    [SerializeField]
    private GameObject[] Trap;
    private GameObject nowObject;

    int nowPointer;

    public DungeonState theDungeon = DungeonState.Idle;

    public void InstantObject(int dungeonsNumber, int EnemyID)
    {
        nowPointer = dungeonsNumber;
        int set = EnemyID;
        StartCoroutine(SetInstanObject(set, dungeonsNumber));
        theDungeon = DungeonState.Game;
    }

    IEnumerator SetInstanObject(int set, int dungeonsNumber)
    {
        yield return new WaitForSeconds(1.2f);
        nowObject = Instantiate(Mob[set]);
        if (set == 0)
        {
            nowObject.GetComponent<EnemyTest>().targetCharacter = CharOb;
            nowObject.GetComponent<EnemyTest>().targetTransform = CharOb.transform;
        }
        nowObject.transform.position = new Vector3(setTransform[dungeonsNumber].transform.position.x, setTransform[dungeonsNumber].transform.position.y, setTransform[dungeonsNumber].transform.position.z - 2f);
    }

    public void DelEnemy()
    {
        Destroy(nowObject);
        Trap[nowPointer].GetComponent<SetTrap4>().offDoor();
        nowObject = null;
        theDungeon = DungeonState.Idle;
    }
}
