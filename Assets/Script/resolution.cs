using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class resolution : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;

    private Resolution[] resolutions;
    private List<Resolution> filterResolutions;

    private float currentRefresRate;
    private int currentResolutionIndex = 0;
    private void Start()
    {
        resolutions = Screen.resolutions;
        filterResolutions = new List<Resolution>();

        resolutionDropdown.ClearOptions();
        currentRefresRate = Screen.currentResolution.refreshRate;

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRate == currentRefresRate)
            {
                filterResolutions.Add(resolutions[i]);
            }
        }

        List<string> options = new List<string>();
        for (int i = 0; i < filterResolutions.Count; i++)
        {
            string resolutionOption = filterResolutions[i].width + "x" + filterResolutions[i].height + " " + filterResolutions[i].refreshRate + "Hz";
            options.Add(resolutionOption);
            if (filterResolutions[i].width == Screen.width && filterResolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }

        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = filterResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);
    }
}
