using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerChall : MonoBehaviour
{
    public static bool dangerChallangeAccepted = false;
    public static float dangerChallRate = 3f;
    public static float dangerPipe = 3f;
    public static float dangerScoring = 0f;

    private void Update() {
        if(dangerScoring == dangerChallRate -1 && dangerChallRate != 3f)
        {
            HealthManager.health++;
            dangerScoring = 0f;
            dangerChallangeAccepted = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Danger"))
        {
            dangerChallangeAccepted= true;
            dangerPipe = dangerChallRate;
            dangerChallRate++;
            dangerScoring = 0f;
            Destroy(other.gameObject);
        }else if(other.gameObject.CompareTag("DangerScoring"))
        {
            dangerScoring++;
        }
    }
}
