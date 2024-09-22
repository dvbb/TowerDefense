using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EscSceneManager : MonoBehaviour
{
    private EscSceneManager Instance;

    [Header("Panels")]
    [SerializeField] private GameObject EscPanel;
    [SerializeField] private GameObject SettingPanel;

    [Header("UI_Components")]
    [SerializeField] private TMP_Dropdown ResolutionDropdown;
    [SerializeField] private Slider BgmSlider;
    [SerializeField] private Slider SeSlider;

    private string RESOLUTION_SAVE_KEY = "MYGAME_RESOLUTION_RADIO";

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    private void SaveResolutionRadio(int index)
    {
        PlayerPrefs.SetInt(RESOLUTION_SAVE_KEY, index);
        PlayerPrefs.Save();
    }


    #region Button Clicked

    public void OnContinueButtonClicked()
    {
        Time.timeScale = 1f;
        UIManager.Instance.HideUI("EscWindow");
    }

    public void OnSettingButtonClicked()
    {
        EscPanel.SetActive(false);
        SettingPanel.SetActive(true);
        ResolutionDropdown.value = PlayerPrefs.GetInt(RESOLUTION_SAVE_KEY);
        BgmSlider.value = BgmManager.Instance.LoadBgmValue();
        SeSlider.value = SeManager.Instance.LoadSeValue();
    }

    public void OnSettingBackButtonClicked()
    {
        SettingPanel.SetActive(false);
        EscPanel.SetActive(true);
    }

    public void OnBackToTitleButtonClicked() => GameSceneManager.Instance.ToStartScene();
    public void OnEndGameButtonClicked() => GameSceneManager.Instance.QuitGame();

    #endregion

    #region ValueChanged
    public void OnResolutionRadioChanged()
    {
        switch (ResolutionDropdown.value)
        {
            case 0:
                SaveResolutionRadio(0);
                Screen.SetResolution(1920, 1080, false);
                break;
            case 1:
                SaveResolutionRadio(1);
                Screen.SetResolution(1680, 1024, false);
                break;
            case 2:
                SaveResolutionRadio(2);
                Screen.SetResolution(1280, 1024, false);
                break;
            case 3:
                SaveResolutionRadio(3);
                Screen.SetResolution(1024, 768, false);
                break;
            case 4:
                SaveResolutionRadio(4);
                Screen.SetResolution(800, 600, false);
                break;
            default:
                break;
        }
    }

    public void OnBgmSliderValueChanged()
    {
        BgmManager.Instance.SaveBgmValue(BgmSlider.value);
    }

    public void OnSeSliderValueChanged()
    {
        SeManager.Instance.SaveSeValue(SeSlider.value);
    }
    #endregion

}