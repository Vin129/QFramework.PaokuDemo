/****************************************************************************
 * 2018.11 vin129的MacBook Pro
 ****************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.PaokuDemo
{
	public class UIMainMenuData : UIPanelData
	{
		// TODO: Query Mgr's Data
	}

    public partial class UIMainMenu : UIPanel
    {
    #region Defult
        protected override void InitUI(IUIData uiData = null)
        {
            mData = uiData as UIMainMenuData ?? new UIMainMenuData();
            //please add init code here
        }

        protected override void ProcessMsg(int eventId, QMsg msg)
        {
            throw new System.NotImplementedException();
        }

        protected override void RegisterUIEvent()
        {
            shopBtn.onClick.AddListener(onClickShopBtn);
            settingBtn.onClick.AddListener(onClickSettingBtn);
            playBtn.onClick.AddListener(onClickPlayBtn);
        }

        protected override void OnShow()
        {
            base.OnShow();
        }

        protected override void OnHide()
        {
            base.OnHide();
        }

        protected override void OnClose()
        {
            base.OnClose();
        }

        void ShowLog(string content)
        {
            Debug.Log("[ UIMainMenu:]" + content);
        }
    #endregion  

        private void onClickShopBtn(){
            AudioManager.Instance.SendMsg(new AudioSoundMsg(AudioPath.Button));
        }

        private void onClickSettingBtn()
        {
            AudioManager.Instance.SendMsg(new AudioSoundMsg(AudioPath.Button));
        }

        private void onClickPlayBtn()
        {
            AudioManager.Instance.SendMsg(new AudioSoundMsg(AudioPath.Button));
            GameManager.Instance.LoadLevelScene(SceneType.Game);
            CloseSelf();
        }


    }
}