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
    public Vector2 enemyCount;

    public void RestartEnemyManager()
    {
        DeleteEnemies(); //R ye basýnca eskileri siler 
        GenerateEnemies(); //Oyun baþlayýnca düþmanýn ortaya çýkmasý

    }

    private void GenerateEnemies()
    {
        var randomEnemyCount = UnityEngine.Random.Range(enemyCount.x,enemyCount.y);//Enemy sayýlarýnýn rastgele verilmesi
        for (int i = 0; i < randomEnemyCount; i++)
        {
            
            var enemyXPos = UnityEngine.Random.Range(-2.5f, 2.5f);
            var newEnemy = Instantiate(enemyPrefab); //Prefab nesneyi tanýmlama
            newEnemy.transform.position = new Vector3(enemyXPos, 0, 2 + i * 1.5f); // Prefab nesnenin konumu
            enemies.Add(newEnemy); //oyundaki enemies listesine enemy eklenmesi
            newEnemy.StartEnemy(player); //Collactable toplanýnca listedeki Enemy nin düþmana doðru hareketi



        }

    }

    private void DeleteEnemies() // R ye basýnca enemieslerin silinmesi
    {
        foreach (var e in enemies) 
        { 
            Destroy(e.gameObject);
        }
        enemies.Clear();// R ye basýnca listeye yeni enemiesler ekleniyor onlarý siler
    }

    public void StopEnemies()
    {
        foreach (var e in enemies)
        {

            e.Stop(); //Collactebleslarý kapýya götürünce enemy durmasý

        }
    }
}
