/****************************************************************************
 * 2018.11 vin129的MacBook Pro
 ****************************************************************************/

namespace QFramework.PaokuDemo
{
	using UnityEngine;
	using UnityEngine.UI;

	public partial class UIMainMenu
	{
		public const string NAME = "UIMainMenu";

		[SerializeField] public Button shopBtn;
		[SerializeField] public Button settingBtn;
		[SerializeField] public Button playBtn;

		protected override void ClearUIComponents()
		{
			shopBtn = null;
			settingBtn = null;
			playBtn = null;
		}

		private UIMainMenuData mPrivateData = null;

		public UIMainMenuData mData
		{
			get { return mPrivateData ?? (mPrivateData = new UIMainMenuData()); }
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
