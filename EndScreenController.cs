using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenController : MonoBehaviour
{
    public Sprite GoodEndScreen, BadEndScreen;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (Parameter.GameEnding == 0)
        {
            spriteRenderer.sprite = GoodEndScreen;
        }
        else
        {
            spriteRenderer.sprite = BadEndScreen;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
