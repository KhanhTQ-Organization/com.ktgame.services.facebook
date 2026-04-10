using com.ktgame.core;
using UnityEngine;

namespace com.ktgame.services.facebook
{
	public class FacebookServiceSettings: ServiceSettingsSingleton<FacebookServiceSettings>
	{
		public override string PackageName => GetType().Namespace;
		[SerializeField] private string _appId;

		[SerializeField] private string _clientToken;

		[SerializeField] private string _mockUserId;

		[SerializeField] private string _mockAccessToken;

		public string AppId
		{
			get => _appId;
			set => _appId = value;
		}

		public string ClientToken
		{
			get => _clientToken;
			set => _clientToken = value;
		}

		public string MockUserId
		{
			get => _mockUserId;
			set => _mockUserId = value;
		}

		public string MockAccessToken
		{
			get => _mockAccessToken;
			set => _mockAccessToken = value;
		}
	}
}
