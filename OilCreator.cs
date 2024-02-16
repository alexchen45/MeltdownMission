using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OCreator : MonoBehaviour
{
    public GameObject Oil;
    List<Vector3> IceCenters = new List<Vector3>();
    Camera mainCamera;
    float initialGenerateTime = 1f;
    float generateTime = 10f;
    float miniDist = 3f;
    // Start is called before the first frame update
    void Start()
    {
        FindColliderCenter("Ice");
        InvokeRepeating("CreateOil", initialGenerateTime, generateTime);
        mainCamera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        if (Parameter.TempHealth <= 5)
        {
            Destroy(this.gameObject);
        }

    }
    public void CreateOil()
    {




        //Instantiate(Seal, IceCenters[x], Quaternion.identity);
        GameObject[] objIce = GameObject.FindGameObjectsWithTag("Ice");
        GameObject[] objHomeIce = GameObject.FindGameObjectsWithTag("HomeIce");
        GameObject[] objPolar = GameObject.FindGameObjectsWithTag("PolarBear");
        bool oilCreated = false;
        while (!oilCreated)
        {
            // Generate a random position
            //Vector3 spawnPosition = Random.insideUnitSphere * spawnDistance;

            Vector3 newOilPos = GenerateRandomPositionInCameraView();

            // Check if there are nearby objects
            //Collider[] colliders = Physics.OverlapSphere(newSealPos, miniDist);
            bool nearbyObjectFound = false;
            foreach (GameObject ice in objIce)
            {
                if (Vector3.Distance(ice.transform.position, newOilPos) < miniDist)
                {
                    nearbyObjectFound = true;
                    break;
                }
            }
            foreach (GameObject homeIce in objHomeIce)
            {
                if (Vector3.Distance(homeIce.transform.position, newOilPos) < miniDist)
                {
                    nearbyObjectFound = true;
                    break;
                }
            }
            foreach (GameObject polar in objPolar)
            {
                if (Vector3.Distance(polar.transform.position, newOilPos) < miniDist)
                {
                    nearbyObjectFound = true;
                    break;
                }
            }

            // If no nearby objects found, instantiate the prefab and break the loop
            if (!nearbyObjectFound)
            {
                Instantiate(Oil, newOilPos, Quaternion.identity);
                oilCreated=true;
                break;
                
            }
        }



    }
    void FindColliderCenter(string objTag)
    {
        // Array to store all colliders with the specified tag

        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(objTag);



        // Loop through all the colliders to calculate the total center
        foreach (GameObject obj in objectsWithTag)
        {
            Collider2D collider = obj.GetComponent<Collider2D>();
            IceCenters.Add(collider.bounds.center);

        }

        // Calculate the average center location


    }
    Vector3 GenerateRandomPositionInCameraView()
    {
        // Generate random coordinates within the camera's viewport
        float randomX = Random.Range(0f, 1f);
        float randomY = Random.Range(0f, 1f);

        // Convert viewport coordinates to world coordinates
        Vector3 viewportPoint = new Vector3(randomX, randomY, mainCamera.nearClipPlane);
        Vector3 worldPoint = mainCamera.ViewportToWorldPoint(viewportPoint);

        return worldPoint;
    }
}
