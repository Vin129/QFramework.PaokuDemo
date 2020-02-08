using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace QFramework.PaokuDemo
{
    public interface IGameObj{
        void Show();
        void Hide();
    }

    public enum GameObjType
    {
        Coin = 0,
        People = 1,
        Car = 2,
    }

    public class GameObjManager : Singleton<GameObjManager> {

        private Dictionary<GameObjType, List<IGameObj>> mGameObjs;

        private GameObjManager(){}

        public void Init(){
            mGameObjs = new Dictionary<GameObjType, List<IGameObj>>();
        }

        public void AddObj(IGameObj obj,GameObjType type ){
            if(mGameObjs.ContainsKey(type)){
                mGameObjs[type].Add(obj);
            }else{
                mGameObjs.Add(type,new List<IGameObj>());
                mGameObjs[type].Add(obj);
            }
        }

        public void ShowObjs(GameObjType type){
            if (mGameObjs.ContainsKey(type))
            {
                mGameObjs[type].ForEach((obj)=> { obj.Show(); });
            }
        }

    }
}
