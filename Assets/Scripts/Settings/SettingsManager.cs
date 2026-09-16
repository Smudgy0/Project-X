using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SettingsManager : MonoBehaviour
{
    // Stored Values
    static int PlayerLives = 1;

    public int DifficultySelected = 0;

    // UI Gameobjects
    public GameObject MainMenuTrioButtons;
    public GameObject SettingsButtons;

    // Text Boxes
    public TMP_Text DifficultySelectedTextBox;

    // Buttons
    public GameObject SettingsButton;
    public GameObject ReturnToMenuButton;

    //Slider
    public Slider DifficultySlider;

    [SerializeField] Difficulty[] Difficultys;

    private void Start()
    {
        DifficultySlider.value = 2;
    }

    private void Update()
    {
        DifficultySelected = (int)DifficultySlider.value;
        PlayerLives = Difficultys[DifficultySelected].LivesAmount;
        DifficultySelectedTextBox.text = Difficultys[DifficultySelected].DifficultyName + " - Lives: " + PlayerLives;
    }

    public void OpenSettings()
    {
        MainMenuTrioButtons.SetActive(false);
        SettingsButtons.SetActive(true);

        EventSystem.current.SetSelectedGameObject(ReturnToMenuButton);
    }

    public void CloseSettings()
    {
        MainMenuTrioButtons.SetActive(true);
        SettingsButtons.SetActive(false);

        EventSystem.current.SetSelectedGameObject(SettingsButton);
    }
}

[Serializable]
public struct Difficulty
{
    public string DifficultyName;
    public int LivesAmount;
}
