using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace QFramework.PaokuDemo
{
    public class PlayerCtr : QMonoBehaviour
    {
        const float grivaty = 9.8f;
        const float m_jumpValue = 5;
        const float m_moveSpeed = 13;

        CharacterController mCC;
        SphereCollider mMagnetCollider;
        InputDirection m_inputDir = InputDirection.NULL;
        bool activeInput = false;
        Vector3 m_mousePos;
        int m_nowIndex = 1;
        int m_targetIndex = 1;
        float m_xDistance;
        float m_yDistance;

        bool m_IsSlide = false;
        bool m_IsInvincible = false;
        bool m_IsHit = false;

        float m_SlideTime;

        float m_SpeedAddCount;

        private float mSpeed = 20f;

        private AnimMsg mAnimMsg;
        private UIMsg mUIMsg;

        private int mDistance = 0;
        private int mCoinAddValue = 1;

        public override IManager Manager
        {
            get
            {
                return GameManager.Instance;
            }
        }

        public AnimMsg MAnimMsg
        {
            get
            {
                mAnimMsg.Dir = m_inputDir;
                return mAnimMsg;
            }
        }

        private void Awake()
        {
            mDistance = 0;
            mCC = GetComponent<CharacterController>();
            mMagnetCollider = GetComponentInChildren<SphereCollider>();
            mMagnetCollider.enabled = false;

            Manager.RegisterEvent<GameEvent>(GameEvent.HitCoin, GetEvent);
            Manager.RegisterEvent<GameEvent>(GameEvent.HitObstacle, GetEvent);
            mAnimMsg = new AnimMsg();
            mAnimMsg.EventID = (int)AnimEvent.PlayerAnim;
            mUIMsg = new UIMsg();
        }

        private void Update()
        {
            if (GameManager.Instance.GS != GameState.Start)
                return;
            m_yDistance -= grivaty * Time.deltaTime;
            mCC.Move((transform.forward * mSpeed + new Vector3(0, m_yDistance, 0)) * Time.deltaTime);
            UpdatePosition();
            MoveControl();
         

            mDistance = (int)mCC.transform.position.z;
            mUIMsg.Distance = mDistance;
            mUIMsg.EventID = (int)UIEvent.UpdateDistance;
            UIManager.Instance.SendMsg(mUIMsg);
        }

        #region 事件相关
        void GetEvent(int key, params object[] obj)
        {
            switch (key)
            {
                case (int)GameEvent.HitCoin:
                    GameManager.Instance.UpdateCoin(mCoinAddValue);
                    AudioManager.Instance.SendMsg(new AudioSoundMsg(AudioPath.Coin));
                    break;
                case (int)GameEvent.HitObstacle:
                    
                    break;
            }
        }
        #endregion

        #region 操作相关
        void GetInputDirection()
        {
            //手势识别
            m_inputDir = InputDirection.NULL;
            if (Input.GetMouseButtonDown(0))
            {
                activeInput = true;
                m_mousePos = Input.mousePosition;
            }
            if (Input.GetMouseButton(0) && activeInput)
            {
                Vector3 Dir = Input.mousePosition - m_mousePos;
                if (Dir.magnitude > 20)
                {

                    if (Mathf.Abs(Dir.x) > Mathf.Abs(Dir.y) && Dir.x > 0)
                    {
                        m_inputDir = InputDirection.Right;
                    }
                    else if (Mathf.Abs(Dir.x) > Mathf.Abs(Dir.y) && Dir.x < 0)
                    {
                        m_inputDir = InputDirection.Left;

                    }
                    else if (Mathf.Abs(Dir.x) < Mathf.Abs(Dir.y) && Dir.y > 0)
                    {
                        m_inputDir = InputDirection.Up;
                    }

                    else if (Mathf.Abs(Dir.x) < Mathf.Abs(Dir.y) && Dir.y < 0)
                    {
                        m_inputDir = InputDirection.Down;
                    }
                    activeInput = false;
                }
            }

            //键盘识别
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            {
                m_inputDir = InputDirection.Up;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                m_inputDir = InputDirection.Down;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                m_inputDir = InputDirection.Left;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                m_inputDir = InputDirection.Right;
            }
        }

        void UpdatePosition()
        {
            GetInputDirection();
            switch (m_inputDir)
            {
                case InputDirection.NULL:
                    break;
                case InputDirection.Right:
                    if (m_targetIndex < 2)
                    {
                        m_targetIndex++;
                        m_xDistance = 2;
                        Manager.SendMsg(MAnimMsg);
                        AudioManager.Instance.SendMsg(new AudioSoundMsg(AudioPath.Slide));
                    }
                    break;
                case InputDirection.Left:
                    if (m_targetIndex > 0)
                    {
                        m_targetIndex--;
                        m_xDistance = -2;
                        Manager.SendMsg(MAnimMsg);
                        AudioManager.Instance.SendMsg(new AudioSoundMsg(AudioPath.Slide));
                    }
                    break;
                case InputDirection.Down:
                    if (m_IsSlide == false)
                    {
                        m_IsSlide = true;
                        m_SlideTime = 0.733f;
                        Manager.SendMsg(MAnimMsg);
                        AudioManager.Instance.SendMsg(new AudioSoundMsg(AudioPath.Huadong));
                    }
                    break;
                case InputDirection.Up:
                    if (mCC.isGrounded)
                    {
                        m_yDistance = m_jumpValue;
                        Manager.SendMsg(MAnimMsg);
                        AudioManager.Instance.SendMsg(new AudioSoundMsg(AudioPath.Jump));
                    }
                    break;
                default:
                    break;
            }

        }

        //移动
        void MoveControl()
        {
            //左右移动
            if (m_targetIndex != m_nowIndex)
            {
                float move = Mathf.Lerp(0, m_xDistance, m_moveSpeed * Time.deltaTime);
                transform.position += new Vector3(move, 0, 0);
                m_xDistance -= move;
                if (Mathf.Abs(m_xDistance) < 0.05f)
                {
                    m_xDistance = 0;
                    m_nowIndex = m_targetIndex;

                    switch (m_nowIndex)
                    {
                        case 0:
                            transform.position = new Vector3(-2, transform.position.y, transform.position.z);
                            break;
                        case 1:
                            transform.position = new Vector3(0, transform.position.y, transform.position.z);
                            break;
                        case 2:
                            transform.position = new Vector3(2, transform.position.y, transform.position.z);
                            break;

                    }
                }
            }

            if (m_IsSlide)
            {
                m_SlideTime -= Time.deltaTime;
                if (m_SlideTime < 0)
                {
                    m_IsSlide = false;
                    m_SlideTime = 0;
                }
            }
        }
    #endregion
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == Tag.smallFence)
        {
            if (m_IsInvincible)
                return;
            other.gameObject.SendMessage("HitPlayer", transform.position);
            HitObstacles();
            AudioManager.Instance.SendMsg(new AudioSoundMsg(AudioPath.Zhuang));
        }   
        else if (other.gameObject.tag == Tag.bigFence)
        {
            if (m_IsInvincible)
                return;
            if (m_IsSlide)
                return;
            //2.声音
            HitObstacles();
            AudioManager.Instance.SendMsg(new AudioSoundMsg(AudioPath.Zhuang));
        }
        else if (other.gameObject.tag == Tag.block) //游戏结束
        {
            AudioManager.Instance.SendMsg(new AudioSoundMsg(AudioPath.Zhuang));
            UIManager.Instance.SendEvent(UIEvent.ShowDead);
        }
        else if (other.gameObject.tag == Tag.smallBlock) //游戏结束
        {
            AudioManager.Instance.SendMsg(new AudioSoundMsg(AudioPath.Zhuang));
            UIManager.Instance.SendEvent(UIEvent.ShowDead);
        }
        else if (other.gameObject.tag == Tag.beforeTrigger) //汽车触发器
        {
           other.transform.parent.SendMessage("HitTrigger", SendMessageOptions.RequireReceiver);
        }
    }

        private float mMaskspeed = 0;
        private float mAddRate = 5f;
        //减速
        public void HitObstacles()
        {
            if (m_IsHit)
                return;
            m_IsHit = true;
            mMaskspeed = mSpeed;
            mSpeed = 0;
            StartCoroutine(DecreaseSpeed());
        }

        IEnumerator DecreaseSpeed()
        {
            while (mSpeed <= mMaskspeed)
            {
                mSpeed += Time.deltaTime * mAddRate;
                yield return 0;
            }
            m_IsHit = false;
        }
    }
}































