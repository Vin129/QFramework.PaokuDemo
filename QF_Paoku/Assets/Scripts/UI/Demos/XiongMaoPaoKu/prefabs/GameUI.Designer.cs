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
    
    
    // Generate Id:70fff6b0-88b1-4da8-9c10-e716e2d0b69c
    public partial class GameUI
    {
        
        public const string NAME = "GameUI";
        
        [SerializeField()]
        public UnityEngine.UI.Image UIBoard;
        
        [SerializeField()]
        public UnityEngine.UI.Slider Timer;
        
        [SerializeField()]
        public UnityEngine.UI.Text TimerText;
        
        [SerializeField()]
        public UnityEngine.UI.Text coinText;
        
        [SerializeField()]
        public UnityEngine.UI.Text distanceText;
        
        [SerializeField()]
        public UnityEngine.UI.Button PauseButton;
        
        [SerializeField()]
        public UnityEngine.UI.Image UIFinalScore;
        
        [SerializeField()]
        public UnityEngine.UI.Text distanceCount;
        
        [SerializeField()]
        public UnityEngine.UI.Text coinCount;
        
        [SerializeField()]
        public UnityEngine.UI.Text ScoreText;
        
        [SerializeField()]
        public UnityEngine.UI.Button homeBtn;
        
        [SerializeField()]
        public UnityEngine.UI.Button continueBtn;
        
        [SerializeField()]
        public UnityEngine.UI.Image UIDead;
        
        [SerializeField()]
        public UnityEngine.UI.Button UIDeadcancle;
        
        [SerializeField()]
        public UnityEngine.UI.Text UIDeadCoinText;
        
        [SerializeField()]
        public UnityEngine.UI.Button UIDeadbuyButton;
        
        [SerializeField()]
        public UnityEngine.UI.Image UIPause;
        
        [SerializeField()]
        public UnityEngine.UI.Text PauseScore;
        
        [SerializeField()]
        public UnityEngine.UI.Text PauseCoin;
        
        [SerializeField()]
        public UnityEngine.UI.Text PauseDistance;
        
        [SerializeField()]
        public UnityEngine.UI.Button PausecontinueBtn;
        
        [SerializeField()]
        public UnityEngine.UI.Button PausehomeBtn;
        
        [SerializeField()]
        public UnityEngine.UI.Image UIResume;
        
        [SerializeField()]
        public UnityEngine.UI.Image resumeImage;
        
        private GameUIData mPrivateData = null;
        
        public GameUIData mData
        {
            get
            {
                return mPrivateData ?? (mPrivateData = new GameUIData());
            }
            set
            {
                mUIData = value;
                mPrivateData = value;
            }
        }
        
        protected override void ClearUIComponents()
        {
            UIBoard = null;
            Timer = null;
            TimerText = null;
            coinText = null;
            distanceText = null;
            PauseButton = null;
            UIFinalScore = null;
            distanceCount = null;
            coinCount = null;
            ScoreText = null;
            homeBtn = null;
            continueBtn = null;
            UIDead = null;
            UIDeadcancle = null;
            UIDeadCoinText = null;
            UIDeadbuyButton = null;
            UIPause = null;
            PauseScore = null;
            PauseCoin = null;
            PauseDistance = null;
            PausecontinueBtn = null;
            PausehomeBtn = null;
            UIResume = null;
            resumeImage = null;
            mData = null;
        }
    }
}
