using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ReturnToPosition : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;

    private Vector3 originalLocalPosition;
    private Quaternion originalLocalRotation;

    public float returnSpeed = 4f;

    private Coroutine returnRoutine;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();

        originalLocalPosition = transform.localPosition;
        originalLocalRotation = transform.localRotation;

        grabInteractable.selectExited.AddListener(OnRelease);
    }

    void OnRelease(SelectExitEventArgs args)
{
    if (!gameObject.activeInHierarchy)
        return;

    if (returnRoutine != null)
        StopCoroutine(returnRoutine);

    returnRoutine = StartCoroutine(ReturnToOriginalPosition());
}

    IEnumerator ReturnToOriginalPosition()
    {
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        while (
            Vector3.Distance(
                transform.localPosition,
                originalLocalPosition
            ) > 0.001f
        )
        {
            transform.localPosition = Vector3.Lerp(
                transform.localPosition,
                originalLocalPosition,
                Time.deltaTime * returnSpeed
            );

            transform.localRotation = Quaternion.Slerp(
                transform.localRotation,
                originalLocalRotation,
                Time.deltaTime * returnSpeed
            );

            yield return null;
        }

        transform.localPosition = originalLocalPosition;
        transform.localRotation = originalLocalRotation;
    }

    void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectExited.RemoveListener(OnRelease);
        }
    }
}