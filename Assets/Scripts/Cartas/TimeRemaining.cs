using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeRemaining : MonoBehaviour
{
    // Start is called before the first frame update
    Image timerBar;
    public float maxTime;
    float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        switch(dontDestroy.nivelDificultad)
        {
            case 0:
                maxTime = 15f;
                break;
            case 1:
                maxTime = 15f;
                break;
            case 2:
                maxTime = 15f;
                break;
        }
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
    }

    public void reinicio()
    {
        timerBar.fillAmount = 1;
        timeLeft = maxTime;
    }
    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timerBar.fillAmount = timeLeft / maxTime;
    }
}
