using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.Build.Content;
public class LevelManager : MonoBehaviour
{
   public GameObject door;

    public void RestartLevel()
    {
        DeactivateDoor(); // oyun restartlan�nca kap�n�n g�r�nmez olmas�
        RandomizeDoorPosition();//oyun restartlan�nca kap�n�n random konumlanmas�
    }

    private void RandomizeDoorPosition()
    {
        var pos = door.transform.position;
        pos.x = Random.Range(-2f, 2f);
        door.transform.position = pos;
    }

    private void DeactivateDoor()
    {
        door.SetActive(false);
    }

    public void AppleCollected()
    {
        door.SetActive(true); // Collactable toplan�nca kap�n�n aktif olmas�
    }
}
