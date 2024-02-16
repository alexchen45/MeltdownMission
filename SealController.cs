using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D polygonCollider;


    public Sprite[] SealSprite = new Sprite[3];
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("DestroySelf", Parameter.SealDeathTime);
        StartCoroutine(SelfDestructCoroutine());
        spriteRenderer = GetComponent<SpriteRenderer>();
        polygonCollider = GetComponent<PolygonCollider2D>();
        int SealSpriteIndex = Random.Range(0, 3);
        spriteRenderer.sprite = SealSprite[SealSpriteIndex];
   
        //Debug.Log("Seal created: " + SealSpriteIndex);
        UpdateCollider();
            
    }

    // Update is called once per frame
    void Update()
    {

        if (Parameter.timeRemaining <= 30f)
        {
            Parameter.SealDeathTime = 10f;
        }else if (Parameter.timeRemaining <= 120f)
        {
            Parameter.SealDeathTime = 15f;
        }
        if (Parameter.timeRemaining <= 5)
        {
            Debug.Log("Self Destroy!");
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if the collision is with a specific tag, for example, "Player"

        if (collision.gameObject.CompareTag("PolarBear"))
        {
            Parameter.sealCount++;
            
            DestroySelf();
        }

    }

    void DestroySelf()
    {
        // Destroy the GameObject
        Destroy(this.gameObject);
    }

    IEnumerator SelfDestructCoroutine()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(Parameter.SealDeathTime);

        // Destroy the GameObject after the delay
        Destroy(gameObject);
    }
    void UpdateCollider()
    {
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
    //bool IsPolarBearTouch()
    //{
    //    Collider2D collider1 = gameObject.GetComponent<Collider2D>();
    //    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("PolarBear");
    //    // Calculate distance for each collider found
    //    foreach (GameObject obj in objectsWithTag)
    //    {
    //        Collider2D collider2 = obj.GetComponent<Collider2D>();
    //        if (collider2 != null)
    //        {


    //            // Calculate the distance between the colliders and get closest points
    //            if (Physics2D.Distance(collider1, collider2).distance < 0f)
    //            {
    //                Debug.Log("return true");
    //                return true;

    //            }

    //        }


    //        // Output the distance            }
    //    }
    //    Debug.Log("No Obj Collider");
    //    return false;
    //}
}
