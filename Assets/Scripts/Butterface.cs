using UnityEngine;

public class Butterface : Hittable
{
    SpriteRenderer spriteRenderer;
    [SerializeField]
    Sprite[] sprites;
    [SerializeField]
    Sprite hitSprite;
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
        if (spriteAnim <= 0)
        {
            spriteAnim = 0.5f;
            spriteIndex += 1;
            if (spriteIndex > 3) spriteIndex = 0;
            spriteRenderer.sprite = sprites[spriteIndex];
        }
    }

    public override void Hit()
    {
        ScoreController.instance.AddPoints(5);
        spriteAnim = 1;
        spriteRenderer.sprite = hitSprite;
    }
}
