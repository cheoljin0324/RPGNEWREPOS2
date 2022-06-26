using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapInstantiate : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> TrapSet;
    [SerializeField]
    private List<Transform> TrapTransform;

    [SerializeField]
    public List<GameObject> CurrentTrap;

    void SetObject()
    {
        for(int i = 0; i<CurrentTrap.Count; i++)
        {
            Destroy(CurrentTrap[i]);
        }
        int TrapAmount = Random.RandomRange(GameManager.Instance.userData.nowStage*2,GameManager.Instance.userData.nowStage*4);
        for(int i = 0; i<TrapAmount; i++)
        {
            int TrapLength = Random.RandomRange(0, TrapSet.Count);
            int PosLength = Random.RandomRange(0, TrapTransform.Count);

            GameObject SetOb = Instantiate(TrapSet[TrapLength]);
            SetOb.transform.position = TrapTransform[PosLength].position;

            CurrentTrap.Add(SetOb);
        }
    }
       

}
