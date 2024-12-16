using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.Build.Content;

public class Enemy : MonoBehaviour
{
   public Player player;
    public float speed;

    private void Update()
    {
        if (player.�sAppleCollected)
        {
            var direction = (player.transform.position - transform.position).normalized; //Enemynin d��mana do�ru konumlanmas�
            transform.position += direction * Time.deltaTime * speed; // Enemy h�z�
        }
    }
}
