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
        DeactivateDoor(); // oyun restartlanýnca kapýnýn görünmez olmasý
        RandomizeDoorPosition();//oyun restartlanýnca kapýnýn random konumlanmasý
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
        door.SetActive(true); // Collactable toplanýnca kapýnýn aktif olmasý
    }
}
