using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //variables du fichier
    public control button;
    public SteeringWheel wheel;
    public Rigidbody rb;
    public float speed = 0.0f;
    public float turnspeed;
    public float horizontalinput;
    public float verticalinput;
    public float distancesol = 0.1f;
    public int nbobjejected;
    public bool ausol;
    public bool mur;



    void Start()
    {
        
    }

    void Update()
    {
        //On verifie la distance entre la voiture et le sol pour etre sur qu'elle ne soit pas en l'air
        ausol = Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, distancesol);

        //On recupere les entrees des pedales et du volant
        horizontalinput = wheel.GetClampedValue();
        verticalinput = button.a;

        //Si on est au sol alors on applique les deplacements
        if (ausol)
        {
            //acceleration
            if (verticalinput == 1 && speed < 70) { speed += 10 * Time.deltaTime; };
            //acceleration marche arriere
            if (verticalinput == -1 && speed > -70 && speed <0) { speed -= 10 * Time.deltaTime; };
            //frein
            if (verticalinput == -1 && speed > 0) { speed -= 20 * Time.deltaTime; }
            //arret de la voiture su aucun boutton pressé (frein moteur)
            if (verticalinput < 0.7 && speed > 0) { speed-= 20 * Time.deltaTime; };
            if (verticalinput > -0.7 && speed < 0) { speed += 20 * Time.deltaTime; };
        }
        else
        {
            //arret de la voiture si elle est en l'air
            if (speed > 0 ) { speed -= 20 * Time.deltaTime; }
            if (speed < 0) {speed += 20 * Time.deltaTime;}
        }
        //on augmente drastiquement la vitesse de rotation si l'on appuis sur la pedale de frein afin de simuler un drift
        if(verticalinput < -0.4 && speed>0 && ausol) { turnspeed = 100; }
        //vitesse de rotation qui varie entre 30 et vitesse max (ici 70)
        else turnspeed = speed;
        if (turnspeed <30) turnspeed = 30;
    }

    void FixedUpdate()
    {
        //la voiture se deplace seulement si elle a une vitesse
        if (Mathf.Abs(speed) > 0.1f)
        {
            //on initialise un vecteur vitees pour notre voiture
            Vector3 forwardMovement = transform.forward * speed * Time.fixedDeltaTime;
            //on applique ce vecteur a notre rigidbody afin de deplacer la voiture 
            rb.MovePosition(rb.position + forwardMovement);

            //on initialise une variable de rotation ainsi qu'un quatrnion pour notre voiture
            float rotation = horizontalinput * turnspeed * Time.fixedDeltaTime;
            Quaternion turnOffset = Quaternion.Euler(0, rotation, 0);
            //on applique ce quaternion afin de faire tourner notre voiture
            rb.MoveRotation(rb.rotation * turnOffset);
        }
        else
        {
            //si la vitesse de notre voiture est proche de 0 alors on arrete la voiture
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    
    }
void OnCollisionEnter(Collision collision)
    {
        //si on entre en collision avec un mur alors on stop la voiture
        if (collision.gameObject.tag == "Wall") 
        {
            mur = true;
            //on met la vitesse a 0 pour stopper la voiture
            speed = 0;
            //on nulifie la velocite et la rotation de notre vehicule
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        else mur = false;
        //si on entre en collision avec un objet ejectable alors on incremente un compteur
        if (collision.gameObject.tag == "Ejectable")
        {
            //on incremente un compteur pour connaitre le nombre d'objet ejecté
            nbobjejected++;
        }
    }
}
