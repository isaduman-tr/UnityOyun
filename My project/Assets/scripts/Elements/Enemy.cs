using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.Build.Content;

public class Enemy : MonoBehaviour
{
    private Player _player;
    public float speed;

    

    public void StartEnemy(Player player)
    {
        _player = player;
    }
    private void Update()
    {
        if (_player.ÝsAppleCollected)
        {
            var direction = (_player.transform.position - transform.position).normalized; //Enemynin düþmana doðru konumlanmasý
            transform.position += direction * Time.deltaTime * speed; // Enemy hýzý
        }
    }
    public void Stop() 
    {
        speed = 0; //Collactables toplanýnca durmasý
    }
}
