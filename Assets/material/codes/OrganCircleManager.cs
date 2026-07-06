using System.Collections;
using UnityEngine;

public class OrganCircleManager : MonoBehaviour
{
    [Header("References")]
    public Transform centerPoint;
    public Transform player;
    public Transform[] bodyParts;

    [Header("Settings")]
    public float radius = 2f;
    public float moveDuration = 2f;

    private Vector3[] originalPositions;
    private Quaternion[] originalRotations;

    private bool expanded = false;
    private bool isMoving = false;

    void Start()
    {
        originalPositions = new Vector3[bodyParts.Length];
        originalRotations = new Quaternion[bodyParts.Length];

        for (int i = 0; i < bodyParts.Length; i++)
        {
            originalPositions[i] = bodyParts[i].position;
            originalRotations[i] = bodyParts[i].rotation;
        }
    }

    public void ToggleCircle()
    {
        if (isMoving)
            return;

        if (!expanded)
            StartCoroutine(MoveToCircle());
        else
            StartCoroutine(MoveBack());

        expanded = !expanded;
    }

    IEnumerator MoveToCircle()
    {
        isMoving = true;

        Vector3[] startPositions = new Vector3[bodyParts.Length];
        Vector3[] targetPositions = new Vector3[bodyParts.Length];

        for (int i = 0; i < bodyParts.Length; i++)
        {
            startPositions[i] = bodyParts[i].position;

            float angle = (360f / bodyParts.Length) * i * Mathf.Deg2Rad;

            targetPositions[i] =
                centerPoint.position +
                new Vector3(
                    Mathf.Cos(angle) * radius,
                    0f,
                    Mathf.Sin(angle) * radius
                );
        }

        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;

            float t = Mathf.SmoothStep(
                0f,
                1f,
                Mathf.Clamp01(elapsed / moveDuration)
            );

            for (int i = 0; i < bodyParts.Length; i++)
            {
                bodyParts[i].position =
                    Vector3.Lerp(
                        startPositions[i],
                        targetPositions[i],
                        t
                    );

                FacePlayer(bodyParts[i]);
            }

            yield return null;
        }

        isMoving = false;
    }

    IEnumerator MoveBack()
    {
        isMoving = true;

        Vector3[] startPositions = new Vector3[bodyParts.Length];

        for (int i = 0; i < bodyParts.Length; i++)
        {
            startPositions[i] = bodyParts[i].position;
        }

        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;

            float t = Mathf.SmoothStep(
                0f,
                1f,
                Mathf.Clamp01(elapsed / moveDuration)
            );

            for (int i = 0; i < bodyParts.Length; i++)
            {
                bodyParts[i].position =
                    Vector3.Lerp(
                        startPositions[i],
                        originalPositions[i],
                        t
                    );

                bodyParts[i].rotation =
                    Quaternion.Slerp(
                        bodyParts[i].rotation,
                        originalRotations[i],
                        t
                    );
            }

            yield return null;
        }

        isMoving = false;
    }

    void FacePlayer(Transform obj)
    {
        if (player == null)
            return;

        Vector3 lookPosition = player.position;
        lookPosition.y = obj.position.y;

        obj.LookAt(lookPosition);
    }
}