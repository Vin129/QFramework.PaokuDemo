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
    
    
    // Generate Id:ac9704f8-960f-4623-9bec-9da5c0547853
    public partial class UIMainMenu
    {
        
        public const string NAME = "UIMainMenu";
        
        [SerializeField()]
        public UnityEngine.UI.Button shopBtn;
        
        [SerializeField()]
        public UnityEngine.UI.Button settingBtn;
        
        [SerializeField()]
        public UnityEngine.UI.Button playBtn;
        
        private UIMainMenuData mPrivateData = null;
        
        public UIMainMenuData mData
        {
            get
            {
                return mPrivateData ?? (mPrivateData = new UIMainMenuData());
            }
            set
            {
                mUIData = value;
                mPrivateData = value;
            }
        }
        
        protected override void ClearUIComponents()
        {
            shopBtn = null;
            settingBtn = null;
            playBtn = null;
            mData = null;
        }
    }
}
