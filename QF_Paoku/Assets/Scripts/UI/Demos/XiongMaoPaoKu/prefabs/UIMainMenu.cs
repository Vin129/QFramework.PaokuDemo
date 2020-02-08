// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace QFramework.PaokuDemo
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.UI;
    
    
    public class UIMainMenuData : QFramework.UIPanelData
    {
    }
    
    public partial class UIMainMenu : QFramework.UIPanel
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
            // base.OnClose();
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
            CloseSelf();
            GameManager.Instance.LoadLevelScene(SceneType.Game);
        }
    }
}
