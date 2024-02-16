using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningController : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] OpeningScreens = new Sprite[4];
    public Sprite[] PolarASprites = new Sprite[2];
    public Sprite[] PolarBSprites = new Sprite[2];
    public GameObject PolarA;
    SpriteRenderer PolarASprite;
    public GameObject PolarB;
    SpriteRenderer PolarBSprite;
    public bool PolarAFocus;
    public bool PolarBFocus;

    public int OpeningState;
    private SpriteRenderer spriteRenderer;
    AudioSource audioSource;

    public float cooldownTime = 1f; // The cooldown time between each increase
    private float lastIncreaseTime; // Time when the variable was last increased
    //private int variableValue = 0; // The variable to increase

    void Start()
    {
        OpeningState = 0;
        lastIncreaseTime = Time.time;
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        PolarASprite = PolarA.GetComponent<SpriteRenderer>();
        PolarBSprite = PolarB.GetComponent<SpriteRenderer>();
        PolarAFocus = false;
        PolarBFocus = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.RightArrow))
        {
            if (Time.time > lastIncreaseTime + cooldownTime)
            {
                OpeningState++;
                lastIncreaseTime = Time.time;
                
            }
            audioSource.Play();

        }
        if (OpeningState >= 4 && PolarAFocus==true && PolarBFocus==true)
        {
            StartCoroutine(ChangeSceneAfterDelay());
        }
        if (OpeningState < 4)
        {
            spriteRenderer.sprite = OpeningScreens[OpeningState];
        }
        if (OpeningState >=3 )
        {
            PolarA.SetActive(true);
            PolarB.SetActive(true);

        }
        if (OpeningState >= 4)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                PolarAFocus = true;
                PolarASprite.sprite = PolarASprites[1];
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                PolarBFocus = true;
                PolarBSprite.sprite = PolarBSprites[1];
            }
        }
    }
    IEnumerator ChangeSceneAfterDelay()
    {
        // Wait for three seconds
        yield return new WaitForSeconds(3f);

        // Load the next scene
        SceneManager.LoadScene("GameScene");
    }
    public void ResetState()
    {
        OpeningState = 0;
        lastIncreaseTime = Time.time;
    }
}
