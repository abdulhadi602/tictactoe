using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Logic : MonoBehaviour
{

    // Start is called before the first frame update
    private GameObject X, O;
    private static int[,] Board;
    private static int MoveCounter;

    public GameObject manager;
    private Manager managerSC;

    public TextMeshProUGUI Turn;
    void Start()
    {
        Board = new int[3,3];

        X = Resources.Load("Prefabs/X") as GameObject;
        O = Resources.Load("Prefabs/O") as GameObject;

        MoveCounter = 0;
        managerSC = manager.GetComponent<Manager>();

    }

    public void Move(GameObject moveby,int i,int j)
    {
        MoveCounter++;
        if (MoveCounter < 9)
        {
            if (moveby == X)
            {
                Board[i, j] = +1;
                if (CheckForWin(1, Board))
                {
                    managerSC.GameOver(1);
                }
                else
                {
                    Turn.SetText("O's turn");
                }
            }
            else if (moveby == O)
            {
                Board[i, j] = -1;
                if (CheckForWin(-1, Board))
                {
                    managerSC.GameOver(-1);
                }
                else
                {
                    Turn.SetText("X's turn");
                }
            }
        }
        else
        {
            Boolean tie=false;
            if (moveby == X)
            {
                Board[i, j] = +1;
                if (CheckForWin(1, Board))
                {
                    managerSC.GameOver(1);
                   
                }
                else { tie = true; }
            }
            else if (moveby == O)
            {
                Board[i, j] = -1;
                if (CheckForWin(-1, Board))
                {
                    managerSC.GameOver(-1);
                }
                else
                {
                    tie = true;
                }
            }
            if (tie)
            {
                managerSC.GameOver(0);
            }
        }
        
    }

    public bool CheckForWin(int moveby,int[,] Board)
    {
        if(Board[0,0]==moveby && Board[0,1]==moveby && Board[0, 2] == moveby)
        {
            return true;
        }else if (Board[1, 0] == moveby && Board[1, 1] == moveby && Board[1, 2] == moveby)
        {
            return true;
        }
        else if (Board[2, 0] == moveby && Board[2, 1] == moveby && Board[2, 2] == moveby)
        {
            return true;
        }
        else if (Board[0, 0] == moveby && Board[1, 0] == moveby && Board[2, 0] == moveby)
        {
            return true;
        }
        else if (Board[0, 1] == moveby && Board[1, 1] == moveby && Board[2, 1] == moveby)
        {
            return true;
        }
        else if (Board[0, 2] == moveby && Board[1, 2] == moveby && Board[2, 2] == moveby)
        {
            return true;
        }
        else if (Board[0, 0] == moveby && Board[1, 1] == moveby && Board[2, 2] == moveby)
        {
            return true;
        }
        else if (Board[0, 2] == moveby && Board[1, 1] == moveby && Board[2, 0] == moveby)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public int[,] getBoard()
    {
        return Board;
    }

}
