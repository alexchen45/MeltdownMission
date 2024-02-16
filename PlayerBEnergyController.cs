using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBEnergyController : MonoBehaviour
{
    public Sprite[] PlayerBEnergyBar = new Sprite[11];
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
        if (PolarBearBController.energy >= 0)
        {
            imageComponent.sprite = PlayerBEnergyBar[PolarBearBController.energy];
        }
        else
        {
            imageComponent.sprite = PlayerBEnergyBar[0];
        }
    }
}
