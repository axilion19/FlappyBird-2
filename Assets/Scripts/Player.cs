using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5;

    //[SerializeField] private AudioSource hitSoundEffect;
    //[SerializeField] private AudioSource deathSoundEffect;

    private void Awake() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
        }
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }

        direction.y +=  gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void AnimateSprite()
    {
        spriteIndex++;

        if(spriteIndex>= sprites.Length){
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Obstacle" || other.gameObject.tag == "DangerObstacle")
        {
            if(other.gameObject.tag == "DangerObstacle") {HealthManager.health--;}
             HealthManager.health--;
            
            if(HealthManager.health <=0)
            {
                //deathSoundEffect.Play();
                FindObjectOfType<GameManager>().GameOver();
            }else{
                //hitSoundEffect.Play();
                StartCoroutine(GetHurt());
            }
        }
        else if (other.gameObject.tag == "Scoring" || other.gameObject.tag == "DangerScoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(6, 7);
        GetComponent<Animator>().SetLayerWeight(1,1);
        yield return new WaitForSeconds(3);
        GetComponent<Animator>().SetLayerWeight(1,0);
        Physics2D.IgnoreLayerCollision(6, 7 , false);
    }
}
