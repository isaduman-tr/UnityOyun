using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.CompilerServices;


public class box : MonoBehaviour
{
    private Rigidbody _rb;
    public float speed =2;
    void Start()
    {
        _rb =GetComponent<Rigidbody>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
           //gameObject.SetActive(false);
        }
    }


    void Update()
    {
        
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

        //transform.position += direction * speed * Time.deltaTime;

    }
}