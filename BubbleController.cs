using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    public GameObject targetObject;
    public float yOffset = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (targetObject != null)
        {
            // Get the target object's position
            Vector3 targetPosition = targetObject.transform.position;

            // Set the new position with the offset
            transform.position = new Vector3(targetPosition.x, targetPosition.y + yOffset, targetPosition.z);
        }
    }
}
