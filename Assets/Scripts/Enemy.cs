using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float enemySpeed = 0f;
    [SerializeField] int turnSpeed = 360;
    public GameObject destroyFx;
    public GameObject impactFx;
    Player player;
    private int rotation = 0;
    private bool hit;
    private TrailRenderer tr;
    private SoundManager soundManager;

    

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        soundManager  =  FindObjectOfType<SoundManager>();
        tr = GetComponent<TrailRenderer>();
        rotation = Random.Range(0, turnSpeed) * (Random.Range(0,2)*2-1);
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
        //transform.Rotate(Vector3.forward * Random.Range(0, turnSpeed) * (Random.Range(0,2)*2-1) * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, rotation ) * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {

        if (hit == false)
        {


            if (other.tag == "Shield")
            {
                player.AddScore();
                soundManager.PlaySound("impactOnShield");
                Instantiate(destroyFx, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }




            if (other.tag == "Player" || other.tag == "Enemy")
            {
                player.TakeDamage();
                soundManager.PlaySound("impactOnPlanet");
                Instantiate(impactFx, transform.position, Quaternion.identity);
                enemySpeed = 0;              //(glue to player)
                rotation = 0;
                transform.parent = player.transform;
                hit = true;
                StartCoroutine(StopTrails(0.5f));
            }
        }
    }



     IEnumerator StopTrails(float x)
    {
        yield return new WaitForSeconds(x);
        // Code to execute after the delay
        tr.enabled = false;
    }

}