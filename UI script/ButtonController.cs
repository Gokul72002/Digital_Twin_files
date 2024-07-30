using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonController : MonoBehaviour
{

    [Header("BUTTONS")]
    public Button temperatureButton;
    public Button lightsButton;
    public Button wifiButton;
    public Button powerButton;
    public Button OverviewButton;

    [Header("PANNELS")]
    public GameObject temperaturePanel;
    public GameObject lightsPanel;
    public GameObject wifiPanel;
    public GameObject powerPanel;
    public GameObject overviewPanel;

    [Header("LOGO")]
    public Image temperaturelogo;
    public Image lightslogo;
    public Image wifilogo;
    public Image powerlogo;
    public Image overviewlogo;

    [Header("LOGO BG")]
    public Image temperaturebg;
    public Image lightsbg;
    public Image wifibg;
    public Image powerbg;
    public Image overviewbg;

    private void Start()
    {
        OverviewButton.onClick.AddListener(On_OverviewButtonClick);
        temperatureButton.onClick.AddListener(OnTemperatureButtonClick);
        lightsButton.onClick.AddListener(OnLightsButtonClick);
        wifiButton.onClick.AddListener(OnEmp_ButtonClick);
        powerButton.onClick.AddListener(On_CAm_ButtonClick);
    }

    public void On_OverviewButtonClick()
    {
        SetActivePanel(overviewPanel);
        SetLogoColors(overviewlogo, temperaturelogo, lightslogo, wifilogo, powerlogo);
        SetBackgroundColors(overviewbg, temperaturebg, lightsbg, wifibg, powerbg);
    }

    public void OnTemperatureButtonClick()
    {
        SetActivePanel(temperaturePanel);
        SetLogoColors(temperaturelogo, overviewlogo, lightslogo, wifilogo, powerlogo);
        SetBackgroundColors(temperaturebg, overviewbg, lightsbg, wifibg, powerbg);
    }

    public void OnLightsButtonClick()
    {
        SetActivePanel(lightsPanel);
        SetLogoColors(lightslogo, temperaturelogo, overviewlogo, wifilogo, powerlogo);
        SetBackgroundColors(lightsbg, temperaturebg, overviewbg, wifibg, powerbg);
    }

    public void OnEmp_ButtonClick()
    {
        SetActivePanel(wifiPanel);
        SetLogoColors(wifilogo, temperaturelogo, lightslogo, overviewlogo, powerlogo);
        SetBackgroundColors(wifibg, temperaturebg, lightsbg, overviewbg, powerbg);
    }

    public void On_CAm_ButtonClick()
    {
        SetActivePanel(powerPanel);
        SetLogoColors(powerlogo, temperaturelogo, lightslogo, wifilogo, overviewlogo);
        SetBackgroundColors(powerbg, temperaturebg, lightsbg, wifibg, overviewbg);
    }

    private void SetActivePanel(GameObject activePanel)
    {
        DeactivateAllPanels();
        ActivatePanel(activePanel);
    }

    private void ActivatePanel(GameObject panel)
    {
        if (panel != null)
            panel.SetActive(true);
    }

    private void DeactivatePanel(GameObject panel)
    {
        if (panel != null)
            panel.SetActive(false);
    }

    private void DeactivateAllPanels()
    {
        DeactivatePanel(temperaturePanel);
        DeactivatePanel(lightsPanel);
        DeactivatePanel(wifiPanel);
        DeactivatePanel(powerPanel);
        DeactivatePanel(overviewPanel);
    }

    private void SetLogoColors(Image activeLogo, params Image[] inactiveLogos)
    {
        ChangeImageColor(activeLogo, Color.black);
        foreach (var logo in inactiveLogos)
        {
            ChangeImageColor(logo, Color.white);
        }
    }

    private void SetBackgroundColors(Image activeBg, params Image[] inactiveBgs)
    {
        ChangeImageColor(activeBg, Color.white);
        foreach (var bg in inactiveBgs)
        {
            ChangeImageColor(bg, Color.black);
        }
    }

    private void ChangeImageColor(Image image, Color color)
    {
        if (image != null)
        {
            image.color = color;
        }
    }
}
