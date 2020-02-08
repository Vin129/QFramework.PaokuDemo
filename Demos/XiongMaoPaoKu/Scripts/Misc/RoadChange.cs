using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace QFramework.PaokuDemo
{
    public class RoadChange : MonoBehaviour
    {
        public GameObject[] TempRoads;

        int nextRoadIndex;
        GameObject mRoadNow;
        GameObject mRoadNext;
        GameObject mParent;

        void Start()
        {
            if (mParent == null)
            {
                mParent = new GameObject();
                mParent.transform.position = Vector3.zero;
                mParent.name = "Road";
            }
            nextRoadIndex = 1;
            mRoadNow = TempRoads[0];
            mRoadNext = TempRoads[1];
            mRoadNext.transform.position += new Vector3(0, 0, 160);
            AddItem(mRoadNow);
            AddItem(mRoadNext);

        }

        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == Tag.road)
            {
                SpawnNewRoad();
            }
        }

        void SpawnNewRoad()
        {

            int i = Random.Range(0,TempRoads.Length - 1);
            if (i == nextRoadIndex)
                i++;
            if(i>= TempRoads.Length){
                i = 0;
            }
            nextRoadIndex = i;
            //生成新的游戏对象
            mRoadNow = mRoadNext;
            mRoadNext = TempRoads[i];
            mRoadNext.transform.position = mRoadNow.transform.position + new Vector3(0, 0, 160);
            AddItem(mRoadNext);
            GameObjManager.Instance.ShowObjs(GameObjType.Coin);
            GameObjManager.Instance.ShowObjs(GameObjType.People);
            GameObjManager.Instance.ShowObjs(GameObjType.Car);
        }

        //生成障碍物
        public void AddItem(GameObject obj)
        {
          
        }

    }
}
