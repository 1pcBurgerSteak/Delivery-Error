using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    public GameObject playerRotation; // Reference to the GameObject that controls rotation
    private SpriteRenderer playerSpriteRenderer;
    public Sprite[] playerSprite;

    void Start()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        UpdateSpriteBasedOnRotation();
    }

    void UpdateSpriteBasedOnRotation()
    {
        float rotation = playerRotation.transform.eulerAngles.z;
        int spriteIndex = GetSpriteIndexFromRotation(rotation);
        playerSpriteRenderer.sprite = playerSprite[spriteIndex];
    }

    int GetSpriteIndexFromRotation(float rotation)
    {
        rotation = (rotation + 360) % 360;

        if (rotation >= 337.5f || rotation < 22.5f)
            return 0; 
        if (rotation >= 22.5f && rotation < 67.5f)
            return 1; 
        if (rotation >= 67.5f && rotation < 112.5f)
            return 2; 
        if (rotation >= 112.5f && rotation < 157.5f)
            return 3; 
        if (rotation >= 157.5f && rotation < 202.5f)
            return 4;
        if (rotation >= 202.5f && rotation < 247.5f)
            return 5; 
        if (rotation >= 247.5f && rotation < 292.5f)
            return 6; 
        if (rotation >= 292.5f && rotation < 337.5f)
            return 7; 

        return 0;
    }
}
