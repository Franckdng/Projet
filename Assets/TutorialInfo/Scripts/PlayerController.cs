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
    public bool ausol;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    public float distancesol = 0.1f;
=======
=======
>>>>>>> Stashed changes
    public bool mur;
    public float distancesol = 0.2f;
    public Rigidbody rb;
>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        ausol = Physics.Raycast(transform.position + Vector3.up*0.1f, Vector3.down, distancesol);
        
        horizontalinput = Input.GetAxis("Horizontal");
        verticalinput = Input.GetAxis("Vertical");
        
=======
        /*   
           ausol = Physics.Raycast(transform.position + Vector3.up*0.1f, Vector3.down, distancesol);

           horizontalinput = button.b;
           verticalinput = button.a;

           if (ausol)
           {
           if (verticalinput == 1 && speed < 70) { speed += 10 * Time.deltaTime; };
           if (verticalinput == -1 && speed > -70 && speed <0) { speed -= 10 * Time.deltaTime; };
           if (verticalinput == -1 && speed > 0) { speed -= 20 * Time.deltaTime; }
           if (verticalinput < 0.7 && speed > 0) { speed-= 20 * Time.deltaTime; };
           if (verticalinput > -0.7 && speed < 0) { speed += 20 * Time.deltaTime; };
           }
           else
           {
               if(speed > 0 ) { speed -= 20 * Time.deltaTime; };
               if (speed < 0) {speed += 20 * Time.deltaTime;
           }

           }

           //if (speed < 0.07 && speed > -0.07   ) { speed = 0; };
           if(verticalinput < -0.4 && speed>0 && ausol) { turnspeed = 100; }
           else turnspeed = speed;
           if (turnspeed <30) turnspeed = 30;
           //if (horizontalinput != -1 && turnspeed > 100) { turnspeed -= 70 * Time.deltaTime; }
           //if ((horizontalinput == -1 || horizontalinput == 1) && turnspeed < 80) { turnspeed += speed*Time.deltaTime; }
           //if (horizontalinput != -1 && horizontalinput != 1 && turnspeed > 30) { turnspeed -= speed * Time.deltaTime; }
           //transform.Translate(Vector3.right * Time.deltaTime * turnspeed * horizontalinput);



           if (speed > 0.07 || speed < -0.07)
           {
               //move forward
               transform.Translate(Vector3.forward * Time.deltaTime * speed);
               transform.Rotate(Vector3.up * Time.deltaTime * turnspeed * horizontalinput);
           }
           else
           {
               transform.Translate(0,0,0);
           }
           */


        
        
        // Vérification si la voiture est au sol
        ausol = Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, distancesol);

        // Obtenir les entrées

        horizontalinput = button.b;
        verticalinput = button.a;

        //horizontalinput = Input.GetAxis("Horizontal");
        //verticalinput = Input.GetAxis("Vertical");

        // Accélération et décélération
>>>>>>> Stashed changes
        if (ausol)
        {
        if (verticalinput == 1 && speed < 70) { speed += 10 * Time.deltaTime; };
        if (verticalinput == -1 && speed > -70 && speed <0) { speed -= 10 * Time.deltaTime; };
        if (verticalinput == -1 && speed > 0) { speed -= 20 * Time.deltaTime; }
        if (verticalinput < 0.7 && speed > 0) { speed-= 20 * Time.deltaTime; };
        if (verticalinput > -0.7 && speed < 0) { speed += 20 * Time.deltaTime; };
        }
        else
        {
            if(speed > 0 ) { speed -= 20 * Time.deltaTime; };
            if (speed < 0) {speed += 20 * Time.deltaTime;
        }
       

        }

<<<<<<< Updated upstream
        //if (speed < 0.07 && speed > -0.07   ) { speed = 0; };
        if(verticalinput < -0.4 && speed>0 && ausol) { turnspeed = 100; }
        else turnspeed = speed;
        if (turnspeed <30) turnspeed = 30;
        //if (horizontalinput != -1 && turnspeed > 100) { turnspeed -= 70 * Time.deltaTime; }
        //if ((horizontalinput == -1 || horizontalinput == 1) && turnspeed < 80) { turnspeed += speed*Time.deltaTime; }
        //if (horizontalinput != -1 && horizontalinput != 1 && turnspeed > 30) { turnspeed -= speed * Time.deltaTime; }
        //transform.Translate(Vector3.right * Time.deltaTime * turnspeed * horizontalinput);
=======

    }
>>>>>>> Stashed changes



        if (speed > 0.07 || speed < -0.07)
        {
            //move forward
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.Rotate(Vector3.up * Time.deltaTime * turnspeed * horizontalinput);
        }
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        
    }
=======
=======
>>>>>>> Stashed changes
        else { transform.Translate(0, 0, 0); }
        // Rotation uniquement si la voiture bouge
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall") // Si c'est un mur
        {
            mur = true;
            speed = 0;
            rb.velocity = Vector3.zero; // Stoppe immédiatement la vitesse
            rb.angularVelocity = Vector3.zero; // Stoppe la rotation
        }
        else mur = false;
    }

>>>>>>> Stashed changes
}
