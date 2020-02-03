using System.Linq;
using UnityEditor;
using UnityEngine;

namespace KoganeEditorLib.Internal
{
	[InitializeOnLoad]
	internal static class HierarchyMenuCustomizer
	{
		private static HierarchyMenuSettings m_settings;

		static HierarchyMenuCustomizer()
		{
			EditorApplication.hierarchyWindowItemOnGUI += OnGUI;
		}

		private static HierarchyMenuSettings GetSettings()
		{
			if ( m_settings == null )
			{
				m_settings = AssetDatabase
						.FindAssets( "t:HierarchyMenuSettings" )
						.Select( AssetDatabase.GUIDToAssetPath )
						.Select( AssetDatabase.LoadAssetAtPath<HierarchyMenuSettings> )
						.FirstOrDefault()
					;
			}

			return m_settings;
		}

		private static void OnGUI( int instanceID, Rect selectionRect )
		{
			if ( Event.current.type != EventType.ContextClick ) return;

			var settings = GetSettings();

			if ( settings == null ) return;
			
			Event.current.Use();

			var list        = settings.List;
			var genericMenu = new GenericMenu();

			for ( var i = 0; i < list.Count; i++ )
			{
				var data = list[ i ];

				if ( data.IsSeparator )
				{
					genericMenu.AddSeparator( data.Name );
				}
				else
				{
					var name         = data.Name;
					var menuItemPath = data.MenuItemPath;
					var content      = new GUIContent( name );

					genericMenu.AddItem
					(
						content: content,
						@on: false,
						func: () => EditorApplication.ExecuteMenuItem( menuItemPath )
					);
				}
			}

			genericMenu.ShowAsContext();
		}
	}
}