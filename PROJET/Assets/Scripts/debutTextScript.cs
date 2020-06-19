using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class debutTextScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().color = Color.blue;
        GetComponent<Text>().text = "PRESS ENTER TO START!";
    }

    // Update is called once per frame
    void Update()
    {
        if(Bird.gameStart == true)
        {
            GetComponent<Text>().text = " ";

            if (Bird.perduStatu == true)
            {
                GetComponent<Text>().color = Color.red;
                GetComponent<Text>().text = "GAME OVER\nPRESS ENTER TO RESTART";
                      

            }
            if(Bird.win == true)
            {
                GetComponent<Text>().color = Color.green;
                GetComponent<Text>().text = "TU AS GAGNÉ BG !!! \n\nCRÉDITS:\nDaphné Designer\nPierre codeur a ses \n heures perdues ;-)\n#BonneBlague";
            }
            if(Bird.pause == true)
            {
                GetComponent<Text>().color = Color.black;
                GetComponent<Text>().text = "PAUSE";
            }
        }

    }
}
