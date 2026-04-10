using UnityEditor;

namespace com.ktgame.services.facebook.editor
{
	public class PackageInstaller
	{
		private const string PackageName = "com.ktgame.services.facebook";

		[MenuItem("Ktgame/Services/Settings/Facebook")]
		private static void SelectionSettings()
		{
			Selection.activeObject = FacebookServiceSettings.Instance;
		}
	}
}
