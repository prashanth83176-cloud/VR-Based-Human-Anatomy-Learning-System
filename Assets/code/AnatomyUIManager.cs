using UnityEngine;

public class AnatomyUIManager : MonoBehaviour
{
    public GameObject skeletal;
    public GameObject digestive;
    public GameObject cardiovascular;
    public GameObject endocrine;
    public GameObject integumentary;
    public GameObject muscular;
    public GameObject nervous;
    public GameObject renal;
    public GameObject reproductive;
    public GameObject respiratory;

    public void ToggleSkeletal()
    {
        skeletal.SetActive(!skeletal.activeSelf);
    }

    public void ToggleDigestive()
    {
        digestive.SetActive(!digestive.activeSelf);
    }

    public void ToggleCardiovascular()
    {
        cardiovascular.SetActive(!cardiovascular.activeSelf);
    }

    public void ToggleEndocrine()
    {
        endocrine.SetActive(!endocrine.activeSelf);
    }

    public void ToggleIntegumentary()
    {
        integumentary.SetActive(!integumentary.activeSelf);
    }

    public void ToggleMuscular()
    {
        muscular.SetActive(!muscular.activeSelf);
    }

    public void ToggleNervous()
    {
        nervous.SetActive(!nervous.activeSelf);
    }

    public void ToggleRenal()
    {
        renal.SetActive(!renal.activeSelf);
    }

    public void ToggleReproductive()
    {
        reproductive.SetActive(!reproductive.activeSelf);
    }

    public void ToggleRespiratory()
    {
        respiratory.SetActive(!respiratory.activeSelf);
    }
}