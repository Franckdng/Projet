using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    public int a;
    public int b;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void avancer()
    {
        a = 1;
    }
    public void reculer()
    {
        a = -1;
    }
    public void stop()
    {
        a = 0;
    }
    public void droite()
    {
        b = 1;
    }
    public void gauche()
    {
        b = -1;
    }
    public void stopt()
    {
        b = 0;
    }
}