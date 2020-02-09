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
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.PaokuDemo
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.UI;
    
    
    public class GameUIData : QFramework.UIPanelData
    {
    }
    
    public partial class GameUI : QFramework.UIPanel
    {
        private float nowTime = 0f;
        ResLoader mResLoader = ResLoader.Allocate();
		protected override void InitUI(IUIData uiData = null)
		{
            //please add init code here
            nowTime = GameManager.Instance.GD.MaxTime;
            TimerText.text = nowTime.ToString();
            showResume();
         

            coinText.text = GameManager.Instance.PD.Coin.ToString();
            distanceText.text = "0米";
		}

		protected override void ProcessMsg (int eventId,QMsg msg)
		{
			throw new System.NotImplementedException ();
		}

		protected override void RegisterUIEvent()
		{
            UIManager.Instance.RegisterEvent<UIEvent>(UIEvent.UpdateCoin, GetEvent);
            UIManager.Instance.RegisterEvent<UIEvent>(UIEvent.UpdateDistance, GetEvent);
            UIManager.Instance.RegisterEvent<UIEvent>(UIEvent.ShowDead,GetEvent);

            PauseButton.onClick.AddListener(onClickPause);
            PausecontinueBtn.onClick.AddListener(showResume);
            PausehomeBtn.onClick.AddListener(()=>{
                AudioManager.Instance.SendMsg(new AudioSoundMsg(AudioPath.Button));
                //UIMgr.ClosePanel(name);
                CloseSelf();
                GameManager.Instance.LoadLevelScene(SceneType.MainMenu);
            });

            homeBtn.onClick.AddListener(() => {
                AudioManager.Instance.SendMsg(new AudioSoundMsg(AudioPath.Button));
                //UIMgr.ClosePanel(name);
                CloseSelf();
                GameManager.Instance.LoadLevelScene(SceneType.MainMenu);
            });

            continueBtn.onClick.AddListener(()=>{
                AudioManager.Instance.SendMsg(new AudioSoundMsg(AudioPath.Button));
                //UIMgr.ClosePanel(name);
                CloseSelf();
                GameManager.Instance.LoadLevelScene(SceneType.Game);
            });

            UIDeadcancle.onClick.AddListener(showUIFinalScore);
            UIDeadbuyButton.onClick.AddListener(()=>{
                //暂时
                AudioManager.Instance.SendMsg(new AudioSoundMsg(AudioPath.Button));
                showResume();
            });
		}

        private void showResume(){
            AudioManager.Instance.SendMsg(new AudioSoundMsg(AudioPath.Countdown));
            UIDead.Hide();
            UIPause.Hide();
            UIResume.Show();
            resumeImage.sprite = mResLoader.LoadSync<GameObject>("UIAtlas_CN_92").GetComponent<SpriteRenderer>().sprite;
            resumeImage.Sequence()
                       .Delay(0.8f)
                       .Event(delegate {
                           resumeImage.sprite = mResLoader.LoadSync<GameObject>("UIAtlas_CN_40").GetComponent<SpriteRenderer>().sprite;
                       })
                       .Delay(0.8f)
                       .Event(delegate {
                           resumeImage.sprite = mResLoader.LoadSync<GameObject>("UIAtlas_CN_58").GetComponent<SpriteRenderer>().sprite;
                       })
                       .Delay(0.8f)
                       .Event(delegate {
                           UIResume.Hide();
                           GameManager.Instance.GS = GameState.Start;
                          })
                       .Begin();

        }

        private void showUIFinalScore(){
            AudioManager.Instance.SendMsg(new AudioSoundMsg(AudioPath.Button));
            UIDead.Hide();
            UIPause.Hide();
            GameManager.Instance.GS = GameState.Stop;
            UIFinalScore.Show();
            coinCount.text = coinText.text;
            ScoreText.text = GameManager.Instance.GD.Distance.ToString();
            distanceCount.text = distanceText.text;
        }

        private void showUIDead(){
            AudioManager.Instance.SendMsg(new AudioSoundMsg(AudioPath.End));
            GameManager.Instance.GS = GameState.Stop;
            GameManager.Instance.GD.DeadTime++;
            UIDead.Show();
            UIDeadCoinText.text = (GameManager.Instance.GD.DeadTime * GameManager.DeadCost).ToString();
        }

        private void onClickPause(){
            AudioManager.Instance.SendMsg(new AudioSoundMsg(AudioPath.Button));
            GameManager.Instance.GS = GameState.Stop;
            UIPause.Show();
            PauseCoin.text = coinText.text;
            PauseScore.text = GameManager.Instance.GD.Distance.ToString();
            PauseDistance.text = distanceText.text;
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
            UIManager.Instance.UnRegistEvent<UIEvent>(UIEvent.UpdateCoin, GetEvent);
            UIManager.Instance.UnRegistEvent<UIEvent>(UIEvent.UpdateDistance, GetEvent);
            UIManager.Instance.UnRegistEvent<UIEvent>(UIEvent.ShowDead, GetEvent);
		}

        private void OnDestroy() {
            mResLoader.Recycle2Cache();
            mResLoader = null;
        }

		void ShowLog(string content)
		{
			Debug.Log("[ GameUI:]" + content);
		}

        void GetEvent(int key, params object[] obj)
        {
            var msg = obj[0] as UIMsg;
            switch (key)
            {
                case (int)UIEvent.UpdateCoin:
                    coinText.text = GameManager.Instance.PD.Coin.ToString();
                    break;
                case (int)UIEvent.UpdateDistance:
                    if (distanceText != null)
                    {
                        distanceText.text = msg.Distance.ToString() + "米";
                        GameManager.Instance.GD.Distance = msg.Distance;
                    }
                    break;
                case (int)UIEvent.ShowDead:
                    showUIDead();
                    break;
            }
        }

        private void Update()
        {
            if(GameManager.Instance.GS == GameState.Start){
                updateTime();
            }
        }

        private void updateTime(){
            nowTime -= Time.deltaTime;
            TimerText.text = nowTime.ToString("F2");
            Timer.value = nowTime / GameManager.Instance.GD.MaxTime;
            if(nowTime <= 0){
                nowTime = 0;
                //GameOver
                showUIFinalScore();
            }
        }
    }
}
