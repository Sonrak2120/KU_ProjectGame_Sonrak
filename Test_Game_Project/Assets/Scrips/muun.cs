using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muun : MonoBehaviour
{
    float horizontalSpeed = 2.0f;
    float verticalSpeed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the mouse delta. This is not in the range -1...1
        float h = horizontalSpeed * 0.02f; //Input.GetAxis("Mouse X");
        float v = verticalSpeed * 0f;//Input.GetAxis("Mouse Y");

        transform.Rotate(v, h, 0);
    }
}
