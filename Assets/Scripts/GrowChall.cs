using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrowChall : MonoBehaviour
{
private Vector3 originalScale; 
public static bool growChallangeAccepted = false;
public static float growChallRate = 3f;
public static float growScore; 
public Text countDown;


void Start() {
   originalScale = transform.localScale;
   growScore = 0f;
   growChallRate = 3f;
   countDown.enabled = false;
}
void Update() {
   countDown.text = (growChallRate - growScore).ToString();
    if((growScore == growChallRate) && growChallangeAccepted){
        transform.localScale = originalScale;
        growScore = 0f;
        HealthManager.health++;
        growChallangeAccepted = false;
        growChallRate ++;
    }
    if(!growChallangeAccepted)
    {
      transform.localScale = originalScale;
      countDown.enabled = false;
    }   
}
void OnTriggerEnter2D(Collider2D other) {
   if (other.gameObject.CompareTag("Grow")) {
      growChallangeAccepted = true;
      transform.localScale *= 1.5f;
      Destroy(other.gameObject);
      countDown.enabled = true;
   }else if (other.gameObject.CompareTag("Scoring") && growChallangeAccepted)
   {
        growScore++;
   }else if(other.gameObject.CompareTag("Obstacle") && growChallangeAccepted)
   {
      growChallangeAccepted = false;
      transform.localScale = originalScale;
      growScore = 0f;
      growChallRate++;
   }
}
   
}
