using UnityEngine;
using UnityEngine.SceneManagement;


public class WinGame : MonoBehaviour
{
    public static WinGame instance;
    public int Count = 0;
    public bool WinTheGame;
    public GameObject WinSprite;

    public void Start()
    {
        instance = this;
    }
    private void Update()
    {
        if (Count == 15)
        {
            WinTheGame = true;
        }
        if (WinTheGame)
        {
            WinSprite.SetActive(true);
        }
    }
    /// <summary>
    /// 重玩一次
    /// </summary>
    public void Replay()
    {
        SceneManager.LoadScene("關卡一");
    }
}
