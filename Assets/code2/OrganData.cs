using UnityEngine;

public class OrganData : MonoBehaviour
{
    [Header("Info")]
    public string organName;

    [TextArea(3, 10)]
    public string description;
}