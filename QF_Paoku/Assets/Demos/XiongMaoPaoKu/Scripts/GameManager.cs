using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using UnityEngine.SceneManagement;
using System;

namespace QFramework.PaokuDemo
{
    public static class PrefsKey{
        public const string GameName = "XiongMaoPaoKu";
        public const string Coin = GameName + "_Coin";

    }

    public static class ResPath{
        public const string audioPath = "Resources/Demos/XiongMaoPaoKu/Sound/";
    }

    public static class AudioPath{
        public const string Bgm1 = ResPath.audioPath + "Bgm_JieMian";
        public const string Bgm2 = ResPath.audioPath + "Bgm_ZhanDou";
        public const string Button = ResPath.audioPath + "Se_UI_Button";
        public const string Coin = ResPath.audioPath + "Se_UI_JinBi";
        public const string Jump = ResPath.audioPath + "Se_UI_Jump";
        public const string Huadong = ResPath.audioPath + "Se_UI_Huadong";
        public const string Slide = ResPath.audioPath + "Se_UI_Slide";
        public const string Zhuang = ResPath.audioPath + "Se_UI_Zhuang";
        public const string End = ResPath.audioPath + "Se_UI_End"; 
        public const string Countdown = ResPath.audioPath + "Se_UI_Countdown";

    }

    public static class Tag
    {
        public const string road = "Road";
        public const string player = "MainPlayer";
        public const string bigFence = "BigFence";
        public const string smallFence = "SmallFence";
        public const string block = "Block";
        public const string smallBlock = "SmallBlock";
        public const string beforeTrigger = "BeforeTrigger";
        public const string magnetCollider = "MagnetCollider";
        //射门的trigger
        public const string beforeGoalTrigger = "BeforeGoalTrigger";
        //拖尾的名字
        public const string ball = "Ball";
        //守门员
        public const string goalkeeper = "Goalkeeper";
        //球门
        public const string ballDoor = "BallDoor";
    }

    public enum SceneType
    {
        MainMenu = 0,
        Game = 1,
    }

    public enum GameState
    {
        None = -1,
        Start = 0,
        Stop = 1,
        Over = 2,
    }

    public enum UIEvent
    {
        Start = QMgrID.UI,
        UpdateCoin,
        UpdateDistance,
        ShowDead,
    }

    public enum GameEvent
    {
        Start = QMgrID.Game,
        HitCoin,
        HitObstacle,

        End,
    }
    public enum AnimEvent{
        Start = GameEvent.End,
        PlayerAnim,
    }

    public struct PlayerData{
        private int mCoin;
        public int Coin {
            get
            {
                return mCoin;
            }
            set
            {
                mCoin = value;
                PlayerPrefs.SetInt(PrefsKey.Coin, value);
            }
        }
        public PlayerData(int coin){
            this.mCoin = coin;
        }
    }

    public struct GameData{
        public float MaxTime;
        public int Distance;
        public int DeadTime;

        public GameData(float MaxTime){
            this.MaxTime = MaxTime;
            this.Distance = 0;
            this.DeadTime = 0;
        }
    }

    public class GameManager : QMgrBehaviour,ISingleton
    {
        public static int DeadCost = 10;

        public GameState GS = GameState.None;
        public PlayerData PD;
        public GameData GD;

        private static GameManager mInstance;

        public static GameManager Instance
        {
            get
            {
                return mInstance;
            }
        }

        public override int ManagerId
        {
            get
            {
                return QMgrID.Game;
            }
        }

        private void Awake()
        {
            Init();
        }

        public void Init(){
            ResMgr.Init();
            mInstance = this;
            var coin = PlayerPrefs.GetInt(PrefsKey.Coin, 0);
            PD = new PlayerData(coin);
            GD = new GameData(100f);

            AudioManager.Instance.SendMsg(new AudioMusicMsg(AudioPath.Bgm1));
        }

        public void LoadLevelScene(SceneType t){
            //TODO退出当前场景操作

            switch(SceneManager.GetActiveScene().buildIndex){
                case (int)SceneType.MainMenu:
                    
                    break;
                case (int)SceneType.Game:
                    //if (t == SceneType.MainMenu)
                    break;
            }
            AudioManager.Instance.SendMsg(new AudioStopMusicMsg());
            switch(t){
                case SceneType.Game:
                    GameObjManager.Instance.Init();
                    Init();
                    GS = GameState.Stop;
                    UIMgr.OpenPanel<GameUI>(prefabName: "Resources/Demos/XiongMaoPaoKu/prefabs/GameUI");
                    AudioManager.Instance.SendMsg(new AudioMusicMsg(AudioPath.Bgm2));
                    break;
                case SceneType.MainMenu:
                    AudioManager.Instance.SendMsg(new AudioMusicMsg(AudioPath.Bgm1));
                    UIMgr.OpenPanel<UIMainMenu>(prefabName: "Resources/Demos/XiongMaoPaoKu/prefabs/UIMainMenu");
                    break;
            }

            SceneManager.LoadScene((int)t);
        }

        public void UpdateCoin(int addValue){
            PD.Coin += addValue;
            UIManager.Instance.SendEvent(UIEvent.UpdateCoin);
        }

        public void OnSingletonInit()
        {
            throw new NotImplementedException();
        }
    }
}
