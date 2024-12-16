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
        if (player.ÝsAppleCollected)
        {
            var direction = (player.transform.position - transform.position).normalized; //Enemynin düþmana doðru konumlanmasý
            transform.position += direction * Time.deltaTime * speed; // Enemy hýzý
        }
    }
}
