using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newCompasData", menuName = "Data/UI Data/Base Data")]
public class CompasData : ScriptableObject
{
    [Header("Position")]
    public float startPos;
    public float endPos;

    [Header("Now Location Arrow")]
    public float rightPos;
    public float leftPos;
}
