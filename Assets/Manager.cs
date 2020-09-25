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
    public GameObject ModeSelection;

    private static bool isModeSet;

    
    // Start is called before the first frame update
    void Start()
    {
        isModeSet = false;
        ModeSelection.SetActive(true);
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
        ModeSelection.SetActive(false);
        gametype = availableModes.isLocalMultiplayer;
        isModeSet = true;
    }
    public void isMultiplayer()
    {
        ModeSelection.SetActive(false);
        gametype = availableModes.Multiplayer;
        isModeSet = true;
    }
    public void isBot()
    {
        ModeSelection.SetActive(false);
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
