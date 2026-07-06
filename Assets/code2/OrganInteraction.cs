using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class OrganInteraction : MonoBehaviour
{
    private XRGrabInteractable grab;
    private OrganData data;
    private AudioSource audioSource;

    private void Awake()
    {
        grab = GetComponent<XRGrabInteractable>();
        data = GetComponent<OrganData>();
        audioSource = GetComponent<AudioSource>();

        grab.selectEntered.AddListener(OnGrab);
        grab.selectExited.AddListener(OnRelease);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        OrganUIManager.Instance.ShowInfo(
            data.organName,
            data.description
        );

        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    void OnRelease(SelectExitEventArgs args)
    {
        OrganUIManager.Instance.HideInfo();

        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }
}