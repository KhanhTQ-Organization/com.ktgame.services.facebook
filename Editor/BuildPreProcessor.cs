using System;
using System.IO;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
#if FACEBOOK
using System.Reflection;
using System.Collections.Generic;
using Facebook.Unity.Settings;
#endif

namespace com.ktgame.services.facebook.editor
{
	public class BuildPreProcessor : IPreprocessBuildWithReport
	{
		public int callbackOrder => 1;

		private const string PackageName = "com.ktgame.services.facebook";

		public void OnPreprocessBuild(BuildReport report)
		{
			var pluginPath = Path.Combine(Application.dataPath, $"Plugins/Ktgame/Settings/{PackageName}");
			if (!Directory.Exists(pluginPath))
			{
				Directory.CreateDirectory(pluginPath);
			}

			if (AssetDatabase.IsValidFolder($"Packages/{PackageName}"))
			{
				AssetDatabase.CopyAsset($"Packages/{PackageName}/Runtime/link.xml", $"Assets/Plugins/Ktgame/Settings/{PackageName}/link.xml");
			}

			var settings = FacebookServiceSettings.Instance;
			if (string.IsNullOrEmpty(settings.AppId) || string.IsNullOrEmpty(settings.ClientToken))
			{
				throw new Exception("Facebook AppId and ClientToken must be set in FacebookServiceSettings");
			}

#if FACEBOOK
			var facebookSettingsType = typeof(FacebookSettings);
			SetAppName(facebookSettingsType, Application.productName);
			SetAppId(facebookSettingsType, settings.AppId);
			SetClientToken(facebookSettingsType, settings.ClientToken);
			EditorUtility.SetDirty(FacebookSettings.Instance);
			AssetDatabase.Refresh();
			AssetDatabase.SaveAssets();
			Debug.Log("Facebook AppId and ClientToken set in FacebookSettings");
#endif
		}

#if FACEBOOK
		private static void SetAppName(Type facebookSettingsType, string appName)
		{
			var appIds =
				facebookSettingsType.GetField("appLabels", BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(FacebookSettings.Instance) as List<string>;
			typeof(List<string>).GetProperty("Item")?.SetValue(appIds, appName, new object[] { 0 });
		}

		private static void SetAppId(Type facebookSettingsType, string appId)
		{
			var appIds =
				facebookSettingsType.GetField("appIds", BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(FacebookSettings.Instance) as List<string>;
			typeof(List<string>).GetProperty("Item")?.SetValue(appIds, appId, new object[] { 0 });
		}

		private static void SetClientToken(Type facebookSettingsType, string clientToken)
		{
			var appIds =
				facebookSettingsType.GetField("clientTokens", BindingFlags.NonPublic | BindingFlags.Instance)
					?.GetValue(FacebookSettings.Instance) as List<string>;
			typeof(List<string>).GetProperty("Item")?.SetValue(appIds, clientToken, new object[] { 0 });
		}
#endif
	}
}