using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.Build.Content;
using System;

public class EnemyManager : MonoBehaviour
{
    public Player player;
    public Enemy enemyPrefab;
    public List<Enemy> enemies;
    public int enemyCount;

    public void RestartEnemyManager()
    {
        DeleteEnemies(); 
        GenerateEnemies(); //Oyun baþlayýnca düþmanýn ortaya çýkmasý

    }

    private void GenerateEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            
            var enemyXPos = 0f;
            enemyXPos = UnityEngine.Random.Range(-2.5f, 2.5f);
            var newEnemy = Instantiate(enemyPrefab); //Prefab nesneyi tanýmlama
            newEnemy.transform.position = new Vector3(enemyXPos, 0, 3 + i * 1.5f); // Prefab nesnenin konumu
            enemies.Add(newEnemy); //oyundaki enemies listesine enemy eklenmesi
            newEnemy.StartEnemy(player); //Collactable toplanýnca listedeki Enemy nin düþmana doðru hareketi



        }

    }

    private void DeleteEnemies()
    {

    }

    public void StopEnemies()
    {
        foreach (var e in enemies)
        {

            e.Stop(); //Collactebleslarý kapýya götürünce enemy durmasý

        }
    }
}
