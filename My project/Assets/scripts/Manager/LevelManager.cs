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
        DeactivateDoor(); // oyun restartlan�nca kap�n�n g�r�nmez olmas�
        RandomizeDoorPosition();//oyun restartlan�nca kap�n�n random konumlanmas�
        DeleteCollactables(); //oyun restartlan�nca collactableslar� siler
        GenerateCollactables(); // oyun restartlan�nca Collactable �retir        
    }

    private void DeleteCollactables()// R ye her bas�ld���nda eski collactables� siler
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
        var pos = door.transform.position; //kap�n�n random poziyonunun ayarlanams�
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
