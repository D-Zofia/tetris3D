using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    public float move_time = 0.8f;
    public Vector3 size = new Vector3(9, 19, 9);

    private static Transform[,,] grid = new Transform[9, 19, 9];

    float timer;
    //--------------------------------------------------------------------------------------------

    void Start()
    {
        timer = move_time;
    }


    void Update()
    {
        //Opadanie------------------------------------------------------------------------------------
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = move_time;
            if (!NaDole()) {
                transform.position += new Vector3(0, -1, 0);
            }
            else
            {
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
            if (children.position.x < 0 || children.position.x > size.x || children.position.z < 0 || children.position.z > size.z)// || children.position.y < 0)
            {
                Debug.Log(children);
                return false;
            }
            if (children.position.y < 0)
            {
                Debug.Log(children);
                return false;
            }
            //if (grid[Mathf.RoundToInt(children.position.x), Mathf.RoundToInt(children.position.y), Mathf.RoundToInt(children.position.z)] != null)
            //{
            //    return false;
            //}
        }
        return true;
    }


    void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            grid[Mathf.RoundToInt(children.position.x), Mathf.RoundToInt(children.position.y), Mathf.RoundToInt(children.position.z)] = children;
        }
    }

    private void Repair_pos()
    {
        while (!Valid_move())
        {
            foreach (Transform children in transform)
            {
                if (children.position.x < 0.0)
                {
                    transform.position += new Vector3(1, 0, 0);
                }
                if (children.position.x > size.x)
                {
                    transform.position += new Vector3(-1, 0, 0);
                }
                if (children.position.z < 0.0)
                {
                    transform.position += new Vector3(0, 0, 1);
                }
                if (children.position.z > size.z)
                {
                    transform.position += new Vector3(0, 0, -1);
                }
                if (children.position.y < 0)
                {
                    transform.position += new Vector3(0, 1, 0);
                }
            }
        }
    }

    bool NaDole()
    {
        foreach (Transform children in transform)
        {
            if (children.position.y <= 0)
            {
                Debug.Log("Podloga");
                return true;
            }
        }
        return false;
    }
}
