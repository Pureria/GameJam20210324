using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	[SerializeField] GameObject windowPanel;
	[SerializeField] GameObject closeButton;

	public void PopMenu()
	{
		windowPanel.SetActive(true);
		closeButton.SetActive(true);
	}

	public void CloseMenu()
	{
		windowPanel.SetActive(false);
		closeButton.SetActive(false);
	}

}
