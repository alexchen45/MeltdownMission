using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilSpillBannerController : MonoBehaviour
{
    public GameObject OilSpillBanner;
    public Sprite[] OilSpillBannerSprite=new Sprite[2];

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Ensure the object to activate is initially disabled
        OilSpillBanner.SetActive(false);
        spriteRenderer = OilSpillBanner.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Parameter.IsOilSpillBannerCalled==false && PolarBearAController.TouchedOil==true ) 
        {
            // Activate the object
            Debug.Log("Alert called!");
            OilSpillBanner.SetActive(true);
            spriteRenderer.sprite = OilSpillBannerSprite[0];
            Parameter.IsOilSpillBannerCalled = true;
            Invoke("DisableObject", 4f);

        }
        if (Parameter.IsOilSpillBannerCalled == false && PolarBearBController.TouchedOil == true)
        {
            // Activate the object
            OilSpillBanner.SetActive(true);
            spriteRenderer.sprite = OilSpillBannerSprite[1];
            Parameter.IsOilSpillBannerCalled = true;
            Invoke("DisableObject", 4f);

        }
    }

    void DisableObject()
    {
        // Disable the object
        OilSpillBanner.SetActive(false);
    }
}
