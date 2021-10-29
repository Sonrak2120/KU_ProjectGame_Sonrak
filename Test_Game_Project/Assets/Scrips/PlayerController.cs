using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    public float rotspeed = 10f;
    float newRoty = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float newX = transform.position.x;
        float newY = transform.position.y;
        float newZ = transform.position.z;

        if (Input.GetKey(KeyCode.DownArrow))
        { 
            newX = transform.position.x + speed * Time.deltaTime;
            newRoty = 0;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            newX = transform.position.x - speed * Time.deltaTime;
            newRoty = -180;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            newZ = transform.position.z + speed * Time.deltaTime;
            newRoty = -90;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newZ = transform.position.z - speed * Time.deltaTime;
            newRoty = 90;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            newY = transform.position.y + 20f * Time.deltaTime;
        }


        transform.position = new Vector3(newX, newY,newZ);
        //transform.position = Quaternion.Euler(0, newRoty, 0);
        transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, newRoty, 0),transform.rotation,rotspeed*Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if(collision.gameObject.name=="Sphere")
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
    }
}
