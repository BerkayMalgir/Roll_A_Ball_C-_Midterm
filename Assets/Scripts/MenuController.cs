using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuController : MonoBehaviour
{
   public GameObject endPanel;
   public GameObject restart;

   public void WinGame()
   {
      endPanel.SetActive(true);
      endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You Win";
   }
   public void LostGame()
   {
      endPanel.SetActive(true);
      endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Game Over";
   }
}
