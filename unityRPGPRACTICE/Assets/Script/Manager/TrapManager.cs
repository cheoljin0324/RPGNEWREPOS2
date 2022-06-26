using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> trapList;
    [SerializeField]
    private List<Transform> trapPosList;
    [SerializeField]
    private List<bool> PosInIt;

    public int TrapAmount;

    private void Start()
    {
        for(int i = 0; i<trapPosList.Count; i++)
        {
            PosInIt.Add(false);
        }
        TrapAmount = Random.RandomRange(GameManager.Instance.userData.nowStage * 2, GameManager.Instance.userData.nowStage * 4);
        if (TrapAmount > trapPosList.Count) TrapAmount = trapPosList.Count;
        for(int i = 0; i<TrapAmount; i++)
        {
            int setNumber = Random.RandomRange(0, trapList.Count);
            GameObject SetTrap = Instantiate(trapList[setNumber]);
            int PosNumber = 0;
            while (PosInIt[PosNumber] == true)
            {
              PosNumber  = Random.RandomRange(0, trapPosList.Count);
            }
            Debug.Log(PosNumber);
            SetTrap.transform.position = trapPosList[PosNumber].position;
            PosInIt[PosNumber] = true;
            if (setNumber == 0)
            {
                SetTrap.transform.position = new Vector3(SetTrap.transform.position.x, 0.0f,SetTrap.transform.position.z);
            }
        }
    }

}
