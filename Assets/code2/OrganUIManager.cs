using TMPro;
using UnityEngine;

public class OrganUIManager : MonoBehaviour
{
    public static OrganUIManager Instance;

    public GameObject infoPanel;
    public TMP_Text organNameText;
    public TMP_Text descriptionText;

    private void Awake()
    {
        Instance = this;
        infoPanel.SetActive(false);
    }

    public void ShowInfo(string organName, string description)
    {
        infoPanel.SetActive(true);
        organNameText.text = organName;
        descriptionText.text = description;
    }

    public void HideInfo()
    {
        infoPanel.SetActive(false);
    }
}