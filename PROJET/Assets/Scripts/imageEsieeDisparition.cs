using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imageEsieeDisparition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Bird.gameStart == true)
        {
            this.gameObject.SetActive(false);

        }
    }
}
