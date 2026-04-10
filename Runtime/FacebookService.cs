using com.ktgame.core;
using com.ktgame.facebook.core;
using Cysharp.Threading.Tasks;
using UnityEngine;

#if FACEBOOK
using com.ktgame.facebook.unity;
#endif

namespace com.ktgame.services.facebook
{
	[Service(typeof(IFacebookService))]
	public class FacebookService : MonoBehaviour, IFacebookService
	{
		public int Priority => 0;
		public bool Initialized { get; set; }

		private IFacebook _facebook;

		public UniTask OnInitialize(IArchitecture architecture)
		{
			var settings = FacebookServiceSettings.Instance;

#if FACEBOOK
            _facebook = new Fb(settings.AppId, settings.ClientToken);
#else
			_facebook = new MockFacebook(new FbLoginResult(settings.MockUserId, settings.MockAccessToken, false, string.Empty, string.Empty));
#endif
			_facebook?.Initialize(OnInitComplete);
			return UniTask.CompletedTask;
		}

		private void OnInitComplete()
		{
			Initialized = true;
		}
	}
}
