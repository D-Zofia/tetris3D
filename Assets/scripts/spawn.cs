using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject[] blocks;


    void Start()
    {
        NewBlock();
    }

    public void NewBlock()
    {
        Instantiate(blocks[Random.Range(0,blocks.Length)],transform.position,Quaternion.identity);
    }
}
