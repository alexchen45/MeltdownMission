using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parameter : MonoBehaviour
{
    //Game related parameter
    public static int TempHealth = 100;
    public static float THReductionTime = 10f;
    public static int THReductionAmount = -5;
    public static float totalTime = 180f; // Total time in seconds (3 minutes)
    public static float SealDeathTime = 20f;
    public static float speedFactor = 0.16f;

    //In-game global varaibles
    public static int sealCount;
    public static float timeRemaining;
    public static bool IsGameStarted;
    public static bool IsGameEnded;
    public static int GameEnding;
    public static bool IsOilSpillBannerCalled;

    //Music
    private AudioSource audioSource;
    private bool StartPlaying;

    // Start is called before the first frame update
    void Start()
    {
        sealCount = 0;
        //StartCoroutine(THReduction());
        IsGameStarted=false;
        IsGameEnded=false;
        GameEnding=0;
        IsOilSpillBannerCalled = false;

        audioSource = GetComponent<AudioSource>();
        StartPlaying = false;

    }
    // Update is called once per frame
    void Update()
    {
        TempHealth =(int)(timeRemaining / 1.8f);
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetPressedSpeed(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetPressedSpeed(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetPressedSpeed(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetPressedSpeed(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SetPressedSpeed(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SetPressedSpeed(6);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SetPressedSpeed(7);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SetPressedSpeed(8);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            SetPressedSpeed(9);
        }

        if (timeRemaining <= 10f&&StartPlaying==false&&IsGameStarted==true)
        {
            StartPlaying = true;
            audioSource.Play();
        }
    }
    //IEnumerator THReduction() {
        
    //    while (TempHealth > 0) {
    //        yield return new WaitForSeconds(THReductionTime);
    //        TempHealth += THReductionAmount;
    //     //   Debug.Log("Current TempHealth: " + TempHealth);
    //    }
    //}
    void SetPressedSpeed(int number)
    {
        speedFactor = number*0.08f;
        Debug.Log("Speed: " + number);
        // You can use the pressedNumber variable for any further operations
    }
}
