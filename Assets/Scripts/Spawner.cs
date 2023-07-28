using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefab;
    public float spawnRate = 1f;

    public float minHeight = -1f;
    public float maxHeight = 1f;

    private void OnEnable() {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }
    private void OnDisable() {
        CancelInvoke(nameof(Spawn));
    }
    private void Spawn()
    {
        System.Console.WriteLine(DangerChall.dangerPipe);
        if(DangerChall.dangerPipe < 1 || DangerChall.dangerChallRate == 3f)
        {
            GameObject pipes = Instantiate(prefab[0], transform.position, Quaternion.identity);
            pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        }else{
            GameObject pipes = Instantiate(prefab[1], transform.position, Quaternion.identity);
            pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
            DangerChall.dangerPipe--;
        }
    }
}
