using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Manager : MonoBehaviour
{
    public TextMeshProUGUI Winner;
    public Canvas GridBtns;
    public static availableModes gametype;

    private static bool isModeSet;
    // Start is called before the first frame update
    void Start()
    {
        isModeSet = false;
        if (!isModeSet)
        {
            isModeSet = true;
            gametype = availableModes.Bot;
        }
    }
    public void GameOver(int winner)
    {
        GridBtns.enabled = false;
        if(winner == 1)
        {
            Winner.SetText("X won");
        }
        else if (winner == -1)
        {
            Winner.SetText("O won");
        }
        else
        {
            Winner.SetText("tie");
        }
    }
    public void isLocalMultiplayer()
    {
        gametype = availableModes.isLocalMultiplayer;
        isModeSet = true;
    }
    public void isMultiplayer()
    {
        gametype = availableModes.Multiplayer;
        isModeSet = true;
    }
    public void isBot()
    {
        gametype = availableModes.Bot;
        isModeSet = true;
    }
    public void setMode(availableModes mode)
    {
        gametype = mode;
    }

    public availableModes getMode()
    {
        
        return gametype;
    }
   public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
