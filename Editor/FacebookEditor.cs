using Sirenix.OdinInspector;
using UnityEditor;

namespace com.ktgame.services.facebook.editor
{
	public class FacebookEditor
	{
		private FacebookServiceSettings _facebookServiceSettings;
		
		public FacebookEditor(FacebookServiceSettings facebookServiceSettings)
		{
			_facebookServiceSettings = facebookServiceSettings;
		}
		
		[PropertySpace(20)]
		[Title("Facebook Setting", Bold = true)]
		[ShowInInspector]
		[LabelText("AppId")]
		public string DevKey
		{
			get => _facebookServiceSettings.AppId;
			set
			{
				_facebookServiceSettings.AppId = value;
				AssetDatabase.SaveAssets();
			}
		}
		
		[ShowInInspector]
		[LabelText("Client Token")]
		public string ClientToken
		{
			get => _facebookServiceSettings.ClientToken;
			set
			{
				_facebookServiceSettings.ClientToken = value;
				AssetDatabase.SaveAssets();
			}
		}
		
		[ShowInInspector]
		[LabelText("Mock User Id")]
		public string MockUserId
		{
			get => _facebookServiceSettings.MockUserId;
			set
			{
				_facebookServiceSettings.MockUserId = value;
				AssetDatabase.SaveAssets();
			}
		}
		
		[ShowInInspector]
		[LabelText("Mock Access Token")]
		public string MockAccessToken
		{
			get => _facebookServiceSettings.MockAccessToken;
			set
			{
				_facebookServiceSettings.MockAccessToken = value;
				AssetDatabase.SaveAssets();
			}
		}
	}
}
