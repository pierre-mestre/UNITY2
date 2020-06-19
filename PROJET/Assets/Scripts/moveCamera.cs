using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{

    // Start is called before the first frame update
    int inside = 0;
    float initRotationX = 0;
    float initRotationY = 0;
    float initRotationZ = 0;
    void Start()
    {
         this.initRotationX = this.transform.rotation.x;
         this.initRotationY = this.transform.rotation.y;
         this.initRotationZ = this.transform.rotation.z;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if(inside == 0) //move to backFisrtPerson
            {
                this.transform.rotation = Quaternion.Euler(this.initRotationX, this.initRotationY, this.initRotationZ);
                this.transform.rotation = Quaternion.Euler(this.initRotationX+10, this.initRotationY, this.initRotationZ);
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 80, this.transform.position.z - 250);
                
                inside = 1;
            }
            else if(inside == 1) // moveTo2D
            {
                this.transform.rotation = Quaternion.Euler(this.initRotationX, this.initRotationY, this.initRotationZ);
                this.transform.position = new Vector3(this.transform.position.x+1500, this.transform.position.y, this.transform.position.z+750);
                this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y - 90, this.transform.rotation.z );
                inside = 2;
            }
            else if (inside == 2)//moveTo1stPerson
            {
               
                this.transform.position = new Vector3(this.transform.position.x - 1500, this.transform.position.y, this.transform.position.z - 750);
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 80, this.transform.position.z + 250);
                this.transform.rotation = Quaternion.Euler(this.initRotationX, this.initRotationY, this.initRotationZ);
                inside = 0;
            }
           

        }
    }
}
