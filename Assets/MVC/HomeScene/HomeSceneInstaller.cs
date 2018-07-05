using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ProjectR.MVC.HomeScene
{
    public class HomeSceneInstaller : MonoInstaller<HomeSceneInstaller>
    {
        [SerializeField] HomeSceneView hmScnView;
        [SerializeField] TopPanelView tPanelView;
        [SerializeField] MainPanelView mPanelView;
        [SerializeField] FootPanelView fPanelView;
        [SerializeField] private InfoPanelView ifPanelView;

        public override void InstallBindings()
        {

            Container.Bind<HomeSceneEvents.OnConnecting>().AsSingle();
            Container.Bind<HomeSceneEvents.OnConnected>().AsSingle();            
            
            Container.BindMediatorAndViewAsSingle<HomeScneMediator, HomeSceneView>(hmScnView);
            Container.BindMediatorAndViewAsSingle<TopPanelMediator, TopPanelView>(tPanelView);
            Container.BindMediatorAndViewAsSingle<MainPanelMediator, MainPanelView>(mPanelView);
            Container.BindMediatorAndViewAsSingle<FootMediator , FootPanelView>(fPanelView);
            Container.BindMediatorAndViewAsSingle<InfoPanelMediator, InfoPanelView>(ifPanelView);
        }
    }

}

