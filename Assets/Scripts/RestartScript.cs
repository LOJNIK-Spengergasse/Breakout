using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartScript : MonoBehaviour
{
    [SerializeField]
    private Slider BrickHp;
    [SerializeField]
    private Slider BrickRows;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        GlobalData.BrickHP = (int)BrickHp.value;
        GlobalData.BrickRows = (int)BrickRows.value;
        SceneManager.LoadScene("GameScene");
    }
}
