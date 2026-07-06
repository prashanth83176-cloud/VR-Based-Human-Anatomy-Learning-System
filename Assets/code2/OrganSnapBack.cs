using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OrganSnapBack : MonoBehaviour
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    public float snapDistance = 0.15f;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;

    private void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        float distance = Vector3.Distance(transform.position, originalPosition);

        if (distance <= snapDistance)
        {
            transform.position = originalPosition;
            transform.rotation = originalRotation;
        }
    }
}