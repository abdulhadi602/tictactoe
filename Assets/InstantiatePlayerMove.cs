using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
     private GameObject X,O;
     private bool isSet;
     private static GameObject lastMove;
     private GameObject logicObj;
     private Logic logicSC;
     void Start()
    {
        logicObj = GameObject.FindGameObjectWithTag("Logic");
        logicSC = logicObj.GetComponent<Logic>();
        X = Resources.Load("Prefabs/X") as GameObject;
        O = Resources.Load("Prefabs/O") as GameObject;
        isSet = false;
        lastMove = null;
    }
    public void CreateX()
    {
        if (!isSet)
        {
            if (lastMove == null)
            {
                GameObject.Instantiate(X, transform.position, Quaternion.identity);
                lastMove = X;

            }
            else
            {
                if(lastMove == X)
                {
                    GameObject.Instantiate(O, transform.position, Quaternion.identity);
                    lastMove = O;
                }
                else
                {
                    GameObject.Instantiate(X, transform.position, Quaternion.identity);
                    lastMove = X;
                }
            }
            isSet = true;
            if (gameObject.tag.Equals("0"))
            {
                logicSC.Move(lastMove, 0, 0);
            }else if (gameObject.tag.Equals("1"))
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
}
