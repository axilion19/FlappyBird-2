using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallangeSpawner : MonoBehaviour
{
    public GameObject[] prefab;
    private float spawnTime = 0.5f;
    public float spawnRate = 5f;

    public float minHeight = -1f;
    public float maxHeight = 1f;
    private float fullHp =3;
    
    private void OnEnable() {
        
            System.Console.WriteLine(HealthManager.health);
            InvokeRepeating(nameof(Spawn), spawnTime, spawnRate);
        
    }
    private void OnDisable() {
        CancelInvoke(nameof(Spawn));
    }
    private void Spawn()
    {
        if(!GrowChall.growChallangeAccepted && HealthManager.health < fullHp && !DangerChall.dangerChallangeAccepted)
        {
            int randomIndex = Random.Range(0, prefab.Length);
            GameObject chal = Instantiate(prefab[randomIndex], transform.position, Quaternion.identity);
            chal.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        }
        
    }
}
