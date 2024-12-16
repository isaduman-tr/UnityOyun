using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.Build.Content;


public class Player : MonoBehaviour
{
    private Rigidbody _rb;
    public float speed =2;
    public bool ÝsAppleCollected;
    public GameDirector gameDirector;
    
    void Start()
    {
        _rb =GetComponent<Rigidbody>();//unity rigidbodysini getirir
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
           gameObject.SetActive(false);//Player Enemye dokununca Player yok olsun komutu


        }
        if (other.CompareTag("Collactable"))
        {
            other.gameObject.SetActive(false);
            gameDirector.levelManager.AppleCollected();
            ÝsAppleCollected = true; //Player collactable toplarsa collactable yok olsun

        }
        if (other.CompareTag("Door") && ÝsAppleCollected )
        {
            gameDirector.LevelCompleted(); //Collacterlarý toplayýnca gamedirector.cs deki komutu çaðýran komut
            
        }
    }


    void Update()
    {
        //kutu hýzý kod alaný
        var direction =Vector3.zero;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 5;

        }
        else
        {
            speed = 2;
        }

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;

        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;

        }
        //normalized iki tuþa basýnca vektör hýzlarýný eþitliyor
        _rb.linearVelocity = direction.normalized * speed;

       

    }
}
