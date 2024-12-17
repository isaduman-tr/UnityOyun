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
    public bool İsAppleCollected;
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
            İsAppleCollected = true; //Player collactable toplarsa collactable yok olsun

        }
        if (other.CompareTag("Door") && İsAppleCollected )
        {
            gameDirector.LevelCompleted(); //Collacterları toplayınca gamedirector.cs deki komutu çağıran komut
            
        }
    }


    void Update()
    {
        //kutu hızı kod alanı
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
        //normalized iki tuşa basınca vektör hızlarını eşitliyor
        _rb.linearVelocity = direction.normalized * speed;

       

    }
}
