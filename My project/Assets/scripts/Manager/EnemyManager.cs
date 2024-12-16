using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.Build.Content;

public class EnemyManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<Enemy> enemies;

    public void StopEnemies()
    {
        foreach (var e in enemies)
        {

            e.Stop(); //Collactebleslarý kapýya götürünce enemy durmasý

        }
    }
}
