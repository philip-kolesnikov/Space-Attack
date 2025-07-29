using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;

    public void UpdateScoreTExt(float amount)
    {
        ScoreText.text = "Score : " + amount;
    }

}
