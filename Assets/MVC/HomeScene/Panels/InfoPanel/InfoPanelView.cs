using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectR.MVC.HomeScene
{
	public class InfoPanelView : MonoBehaviour, IView
	{
		[SerializeField] private Text ifTxt;
		[SerializeField] private Text btText;
		[SerializeField] private Button singlebt;		
		
		public void Display(string info)
		{
			ifTxt.text = info;						
			gameObject.SetActive(true);
		}			
		
		public void Display(string info, string buttonInfo, UnityEngine.Events.UnityAction buttonClbk)
		{
			ifTxt.text = info;
			singlebt.gameObject.SetActive(true);
			btText.text = buttonInfo;
			singlebt.onClick.RemoveAllListeners();
			if (buttonClbk != null)
			{
				singlebt.onClick.AddListener(buttonClbk);
			}
			
			singlebt.onClick.AddListener(()=> {gameObject.SetActive(false);});
			gameObject.SetActive(true);
		}

		public void Hide()
		{
			gameObject.SetActive(false);
		}

		public void HideButton()
		{
			singlebt.gameObject.SetActive(false);
		}
		
	} 
}
