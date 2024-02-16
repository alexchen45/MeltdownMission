using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceController : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D polygonCollider;
    public Vector3 scaleFactors = new Vector3(0.85f, 0.85f, 0.85f);

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        polygonCollider = GetComponent<PolygonCollider2D>();
        transform.localScale = Vector3.Scale(transform.localScale, scaleFactors);

    }

    // Update is called once per frame
    void Update()
    {
        if (Parameter.TempHealth <= 5)
        {
            scaleFactors = new Vector3(0.18f, 0.18f, 0.18f);
        }
        else if (Parameter.TempHealth <= 25)
        {
            scaleFactors = new Vector3(0.30f, 0.30f, 0.30f);
        }
        else if (Parameter.TempHealth <= 50)
        {
            scaleFactors = new Vector3(0.49f, 0.49f, 0.49f);
        }
        else if (Parameter.TempHealth <= 75)
        {
            scaleFactors = new Vector3(0.67f, 0.67f, 0.67f);
        }
        else
        {
            scaleFactors = new Vector3(0.85f, 0.85f, 0.85f);
        }
        transform.localScale = scaleFactors;


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
