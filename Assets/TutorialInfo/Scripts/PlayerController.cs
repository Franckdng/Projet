using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    public float speed = 0.0f;
    public float turnspeed;
    public float horizontalinput;
    public float verticalinput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalinput = Input.GetAxis("Horizontal");
        verticalinput = Input.GetAxis("Vertical");
        if (verticalinput == 1 && speed < 70) { speed += 10 * Time.deltaTime; };
        if (verticalinput == -1 && speed > -70) { speed -= 10 * Time.deltaTime; };
        if (verticalinput < 0.7 && speed > 0) { speed-= 30 * Time.deltaTime; };
        if (verticalinput > -0.7 && speed < 0) { speed += 30 * Time.deltaTime; };
        if (speed < 0.07 && speed > -0.07   ) { speed = 0; };
        if ((horizontalinput == -1 || horizontalinput == 1) && turnspeed < 50) { turnspeed += speed*Time.deltaTime; }
        if (horizontalinput != -1 && horizontalinput != 1 && turnspeed > 30) { turnspeed -= speed * Time.deltaTime; }
        //transform.Translate(Vector3.right * Time.deltaTime * turnspeed * horizontalinput);
        if (speed != 0)
        {
            //move forward
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.Rotate(Vector3.up * Time.deltaTime * turnspeed * horizontalinput);
        }
    }
}
