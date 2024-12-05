using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrickSetup : MonoBehaviour
{
    [SerializeField] float X;
    [SerializeField] float Y;
    [SerializeField] float Scaling;
    [SerializeField] float Spacing;
    [SerializeField] int BrickAmount;
    [SerializeField] Sprite BrickSprite100;
    [SerializeField] Sprite BrickSprite66;
    [SerializeField] Sprite BrickSprite33;
    int totalBricks = 0;


    // Start is called before the first frame update
    void Start()
    {
        for (int y = 0; y < GlobalData.BrickRows; y++)
        {
            for (int x = 0; x < BrickAmount; x++)
            {
                //Brick Creation
                GameObject brick = new GameObject();
                brick.transform.localScale = new Vector2(Scaling, Scaling);
                brick.name = $"Brick{x}_{y}";
                
                //Sprite
                SpriteRenderer bs = brick.AddComponent<SpriteRenderer>();
                bs.sprite = BrickSprite100;
                bs.color = Random.ColorHSV();
                
                //Collider
                brick.AddComponent<BoxCollider2D>();

                //Brick Placement
                brick.transform.position = new Vector2(x + X + Spacing*x, Y - y);

                //brick AddScript
                BrickScript bsc = brick.AddComponent<BrickScript>();
                bsc.BrickHealth = GlobalData.BrickHP;
                bsc.BrickSprite100 = BrickSprite100;
                bsc.BrickSprite66 = BrickSprite66;
                bsc.BrickSprite33 = BrickSprite33;
                totalBricks++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(totalBricks <= GlobalData.Score)
        {
            SceneManager.LoadScene("EndScene");
        }
    }

}
