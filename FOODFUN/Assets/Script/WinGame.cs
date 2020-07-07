using UnityEngine;

public class WinGame : MonoBehaviour
{
    public static WinGame instance;
    public int Count = 0;
    public bool WinTheGame;

    private void Update()
    {
        if (Count == 16)
        {
            WinTheGame = true;
        }
    }
}
