using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSpriteScript : MonoBehaviour
{
    [SerializeField] private Sprite[] numbers;
    private int nowNumbers;
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
        nowNumbers = 0;
    }

    private void Update()
    {
        image.sprite = numbers[nowNumbers];   
    }

    public void SetNowNumbers(int nowNumbers) { this.nowNumbers = nowNumbers; }
}
