using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController controller;
    Rigidbody rb;
    [SerializeField] float inicioclickx, fimclickx,inicioclickz,fimclickz, distx, distz;
    int direx, direz;
    [SerializeField] int speed;
    [SerializeField] AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        swipe();
        if(direx != 0 || direz != 0)
        {
            GetComponent<Animation>().CrossFade("andando");
        }
        else
        {
            GetComponent<Animation>().CrossFade("Idle");

        }
    }

    void swipe()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            inicioclickx = Input.mousePosition.x;
            inicioclickz = Input.mousePosition.y;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            fimclickx = Input.mousePosition.x;
            fimclickz = Input.mousePosition.y;
            
            if(inicioclickx > fimclickx)
            {
                direx = -1;
                distx = Mathf.Abs(inicioclickx) - Mathf.Abs(fimclickx);
                
            }
            else if(inicioclickx< fimclickx)
            {
                direx = 1;
                distx = Mathf.Abs(fimclickx) - Mathf.Abs(inicioclickx);
            }else if(inicioclickx == fimclickx)
            {
                direx = 0;
                distx = 0;
            }
            if (inicioclickz > fimclickz)
            {
                direz = -1;
                distz = Mathf.Abs(inicioclickz) - Mathf.Abs(fimclickz);
            }
            else if (inicioclickz < fimclickz)
            {
                direz = 1;
                distz = Mathf.Abs(fimclickz) - Mathf.Abs(inicioclickz);
            }
            else if (inicioclickz == fimclickz)
            {
                direz = 0;
                distz = 0;
            }
        }
        if (distx > distz)
        {
            direz = 0;
        }
        if (distx < distz)
        {
            direx = 0;
        }
        if (distx == distz)
        {
            direz = 0;
            direx = 0;
        }
        if(direx == -1)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
        }
        else if (direx == 1)
        {
            gameObject.transform.eulerAngles = new Vector3(0, -90, 0);
        }
        else if (direz == -1)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (direz == 1)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        }

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(direx*speed, 0.0f, direz*speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "abobora")
        {
            audio.Play();
        }
    }
}
