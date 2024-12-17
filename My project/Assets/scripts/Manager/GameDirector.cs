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

    public Player player;
    public void Start()
    {
        RestartLevel();

    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // R ye basýnca level restartlanýr
        {
            RestartLevel();
        }
    }
    private void RestartLevel()
    {
        levelManager.RestartLevel();
        enemyManager.RestartEnemyManager();
        player.RestartPlayer();
    }

    public void LevelCompleted()
    {
        enemyManager.StopEnemies();   
    }
}
