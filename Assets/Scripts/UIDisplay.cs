using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Health health;
    [SerializeField] Slider healthSlider;
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();

    }
    void Start()
    {
        healthSlider.maxValue = health.GetHealth();
    }

    void Update()
    {
        healthSlider.value = health.GetHealth();
        scoreText.text = scoreKeeper.GetCurrentScore().ToString();
    }
}
