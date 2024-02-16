using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public TMP_Text countdownText;

    private bool IsTimerStarted;
    public GameObject EndScreen;
    // Start is called before the first frame update
    void Start()
    {
        Parameter.timeRemaining = Parameter.totalTime;

        UpdateCountdownText();
        
        IsTimerStarted = false;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            Parameter.IsGameStarted = true;
            // Load the next scene
            if (!IsTimerStarted)
            {
                InvokeRepeating("UpdateTimer", 1f, 1f); // Update timer every second
            }
            IsTimerStarted = true;
        }
        if (Parameter.sealCount >= 10 && (PolarBearAController.OnIceWater == 2 && PolarBearBController.OnIceWater == 2) && (PolarBearAController.TouchedOil == false && PolarBearBController.TouchedOil == false))
        {
            HandleGameEnd();
        }
        if (PolarBearAController.energy == 0 && PolarBearBController.energy == 0)
        {
            HandleGameEnd();
        }


    }

    // Update is called once per frame
    void UpdateTimer()
    {
        
        

        if (Parameter.timeRemaining <= 0f)
        {
            // Timer has reached zero, do something here
            Debug.Log("Time's up!");
            HandleGameEnd();
            CancelInvoke("UpdateTimer");
        }
        else
        {
            Parameter.timeRemaining -= 1f;
            UpdateCountdownText();
        }
    }

    void UpdateCountdownText()
    {
        int minutes = Mathf.FloorToInt(Parameter.timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(Parameter.timeRemaining % 60f);

        string timerString = string.Format("{0:0}:{1:00}", minutes, seconds);
        countdownText.text = timerString;
    }

    void HandleGameEnd()
    {
        Parameter.IsGameEnded = true;
        if (PolarBearAController.energy == 0 || PolarBearBController.energy == 0)
        {
            //Fail 2: One/Both did not get back
            Parameter.GameEnding = 2;
        }
        else if (Parameter.sealCount < 10)
        {
            //Fail 3: Not enough seal
            Parameter.GameEnding = 3;

        }
        else if (PolarBearAController.OnIceWater!=2|| PolarBearBController.OnIceWater != 2)
        {
            //Fail 1: One/Both did not get back
            Parameter.GameEnding = 1;

        }

        else if (PolarBearAController.TouchedOil == true || PolarBearBController.TouchedOil == true)
        {
            //Fail 4: One/Both touched oil
            Parameter.GameEnding = 4;
        }
        else
        {
            //success:
            Parameter.GameEnding = 0;
        }
        Debug.Log("Game End!");
        Debug.Log("Polar Energys: "+ PolarBearAController.energy+ PolarBearBController.energy);
        Debug.Log("Polar Location(0=Ice, 1=Water, 2=Home Ice): " + PolarBearAController.OnIceWater + PolarBearBController.OnIceWater);
        Debug.Log("Seal Count: " + Parameter.sealCount);
        Debug.Log("Polar Oil Touch: " + PolarBearAController.TouchedOil + PolarBearBController.TouchedOil);
        Debug.Log("Game Ending(before switching scene): " + Parameter.GameEnding);





        StartCoroutine(SwitchToEnd());
        
        

    }
    IEnumerator SwitchToEnd()
    {
        while (true)
        {
            // Increase the variable
            EndScreen.SetActive(true);

            // Print the variable value (you can replace this with your own logic)
            

            // Wait for cooldown time
            yield return new WaitForSeconds(3f);

            // Load the next scene
            SceneManager.LoadScene("EndScene");
        }
    }
}
