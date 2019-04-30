using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Move : MonoBehaviour
{
    public float speed = 5;
    public float direction = 25;
    public Material mat;
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Mathf.Cos(Mathf.Deg2Rad*direction), Mathf.Sin(Mathf.Deg2Rad * direction), 0)*Time.deltaTime*speed;
       // mat.color = new Color(Random.value, 0, 0);
        Debug.DrawRay(transform.position - new Vector3(0,0,2), new Vector3(Mathf.Cos(Mathf.Deg2Rad * direction), Mathf.Sin(Mathf.Deg2Rad * direction), 0)- new Vector3(0, 0, 2), Color.red);
    }

    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
        if (Mathf.Abs(col.contacts[0].normal.x) > 0.5)
        {
            direction = 180 - direction + Random.value*50;
        }
        else
            direction = 360 - direction + Random.value * 50;
        
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        transform.Rotate(0, 0, 180);
    }
}
