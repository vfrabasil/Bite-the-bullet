using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{

    //[SerializeField] float turnSpeed = 0f;
    public TMP_Text healthDisplay;
    public TMP_Text scoreDisplay;
    public GameObject endGame;

    private int score = 0;
    private int health = 0;
    private Animator anim;

    void Start()
    {
        score = 0;
        health = 10;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Planet Rotation:
        // transform.Rotate(Vector3.forward * turnSpeed * Input.GetAxisRaw("Horizontal") * Time.deltaTime);
        
    }


    public void TakeDamage()
    {
        
        anim.SetBool("IsHit", true);
        health--;
        healthDisplay.text = "HEALTH: " + health;
        if (health <= 0) 
        {
            endGame.SetActive(true);
            //StopAllAudio();
            Time.timeScale = 0;
        }    
        StartCoroutine(StopShake(0.5f));
    }



     IEnumerator StopShake(float x)
    {
        yield return new WaitForSeconds(x);
        // Code to execute after the delay
        anim.SetBool("IsHit", false);
    }

    public void AddScore()
    {
        score++;
        scoreDisplay.text = "SCORE: " + score;
        
    }


    public void PlayGame()
    {
        endGame.SetActive(false);
        Time.timeScale = 1;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        SceneManager.LoadScene("SampleScene");
    }



}

