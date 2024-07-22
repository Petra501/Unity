using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class PlayerController : MonoBehaviour
{
    public Animator PlayerAnimator;
    public GameObject liftingObject;
    public string tag;
    public AudioSource audioSource;

    public bool hold = false;


    // Start is called before the first frame update
    void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
        PlayerAnimator.SetBool("isStand", true);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward * 2, Color.red, 0.1f);
        Ray ray = new Ray(gameObject.transform.position, gameObject.transform.forward * 2);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 2f))
        {
            liftingObject = hit.transform.gameObject;
            tag = hit.transform.tag;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            PlayerAnimator.SetBool("isRun", true);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            PlayerAnimator.SetBool("isRun", false);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerAnimator.SetBool("isWalkBack", true);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            PlayerAnimator.SetBool("isWalkBack", false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerAnimator.SetBool("isLifting", true);
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            PlayerAnimator.SetBool("isLifting", false);
        }
    }

    void Lift()
    {
        if (liftingObject != null && hold == false)
        {
            liftingObject.transform.parent = GameObject.Find("mixamorig:RightHandIndex4").transform;
            liftingObject.transform.position = GameObject.Find("mixamorig:RightHandIndex4").transform.position;
            hold = true;
            return;
        }

        if (liftingObject != null && hold == true)
        {
            liftingObject.transform.parent = null;
            hold = false;
            return;
        }

    }

    void WalkSound()
    {
        audioSource.Play();
    }
}
