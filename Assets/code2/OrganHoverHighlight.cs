using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class OrganHoverOutline : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Outline outline;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        outline = GetComponent<Outline>();

        if (outline != null)
        {
            outline.enabled = false;

            outline.OutlineMode = Outline.Mode.OutlineVisible;
            outline.OutlineColor = Color.yellow;
            outline.OutlineWidth = 5f;
        }

        grabInteractable.hoverEntered.AddListener(OnHoverEnter);
        grabInteractable.hoverExited.AddListener(OnHoverExit);

        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnHoverEnter(HoverEnterEventArgs args)
    {
        if (outline != null)
        {
            outline.enabled = true;
            outline.OutlineColor = Color.yellow;
        }
    }

    private void OnHoverExit(HoverExitEventArgs args)
    {
        if (outline != null && !grabInteractable.isSelected)
        {
            outline.enabled = false;
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        if (outline != null)
        {
            outline.enabled = true;
            outline.OutlineColor = Color.green;
        }
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        if (outline != null)
        {
            outline.enabled = false;
        }
    }
}