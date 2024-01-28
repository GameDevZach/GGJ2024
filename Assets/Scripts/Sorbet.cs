using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorbet : Hittable
{
    SpriteRenderer spriteRenderer;
    [SerializeField]
    Sprite[] sprites;
    int spriteIndex = 0;
    float spriteAnim = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteAnim -= Time.deltaTime;
        if(spriteAnim <= 0)
        {
            spriteAnim = 0.5f;
            spriteIndex += 1;
            if (spriteIndex > 1) spriteIndex = 0;
            spriteRenderer.sprite = sprites[spriteIndex];
        }
    }

    public override void Hit()
    {
        ScoreController.instance.DecrementPoints(3);
    }
}
