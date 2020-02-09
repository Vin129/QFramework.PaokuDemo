/****************************************************************************
 * Copyright (c) 2020 vin129 
 * https://gitee.com/vin129/QFramework.PaokuDemo.git 
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 ****************************************************************************/

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
