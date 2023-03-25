using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CiinemachineScript : MonoBehaviour
{
    private CinemachineVirtualCamera _VirtualCamera;

    public void Start()
    {
        _VirtualCamera = GetComponent<CinemachineVirtualCamera>();
        GameObject player = GameObject.Find("Player");
        if (player == null)
        {
            Debug.LogError("Player�I�u�W�F�N�g��������܂���B");
            return;
        }

        _VirtualCamera.Follow = player.transform;
    }
}
