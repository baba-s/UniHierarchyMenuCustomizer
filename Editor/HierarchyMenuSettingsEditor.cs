using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace KoganeEditorLib.Internal
{
	[CustomEditor( typeof( HierarchyMenuSettings ) )]
	internal sealed class HierarchyMenuSettingsEditor : Editor
	{
		private SerializedProperty m_property;
		private ReorderableList    m_reorderableList;

		private void OnEnable()
		{
			m_property = serializedObject.FindProperty( "m_list" );
			m_reorderableList = new ReorderableList( serializedObject, m_property )
			{
				elementHeight       = 44,
				drawElementCallback = OnDrawElement
			};
		}

		private void OnDrawElement
		(
			Rect rect,
			int  index,
			bool isActive,
			bool isFocused
		)
		{
			var element = m_property.GetArrayElementAtIndex( index );
			rect.height -= 4;
			rect.y      += 2;
			EditorGUI.PropertyField( rect, element );
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			m_reorderableList.DoLayoutList();

			if ( GUILayout.Button( "Reset" ) )
			{
				Undo.RecordObject( target, "Reset" );
				var settings = target as HierarchyMenuSettings;
				settings.Reset();
			}

			if ( GUILayout.Button( "Reset To Default" ) )
			{
				Undo.RecordObject( target, "Reset To Default" );
				var settings = target as HierarchyMenuSettings;
				settings.ResetToDefault();
			}

			serializedObject.ApplyModifiedProperties();
		}
	}
}