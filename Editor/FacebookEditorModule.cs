using UnityEditor;
using com.ktgame.core.editor;
using Sirenix.OdinInspector.Editor;
using UnityEngine;

namespace com.ktgame.services.facebook.editor
{
	[InitializeOnLoad]
	public class FacebookEditorModule : IEditorDirtyHandler, IMenuTreeExtension
	{
		static FacebookEditorModule()
		{
			var module = new FacebookEditorModule();
			EditorDirtyRegistry.Register(module);
			MenuTreeExtensionRegistry.Register(module);
		}
		
		public void SetDirty()
		{
			var instance = FacebookServiceSettings.Instance;
			if (instance != null)
			{
				EditorUtility.SetDirty(instance);
			}
		}
		
		public void BuildMenu(OdinMenuTree tree)
		{
			var instance = FacebookServiceSettings.Instance;
			var icon = AssetDatabase.LoadAssetAtPath<Texture2D>($"Packages/{instance.PackageName}/Editor/Textures/Icon.png");
			tree.Add("FacebookSDK", new FacebookEditor(FacebookServiceSettings.Instance), icon);
		}
	}
}
