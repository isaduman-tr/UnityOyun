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
    public bool �sAppleCollected;
    public GameDirector gameDirector;
    
    
    
    
    public void RestartPlayer()
    {
        gameObject.SetActive(true); //Oyuncu Enemye dokunduktan sonra restart edildi�inde tekrar g�ster
        _rb = GetComponent<Rigidbody>();//unity rigidbodysini getirir
        _rb.position = Vector3.zero;// her restarta player konumunu s�f�ra getir
        �sAppleCollected = false; // Collactable toplan�p r ye bas�nca enemyleri durdur
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Collactable"))
        {
            other.gameObject.SetActive(false);
            gameDirector.levelManager.AppleCollected();
            �sAppleCollected = true; //Player collactable toplarsa collactable yok olsun

        }
        if (other.CompareTag("Door") && �sAppleCollected )
        {
            gameDirector.LevelCompleted(); //Collacterlar� toplay�nca gamedirector.cs deki komutu �a��ran komut
            
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);//Player Enemye dokununca Player yok olsun komutu


        }
    }


    void Update()
    {
        //kutu h�z� kod alan�
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
        //normalized iki tu�a bas�nca vekt�r h�zlar�n� e�itliyor
        _rb.linearVelocity = direction.normalized * speed;

       

    }
}
