using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaborLogging : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// What value the timer starts at.
    /// </summary>
    private float timerStart;
    /// <summary>
    /// The User Interface in the scene.
    /// </summary>
    private UserInterface ui;
    #endregion

    private void Awake()
    {
        ui = FindObjectOfType<UserInterface>();
        ui.UpdateTimerText(timerStart.ToString("F2"));
    }

    private void Update()
    {
            timerStart += Time.deltaTime;
            ui.UpdateTimerText(timerStart.ToString("F2"));
    }

    /// <summary>
    /// Resets the Labor Timer.
    /// </summary>
    public void LogTimer()
    {
        ui.previousPickTimeText.text = timerStart.ToString("F2");
        timerStart = 0;
    }
}