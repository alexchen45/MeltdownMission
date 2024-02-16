using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeIceController : MonoBehaviour
{
    public Sprite[] HomeIceSprite=new Sprite[4]; // Assign the new sprite in the inspector

    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D polygonCollider;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        polygonCollider = GetComponent<PolygonCollider2D>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Parameter.TempHealth <= 25)
        {
            changeSprite(HomeIceSprite[3]);
        }else if (Parameter.TempHealth <= 50)
        {
            changeSprite(HomeIceSprite[2]);
        }
        else if (Parameter.TempHealth <= 75)
        {
            changeSprite(HomeIceSprite[1]);
        }
        else
        {
            changeSprite(HomeIceSprite[0]);
        }

    }
    void changeSprite(Sprite spriteToChanged)
    {
        spriteRenderer.sprite = spriteToChanged;

        for (int i = 0; i < polygonCollider.pathCount; i++) polygonCollider.SetPath(i, new Vector2[0]);
        polygonCollider.pathCount = spriteRenderer.sprite.GetPhysicsShapeCount();

        List<Vector2> path = new List<Vector2>();
        for (int i = 0; i < polygonCollider.pathCount; i++)
        {
            path.Clear();
            spriteRenderer.sprite.GetPhysicsShape(i, path);
            polygonCollider.SetPath(i, path.ToArray());
        }
    }

}
