using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Transform planet;
    public int solarRotation;
    public int rotation;
    public GameObject center;
    public bool isMoon = false;

    void Start()
    {
        planet = GetComponent<Transform>();
        center = GameObject.Find("Sun Sphere");
    }

    
    void Update()
    {
        transform.RotateAround(planet.transform.position, planet.transform.up, rotation * Time.deltaTime);

        if (isMoon) 
        {
            center = GameObject.Find("Earth");
            transform.RotateAround(center.transform.position, planet.transform.up, solarRotation / 1.5f * Time.deltaTime);
        } else
        {
            transform.RotateAround(center.transform.position, planet.transform.up, solarRotation * Time.deltaTime);
        }
    }
}
