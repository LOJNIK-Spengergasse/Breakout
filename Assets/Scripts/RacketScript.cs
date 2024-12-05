using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class RacketScript : MonoBehaviour
{
    [SerializeField]
    private KeyCode InputRight;
    [SerializeField]
    private KeyCode InputLeft;
    [SerializeField]
    private float MoveSpeed;

    private bool _moveRight;
    private bool _moveLeft;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (UnityEngine.Input.GetKey(InputRight))
        {
            transform.Translate(new Vector2(MoveSpeed,0.0f));
            
        }
        if (UnityEngine.Input.GetKey(InputLeft))
        {
            transform.Translate(new Vector2(-MoveSpeed,0.0f));
            
        }
    }
}
