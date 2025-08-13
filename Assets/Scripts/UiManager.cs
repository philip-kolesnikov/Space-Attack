    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class UiManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] GameObject StartButton;
    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject GameOverPanel;

    public void UpdateScoreText(float amount)
    {
        ScoreText.text = "Score : " + amount;
    }

    public void ToggleStartButton()
    {
        if (!StartButton.activeSelf)
        {
            StartButton.SetActive(true);
        }
        else
        {
            StartButton.SetActive(false);
        }
    }

    public void ToggleWinPanel()
    {
        if (!WinPanel.activeSelf)
        {
            WinPanel.SetActive(true);
        }
        else
        {
            WinPanel.SetActive(false);
        }
    }

        public void ToggleGameOverPanel()
    {
        if (!GameOverPanel.activeSelf)
        {
            GameOverPanel.SetActive(true);
        }
        else
        {
            GameOverPanel.SetActive(false);
        }
    }
    

}
