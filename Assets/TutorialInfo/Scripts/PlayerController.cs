using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public control button;
    public SteeringWheel wheel;
    public float speed = 0.0f;
    public float turnspeed;
    public float horizontalinput;
    public float verticalinput;
    public bool ausol;
    public float distancesol = 0.1f;
    public bool mur;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Vérification si la voiture est au sol
        ausol = Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, distancesol);

        // Obtenir les entrées

        horizontalinput = wheel.GetClampedValue();
        verticalinput = button.a;

        // Accélération et décélération
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
            if(speed > 0 ) { speed -= 20 * Time.deltaTime; }
            if (speed < 0) {speed += 20 * Time.deltaTime;}
        }
        if(verticalinput < -0.4 && speed>0 && ausol) { turnspeed = 100; }
        else turnspeed = speed;
        if (turnspeed <30) turnspeed = 30;
    }

    void FixedUpdate()
    {
        // Déplacement physique basé sur la vitesse
        if (Mathf.Abs(speed) > 0.1f) // Déplacement seulement si la voiture a une vitesse
        {
            Vector3 forwardMovement = transform.forward * speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + forwardMovement);

            // Rotation fluide
            float rotation = horizontalinput * turnspeed * Time.fixedDeltaTime;
            Quaternion turnOffset = Quaternion.Euler(0, rotation, 0);
            rb.MoveRotation(rb.rotation * turnOffset);
        }
        else
        {
            // Si la vitesse est proche de zéro, arrêter complètement le Rigidbody
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    
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
}
