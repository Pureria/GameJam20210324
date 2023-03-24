using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base Data")]

public class EntityData : ScriptableObject
{
    [Header("MoveState")]
    public float movementVelocity = 13f;
    public Vector2 angle;
    public float criticalMovementVelocity = 10f;
    public float slowMovementVelocity = 6f;

    [Header("Clitical Velocity")]
    public float criticalVelocity = 30f;
}
