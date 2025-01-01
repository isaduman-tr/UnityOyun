using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.Build.Content;
using UnityEngine.AI;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    private Player _player;
    public float speed;
    private Rigidbody _rb;
    public NavMeshAgent navMeshAgent;
    private Animator _animator;
    private bool _isWalking;
    public Transform zPrefab;
    private Transform _z1;
    private Transform _z2;

    public void StartEnemy(Player player)
    {
        _player = player;
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
        transform.Rotate(0, Random.Range(-180,180), 0);
        CreateAndAnimateZprefab();
    }

    private void CreateAndAnimateZprefab()
    {
        _z1 = Instantiate(zPrefab);
        _z1.position = transform.position + Vector3.up * 2;
        _z1.localScale = Vector3.zero;
        _z1.DOMoveY(_z1.transform.position.y + 1, 1f).SetEase(Ease.Linear).SetLoops(-1,LoopType.Restart);
        _z1.DOScale(1, 1f).SetLoops(-1,LoopType.Restart);

        _z2 = Instantiate(zPrefab);
        _z2.position = transform.position + Vector3.up * 2;
        _z2.localScale = Vector3.zero;
        _z2.DOMoveY(_z2.transform.position.y + 1, 1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart).SetDelay(.5f);
        _z2.DOScale(1, 1f).SetLoops(-1, LoopType.Restart).SetDelay(.5f);
    }

    private void Update()
    {
        if (_player.ÝsAppleCollected)
        {
            
            navMeshAgent.destination = _player.transform.position;  //ai navigation tarafýndan enemynin playeri takip etmesi
            if (!_isWalking) // booller her zaman false baþlýyor bir sonraki update de içine giremeyecek ders 16 dakika 17
            {
                _isWalking = true;
                _animator.SetTrigger("Walk");
                _z1.DOKill();
                _z2.DOKill();
                Destroy(_z1.gameObject);
                Destroy(_z2.gameObject);
            }
        }
    }
   
    
    public void Stop() 
    {
        
        navMeshAgent.speed = 0; //navmesh ile kapýya gidince eneymnin durmasý
        _animator.SetTrigger("Idle"); // animatordaki ýdle anomasyonunu çalýþtýrýr
    }
}
