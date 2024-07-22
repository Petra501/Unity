using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CubeController : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    public GameObject otherCoin;
    public Rigidbody rb;
    public Material original;
    public Material change;
    public int counter = 0;
    public float speed;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        otherCoin = GameObject.Find("Coin2");
        otherCoin.SetActive(false);
    }

    void Update()
    {

        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.AddForce(new Vector3(Input.GetAxis("Horizontal") * speed, 0, 0));
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            rb.AddForce(new Vector3(Input.GetAxis("Horizontal") * speed, 0, 0));
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Coin")
        {
            counter++;
            otherCoin.SetActive(true);
            audioSource.PlayOneShot(audioClip);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "NearBox")
        {
            other.transform.parent.GetComponent<Renderer>().material = change;
        
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "NearBox")
        {
            other.transform.parent.GetComponent<Renderer>().material = original;
        }

    }
}
