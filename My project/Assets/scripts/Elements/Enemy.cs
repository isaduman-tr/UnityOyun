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
    private Animator _animator;
    private bool _isWalking;
    

    public void StartEnemy(Player player)
    {
        _player = player;
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
        transform.Rotate(0, Random.Range(-180,180), 0);
    }
    private void Update()
    {
        if (_player.�sAppleCollected)
        {
            
            navMeshAgent.destination = _player.transform.position;  //ai navigation taraf�ndan enemynin playeri takip etmesi
            if (!_isWalking) // booller her zaman false ba�l�yor bir sonraki update de i�ine giremeyecek ders 16 dakika 17
            {
                _isWalking = true;
                _animator.SetTrigger("Walk");
            }
        }
    }
    public void Stop() 
    {
        navMeshAgent.speed = 0; //navmesh ile kap�ya gidince eneymnin durmas�
        _animator.SetTrigger("Idle"); // animatordaki �dle anomasyonunu �al��t�r�r
    }
}
