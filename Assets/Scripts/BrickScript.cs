using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    public Sprite BrickSprite100;
    public Sprite BrickSprite66;
    public Sprite BrickSprite33;
    public int BrickHealth=1;
    int curHealth;
    SpriteRenderer parentSprite;
    BoxCollider2D parentCollider;


    // Start is called before the first frame update
    void Start()
    {
        curHealth = BrickHealth;
        parentSprite = this.GetComponentInParent<SpriteRenderer>();
        parentCollider = this.GetComponentInParent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (curHealth <= 0)
        {
            if (parentSprite.enabled) GlobalData.IncreaseScore(1);
            parentSprite.enabled = false;
            parentCollider.enabled = false;
        }
        else if ((float) BrickHealth / 3 >= curHealth && BrickHealth>=3)
        {
            parentSprite.sprite = BrickSprite33;
        }
        else if ((float) BrickHealth / 3*2 >= curHealth && BrickHealth>=2)
        {
            parentSprite.sprite = BrickSprite66;
        }
        //else parentSprite.sprite = BrickSprite100;
    }

    public void Damage(int dmg)
    {
        curHealth -= dmg;
    }
}
