using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField]
    private Image FirstHeart;
    [SerializeField]
    private Image SecondHeart;
    [SerializeField]
    private Image ThirdHeart;
    [SerializeField]
    private Test PlayerTest;
    [SerializeField]
    private Button GameButton;

    private void Update()
    {
        if (PlayerTest.Hp == 1)
        {
            FirstHeart.gameObject.SetActive(true);
            SecondHeart.gameObject.SetActive(false);
            ThirdHeart.gameObject.SetActive(false);
        }
        else if (PlayerTest.Hp == 2) {
            FirstHeart.gameObject.SetActive(true);
            SecondHeart.gameObject.SetActive(true);
            ThirdHeart.gameObject.SetActive(false);
        }
        else if(PlayerTest.Hp == 3)
        {
            FirstHeart.gameObject.SetActive(true);
            SecondHeart.gameObject.SetActive(true);
            ThirdHeart.gameObject.SetActive(true);
        }
        else
        {
            FirstHeart.gameObject.SetActive(false);
            SecondHeart.gameObject.SetActive(false);
            ThirdHeart.gameObject.SetActive(false);
        }

        if (PlayerTest.Hp <= 0)
        {
            GameButton.gameObject.SetActive(true);
        }
    }

    public void RESTART()
    {
        Destroy(GameManager.Instance.gameObject);
        Destroy(GameObject.Find("[DOTween]"));
        SceneManager.LoadScene("GameStart");

    }
}
