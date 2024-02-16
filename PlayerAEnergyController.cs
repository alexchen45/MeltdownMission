using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerAEnergyController : MonoBehaviour
{
    public Sprite[] PlayerAEnergyBar= new Sprite[11];
    SpriteRenderer spriteRenderer;
    Image imageComponent;


    // Start is called before the first frame update
    void Start()
    {
        imageComponent = this.gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PolarBearAController.energy >= 0)
        {
            imageComponent.sprite = PlayerAEnergyBar[PolarBearAController.energy];
        }
        else
        {
            imageComponent.sprite = PlayerAEnergyBar[0];
        }

    }
}
