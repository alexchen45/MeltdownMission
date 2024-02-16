using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text ScoreNumber;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreNumber.text = (Parameter.sealCount.ToString()+"/10");
    }
}
