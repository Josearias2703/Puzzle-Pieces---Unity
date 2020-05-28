using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    Image timerBar;
    public float maxTime = 5f;
    float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        timerBar = GetComponent<Image>();
        //timeLeft = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
     //   timeLeft -= Time.deltaTime;
        timeLeft = Time.time;
        timerBar.fillAmount = timeLeft / maxTime;
    }
}
