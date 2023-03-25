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
            Debug.LogError("Playerオブジェクトが見つかりません。");
            return;
        }

        _VirtualCamera.Follow = player.transform;
    }
}
