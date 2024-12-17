using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.Build.Content;



public class GameDirector : MonoBehaviour
{
   
    [Header("Managers")]
    public EnemyManager enemyManager;
    public LevelManager levelManager;
    public void Start()
    {
        RestartLevel();

    }

    private void RestartLevel()
    {
        levelManager.RestartLevel();
        enemyManager.RestartEnemyManager();
    }

    public void LevelCompleted()
    {
        enemyManager.StopEnemies();   
    }
}
