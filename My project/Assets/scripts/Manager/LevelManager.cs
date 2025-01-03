using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.Build.Content;
public class LevelManager : MonoBehaviour
{
    public GameObject door;
    public GameObject collactablePrefab;
    public List<GameObject> collactables;
    
    
    
    public void RestartLevel()
    {
        DeactivateDoor(); // oyun restartlanınca kapının görünmez olması
        RandomizeDoorPosition();//oyun restartlanınca kapının random konumlanması
        DeleteCollactables(); //oyun restartlanınca collactablesları siler
        GenerateCollactables(); // oyun restartlanınca Collactable üretir 

    }

    private void DeleteCollactables()// R ye her basıldığında eski collactablesı siler
    {
        foreach (GameObject c in collactables) 
        { 
            Destroy(c.gameObject);
        }
        collactables.Clear();
    }

    private void GenerateCollactables()
    {
        var newcollactable = Instantiate(collactablePrefab);
        newcollactable.transform.position = new Vector3(Random.Range(-2.5f,2.5f),0,9.3f);//eklenen collactable konumu
        collactables.Add(newcollactable); // collactables eklnemesi
    }

    private void RandomizeDoorPosition()
    {
        var pos = door.transform.position; //kapının random poziyonunun ayarlanamsı
        pos.x = Random.Range(-2f, 2f);
        door.transform.position = pos;
    }

    private void DeactivateDoor()
    {
        door.SetActive(false);
    }

    public void AppleCollected()
    {
        door.SetActive(true); // Collactable toplanınca kapının aktif olması
    }
}
