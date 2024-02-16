using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealCreator : MonoBehaviour
{
    public GameObject Seal;
    List<Vector3> IceCenters=new List<Vector3>();
    float initialGenerateTime = 1f;
    float generateTime = 10f;
    float miniDist = 1f;
    // Start is called before the first frame update
    void Start()
    {
        FindColliderCenter("Ice");
        //InvokeRepeating("CreateSeal", initialGenerateTime, generateTime);
        StartCoroutine(SpawnSeals());

    }

    // Update is called once per frame
    void Update()
    {
        if (Parameter.TempHealth < 5)
        {
            Destroy(this.gameObject);
        }
    }
        private IEnumerator SpawnSeals()
    {
        while (true)
        {
            yield return new WaitForSeconds(initialGenerateTime);
            CreateSeal();
            yield return new WaitForSeconds(generateTime);
        }
    }
    public void CreateSeal()
    {
    
        if (IceCenters.Count > 0)
        {
            int x;

            //Instantiate(Seal, IceCenters[x], Quaternion.identity);
            GameObject[] objSeal = GameObject.FindGameObjectsWithTag("Seal");
            GameObject[] objPolar = GameObject.FindGameObjectsWithTag("PolarBear");
            for (int i = 0; i < IceCenters.Count; i++)
            {
                // Generate a random position
                //Vector3 spawnPosition = Random.insideUnitSphere * spawnDistance;
                x = Random.Range(0, IceCenters.Count);
                Vector3 newSealPos = IceCenters[x];

                // Check if there are nearby objects
                //Collider[] colliders = Physics.OverlapSphere(newSealPos, miniDist);
                bool nearbyObjectFound = false;
                foreach (GameObject seal in objSeal)
                {
                    if (Vector3.Distance(seal.transform.position,newSealPos)<miniDist)
                    {
                        nearbyObjectFound = true;
                        break;
                    }
                }
                foreach(GameObject polar in objPolar)
                {
                    if (Vector3.Distance(polar.transform.position, newSealPos) < miniDist)
                    {
                        nearbyObjectFound = true;
                        break;
                    }
                }

                // If no nearby objects found, instantiate the prefab and break the loop
                if (!nearbyObjectFound)
                {
                    Instantiate(Seal, newSealPos, Quaternion.identity);
                    break;
                }
            }

        }
        else
        {
            Debug.Log("No ice!");
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
}
