using UnityEngine;
using System.Collections.Generic;
using System.Collections;



public class GameDirector : MonoBehaviour
{
    public List<Enemy> Enemies;
    public void LevelCompleted()
    {
        foreach (var e in Enemies) {
        
        e.speed = 0;
        
        }
    }
}
