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
        if (_player.ÝsAppleCollected)
        {
            /* var direction = (_player.transform.position - transform.position).normalized; //Enemynin düþmana doðru konumlanmasý
            direction.y=0;  
            _rb.position += direction * Time.deltaTime * speed; // Enemy hýzý */
            navMeshAgent.destination = _player.transform.position;  //ai navigation tarafýndan enemynin playeri takip etmesi
        }
    }
    public void Stop() 
    {
        // speed = 0; //Collactables toplanýnca durmasý
        navMeshAgent.speed = 0; //navmesh ile kapýya gidince eneymnin durmasý
    }
}
