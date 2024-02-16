using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionResultController : MonoBehaviour
{
    public Sprite[] MissionResult = new Sprite[5];
    SpriteRenderer spriteRenderer;
    private int spinCount;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = MissionResult[Parameter.GameEnding];
        spinCount = 0;
        Debug.Log("Game Ending(after switching scene): " + Parameter.GameEnding);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            spinCount++;
        }
        if (spinCount > 3)
        {
            Functions.GameRestart();
        }
    }

    public void ResetState()
    {
        spinCount = 0;
    }
}
