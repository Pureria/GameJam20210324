using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData",menuName ="Data/Player Data/Base Data")]

public class PlayerData : ScriptableObject
{
    [Header("MoveState")]
    public float movementVelocity = 10f;

    [Header("Heart Sound")]
    public float maxRange = 0.7f;
    public float middleRange = 1.0f;
    public float minRange = 1.3f;
    public float MaxVolume = 1.0f;

    public int whatIsEnemyNo;
}
