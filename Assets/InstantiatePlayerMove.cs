using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InstantiatePlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
     private GameObject X,O;
     private bool isSet;
     private static GameObject lastMove;
     private GameObject logicObj;
     private Logic logicSC;

    private AIcontroller aisc;
    private GameObject AI;

    void Start()
    {
        logicObj = GameObject.FindGameObjectWithTag("Logic");
        logicSC = logicObj.GetComponent<Logic>();

        X = Resources.Load("Prefabs/X") as GameObject;
        O = Resources.Load("Prefabs/O") as GameObject;

        isSet = false;
        lastMove = null;

        AI = GameObject.FindGameObjectWithTag("AI");
        aisc = AI.GetComponent<AIcontroller>();


       
    }
    public void Create()
    {
        if (!isSet)
        {
            if (lastMove == null)
            {
                lastMove = X;
                if (Manager.gametype.Equals(availableModes.Bot))
                {
                    GameObject obj = aisc.Calculatenextmove();
                    if(obj != null)
                    {
                        Instantiate(X, obj.transform.position, Quaternion.identity);
                        obj.GetComponent<InstantiatePlayerMove>().MovePiece();
                    }
                }
                else
                {
                    GameObject.Instantiate(X, transform.position, Quaternion.identity);
                    MovePiece();            
                }
               
            }
            else
            {
                if(lastMove == X)
                {

                    GameObject.Instantiate(O, transform.position, Quaternion.identity);
                    lastMove = O;
                    MovePiece();
                    
                    if (Manager.gametype.Equals(availableModes.Bot))
                    {
                        lastMove = X;
                        GameObject obj = aisc.Calculatenextmove();
                        if (obj != null)
                        {
                            Instantiate(X, obj.transform.position, Quaternion.identity);
                            obj.GetComponent<InstantiatePlayerMove>().MovePiece();
                        }
                    }
                }
                else
                {
                    lastMove = X;
                  
                        GameObject.Instantiate(X, transform.position, Quaternion.identity);
                        MovePiece();                                           
                    
                    
                }
            }          
        }
    }
    public void MovePiece()
    {
        isSet = true;
        if (gameObject.tag.Equals("0"))
        {
            logicSC.Move(lastMove, 0, 0);
        }
        else if (gameObject.tag.Equals("1"))
        {
            logicSC.Move(lastMove, 0, 1);
        }
        else if (gameObject.tag.Equals("2"))
        {
            logicSC.Move(lastMove, 0, 2);
        }
        else if (gameObject.tag.Equals("3"))
        {
            logicSC.Move(lastMove, 1, 0);
        }
        else if (gameObject.tag.Equals("4"))
        {
            logicSC.Move(lastMove, 1, 1);
        }
        else if (gameObject.tag.Equals("5"))
        {
            logicSC.Move(lastMove, 1, 2);
        }
        else if (gameObject.tag.Equals("6"))
        {
            logicSC.Move(lastMove, 2, 0);
        }
        else if (gameObject.tag.Equals("7"))
        {
            logicSC.Move(lastMove, 2, 1);
        }
        else if (gameObject.tag.Equals("8"))
        {
            logicSC.Move(lastMove, 2, 2);
        }
     
    }
}
