using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.Build.Content;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Player _player;
    public float speed;
    private Rigidbody _rb;
    public NavMeshAgent navMeshAgent;
    

    public void StartEnemy(Player player)
    {
        _player = player;
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (_player.�sAppleCollected)
        {
            /* var direction = (_player.transform.position - transform.position).normalized; //Enemynin d��mana do�ru konumlanmas�
            direction.y=0;  
            _rb.position += direction * Time.deltaTime * speed; // Enemy h�z� */
            navMeshAgent.destination = _player.transform.position;  //ai navigation taraf�ndan enemynin playeri takip etmesi
        }
    }
    public void Stop() 
    {
        // speed = 0; //Collactables toplan�nca durmas�
        navMeshAgent.speed = 0; //navmesh ile kap�ya gidince eneymnin durmas�
    }
}
