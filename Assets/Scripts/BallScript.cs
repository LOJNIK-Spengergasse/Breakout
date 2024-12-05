using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class BallScript : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    private Rigidbody2D Rb;
    private AudioSource Audio;
    [SerializeField]
    private AudioClip BrickSound;
    [SerializeField]
    private AudioClip LostSound;
    [SerializeField]
    private float LoadSceneDelay;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Audio = GetComponent<AudioSource>();

        //StartGame
        GlobalData.Score = 0;
        Rb.velocity = new Vector2(0, -Speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Ball lost
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Audio Handling
        Audio.clip = LostSound;
        Audio.Play();
        //Scene Handling //would need to be changed if mutliple balls were added
        Invoke("LoadEndScene", LoadSceneDelay);
    }

    private void LoadEndScene()
    {
        SceneManager.LoadScene("EndScene");
    }

    //Brick/Racket/Wall hit
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Brick hit Handling
        GameObject col = collision.gameObject;
        if (col.name.Contains("Brick"))
        {
            BrickScript bs = col.GetComponent<BrickScript>();
            bs.Damage(1);
            //Audio Handling
            Audio.clip = BrickSound;
            Audio.Play();
        }

        //Velocity Handling
        if (collision.collider.name == "Racket")
        {
            //speed Handling
            Rb.velocity = Vector2.ClampMagnitude(Rb.velocity, Speed);
            //Velocity Handling
            Vector2 hitpoint = collision.contacts[0].point;
            Vector2 racketXpos = collision.collider.bounds.center;
            Rb.velocity = Rb.velocity + (hitpoint - racketXpos) * 2; //*2 for better angles
        }
    }
}
