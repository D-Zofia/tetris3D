using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_control : MonoBehaviour
{
    public float speed=200;
    public float odleglosc=32;
    public float wysokosc=28;

    float angle=40;
    float pi = 3.1416f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(4.5f, 10, 4.5f));
        if (Input.GetKey(KeyCode.A))
        {
            angle += Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            angle -= Time.deltaTime * speed;
        }
        transform.position =new Vector3(Mathf.Sin(angle*pi/180),wysokosc/odleglosc,Mathf.Cos(angle*pi/180))*odleglosc+new Vector3(4.5f,0,4.5f);
    }
}
