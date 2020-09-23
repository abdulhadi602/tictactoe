using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Manager : MonoBehaviour
{
    public TextMeshProUGUI Winner;
    public Canvas GridBtns;
    // Start is called before the first frame update
    void Start()
    {
        
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

   public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
