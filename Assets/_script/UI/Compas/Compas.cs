using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Compas : MonoBehaviour
{
    [SerializeField] private CompasData compasData;
    private float nowLocation;
    private Transform playerPos;
    private RectTransform rectTransform;

    private void Start()
    {
        nowLocation = compasData.startPos;
        playerPos = GameObject.Find("Player").transform;
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(compasData.leftPos, rectTransform.anchoredPosition.y);
    }

    private void FixedUpdate()
    {
        nowLocation = playerPos.position.x;
        float parce = nowLocation / (compasData.endPos - compasData.startPos);
        rectTransform.anchoredPosition = new Vector2((compasData.rightPos - compasData.leftPos) * parce + compasData.leftPos,rectTransform.anchoredPosition.y);
    }
}
