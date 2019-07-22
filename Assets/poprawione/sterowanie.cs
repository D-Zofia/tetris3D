using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sterowanie : MonoBehaviour
{
    public Vector3 wymiary = new Vector3(9,19,9);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Poruszanie----------------------------------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += new Vector3(1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(0, 0, 1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(0, 0, -1);
        }
        //Rotacja-------------------------------------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.Z))
        {
            transform.Rotate(0, 0, 90, Space.World);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            transform.Rotate(90, 0, 0, Space.World);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            transform.Rotate(0, 90, 0, Space.World);
        }

        Repair_poz();
    }

    bool PozaMapa()
    {
        foreach(Transform cube in transform)
        {
            if (cube.position.x<0||cube.position.x>wymiary.x||cube.position.z < 0 || cube.position.z > wymiary.z||cube.position.y<0)
            {
                return true;
            }
        }
        return false;
    }

    void Repair_poz()
    {
        foreach (Transform cube in transform)
        {
            while (PozaMapa())
            {
                if (cube.position.x < 0)
                {
                    transform.position += new Vector3(1, 0, 0);
                }
                if (cube.position.x > wymiary.x)
                {
                    transform.position += new Vector3(-1, 0, 0);
                }
                if (cube.position.z < 0)
                {
                    transform.position += new Vector3(0, 0, 1);
                }
                if (cube.position.z > wymiary.z)
                {
                    transform.position += new Vector3(0, 0, -1);
                }
            }
        }
    }

}
