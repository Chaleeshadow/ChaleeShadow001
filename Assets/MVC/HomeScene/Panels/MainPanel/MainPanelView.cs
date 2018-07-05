using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectR.MVC.HomeScene
{
	public class MainPanelView : MonoBehaviour, IView
	{

		[SerializeField] private Button playBtn;

		public IObservable<Unit> OnPlayBttonClickedAsObservable()
		{
			return playBtn.OnSingleClickAsObservable();
		}

	} 
}

