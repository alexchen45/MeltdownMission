using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static bool IsTouched(string objTag, GameObject collidingObj, float miniDist)
    {
        Collider2D collider1;
        collider1 = collidingObj.GetComponent<Collider2D>();
        //if (collider1 == null)
        //{
        //    collider1 = collidingObj.GetComponent<PolygonCollider2D>();
        //}
        if (collider1 == null)
        {
            Debug.Log("Collider 1 empty");
        }
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(objTag);
        // Calculate distance for each collider found
        foreach (GameObject obj in objectsWithTag)
        {
            Collider2D collider2;
            collider2 = obj.GetComponent<Collider2D>();
            //if (collider2 == null)
            //{
            //    collider2 = obj.GetComponent<PolygonCollider2D>();
            //}
            if (collider2 != null)
            {


                // Calculate the distance between the colliders and get closest points
                if (Physics2D.Distance(collider1, collider2).distance < miniDist)
                {
                    return true;

                }
                else
                {
                    //Debug.Log("Dist Far!");
                }

            }
            else
            {
                Debug.Log("Collider 2 empty");
            }

            

        }

        return false;
    }
    public static void GameRestart()
    {
        //Reset all game states
    }

}
