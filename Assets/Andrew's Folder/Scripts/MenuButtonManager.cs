using UnityEngine;

public class MenuButtonManager : MonoBehaviour
{
    public GameObject levelSelectPanel;
    public GameObject optionsPanel;
    public GameObject controlsPanel;
    public GameObject referencesPanel;
    public GameObject mainMenuPanel;

    private void SwitchPanels(GameObject panelToDisable, GameObject panelToEnable)
    {
        if (panelToDisable != null)
        {
            panelToDisable.SetActive(false);
        }

        if (panelToEnable != null)
        {
            panelToEnable.SetActive(true);
        }
    }

    public void ShowLevelSelect()
    {
        SwitchPanels(null, levelSelectPanel);
    }

    public void ShowOptions()
    {
        SwitchPanels(null, optionsPanel);
    }

    public void ShowControls()
    {
        SwitchPanels(null, controlsPanel);
    }

    public void ShowReferences()
    {
        SwitchPanels(null, referencesPanel);
    }

    public void SwitchToLevelSelect(GameObject panelToDisable)
    {
        SwitchPanels(panelToDisable, levelSelectPanel);
    }

    public void SwitchToOptions(GameObject panelToDisable)
    {
        SwitchPanels(panelToDisable, optionsPanel);
    }

    public void SwitchToControls(GameObject panelToDisable)
    {
        SwitchPanels(panelToDisable, controlsPanel);
    }

    public void SwitchToReferences(GameObject panelToDisable)
    {
        SwitchPanels(panelToDisable, referencesPanel);
    }

    public void SwitchToMainMenu(GameObject panelToDisable)
    {
        SwitchPanels(panelToDisable, mainMenuPanel);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}