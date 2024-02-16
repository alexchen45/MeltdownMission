using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D polygonCollider;
    public Sprite[] OilSprite = new Sprite[5];
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("DestroySelf", Parameter.SealDeathTime);
        //StartCoroutine(SelfDestructCoroutine());
        spriteRenderer = GetComponent<SpriteRenderer>();
        polygonCollider = GetComponent<PolygonCollider2D>();

        //spriteRenderer.sprite = SealSprite[Random.Range(0, 2)];
        //UpdateCollider();

    }

    // Update is called once per frame
    void Update()
    {
        //if (Functions.IsTouched("PolarBear", this.gameObject, 0.001f))
        //{
        //    //DestroySelf();
        //    Destroy(this.gameObject);
        //}
    }

    void DestroySelf()
    {
        // Destroy the GameObject
        Destroy(this.gameObject);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if the collision is with a specific tag, for example, "Player"
        if (collision.gameObject.CompareTag("PolarBear"))
            {
                // Do something when collision with Player occurs
                Debug.Log("Collision with player detected!");

                // Example: Destroy the object collided with
                //Destroy(this.gameObject);
                DestroySelf();
            }

    }
    //void UpdateCollider()
    //{
    //    for (int i = 0; i < polygonCollider.pathCount; i++) polygonCollider.SetPath(i, new Vector2[0]);
    //    polygonCollider.pathCount = spriteRenderer.sprite.GetPhysicsShapeCount();

    //    List<Vector2> path = new List<Vector2>();
    //    for (int i = 0; i < polygonCollider.pathCount; i++)
    //    {
    //        path.Clear();
    //        spriteRenderer.sprite.GetPhysicsShape(i, path);
    //        polygonCollider.SetPath(i, path.ToArray());
    //    }

    //}
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
