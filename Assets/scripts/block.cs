using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    public float move_time = 0.8f;
    public Vector3 size = new Vector3(9, 19, 9);

    private static bool[,,] grid = new bool[9, 20, 9];

    float timer;
    //--------------------------------------------------------------------------------------------

    void Start()
    {
        timer = move_time;
        //for (int i = 0; i< 20; i++)
        //{
        //    for(int j = 0; j< 9; j++)
        //    {
        //        for (int k = 0; k< 9; k++)
        //        {
        //            grid[j, i, k] = false;
        //        }
        //    }
        //}
    }


    void Update()
    {
        //Opadanie------------------------------------------------------------------------------------
        timer -= Input.GetKey(KeyCode.Space)?Time.deltaTime*20: Time.deltaTime;
        if (timer < 0)
        {
            timer = move_time;
            transform.position += new Vector3(0, -1, 0);
            if (!Valid_move())
            {
                transform.position -= new Vector3(0, -1, 0);
                AddToGrid();
                FindObjectOfType<spawn>().NewBlock();
                this.enabled = false;
            }
        }
        //Poruszanie----------------------------------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!Valid_move()) transform.position -= new Vector3(1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!Valid_move()) transform.position -= new Vector3(-1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(0, 0, 1);
            if (!Valid_move()) transform.position -= new Vector3(0, 0, 1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(0, 0, -1);
            if (!Valid_move()) transform.position -= new Vector3(0, 0, -1);
        }

        //Rotacja-------------------------------------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.Z))
        {
            transform.Rotate(0, 0, 90, Space.World);
            Repair_pos();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            transform.Rotate(90, 0, 0, Space.World);
            Repair_pos();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            transform.Rotate(0, 90, 0, Space.World);
            Repair_pos();
        }
    }

    bool Valid_move()
    {
        foreach (Transform children in transform)
        {
            Debug.Log(children.position);
            if (children.position.x < -0.001f || children.position.x > size.x || children.position.z < -0.001f || children.position.z > size.z || children.position.y < -0.001f)
            {
                return false;
            }

            if (grid[(int)(children.position.x - 0.001f), (int)(children.position.y), (int)(children.position.z - 0.001f)])
            {
                return false;
            }
        }
        return true;
    }


    void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            grid[(int)(children.position.x-0.001f), (int)(children.position.y - 0.001f), (int)(children.position.z - 0.001f)] = true;
        }
    }

    private void Repair_pos()
    {
        while (!Valid_move())
        {
            foreach (Transform children in transform)
            {
                if (children.position.x < -0.001)
                {
                    transform.position += new Vector3(1, 0, 0);
                }
                if (children.position.x > size.x)
                {
                    transform.position += new Vector3(-1, 0, 0);
                }
                if (children.position.z < -0.001)
                {
                    transform.position += new Vector3(0, 0, 1);
                }
                if (children.position.z > size.z)
                {
                    transform.position += new Vector3(0, 0, -1);
                }
                if (children.position.y < -0.001)
                {
                    transform.position += new Vector3(0, 1, 0);
                }
            }
        }
    }


}
