/****************************************************************************
 * 2018.12 vin129的MacBook Pro
 ****************************************************************************/

namespace QFramework.PaokuDemo
{
	using UnityEngine;
	using UnityEngine.UI;

	public partial class GameUI
	{
		public const string NAME = "GameUI";

		[SerializeField] public Image UIBoard;
		[SerializeField] public Slider Timer;
		[SerializeField] public Text TimerText;
		[SerializeField] public Text coinText;
		[SerializeField] public Text distanceText;
		[SerializeField] public Button PauseButton;
		[SerializeField] public Image UIFinalScore;
		[SerializeField] public Text distanceCount;
		[SerializeField] public Text coinCount;
		[SerializeField] public Text ScoreText;
		[SerializeField] public Button homeBtn;
		[SerializeField] public Button continueBtn;
		[SerializeField] public Image UIDead;
		[SerializeField] public Button UIDeadcancle;
		[SerializeField] public Text UIDeadCoinText;
		[SerializeField] public Button UIDeadbuyButton;
		[SerializeField] public Image UIPause;
		[SerializeField] public Text PauseScore;
		[SerializeField] public Text PauseCoin;
		[SerializeField] public Text PauseDistance;
		[SerializeField] public Button PausecontinueBtn;
		[SerializeField] public Button PausehomeBtn;
		[SerializeField] public Image UIResume;
		[SerializeField] public Image resumeImage;

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
		}

		private GameUIData mPrivateData = null;

		public GameUIData mData
		{
			get { return mPrivateData ?? (mPrivateData = new GameUIData()); }
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
