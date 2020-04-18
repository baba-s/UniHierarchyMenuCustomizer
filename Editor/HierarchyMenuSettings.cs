using System;
using System.Collections.Generic;
using UnityEngine;

namespace UniHierarchyMenuCustomizer.Internal
{
	[CreateAssetMenu( fileName = "HierarchyMenuSettings", menuName = "UniHierarchyMenuCustomizer/HierarchyMenuSettings", order = 9000 )]
	internal sealed class HierarchyMenuSettings : ScriptableObject
	{
		[SerializeField] private Data[] m_list = null;

		public IList<Data> List => m_list;

		public void Reset()
		{
			m_list = new Data[0];
		}

		public void ResetToDefault()
		{
			m_list = new[]
			{
				new Data( "Copy", "Edit/Copy" ),
				new Data( "Paste", "Edit/Paste" ),

				new Data(),

				new Data( "Rename", "Edit/Rename" ),
				new Data( "Duplicate", "Edit/Duplicate" ),
				new Data( "Delete", "Edit/Delete" ),

				new Data(),

				new Data( "Select Children", "Edit/Select Children" ),
				new Data( "Select Prefab Root", "Edit/Select Prefab Root" ),

				new Data(),

				new Data( "Create Empty", "GameObject/Create Empty" ),

				new Data( "3D Object/Cube", "GameObject/3D Object/Cube" ),
				new Data( "3D Object/Sphere", "GameObject/3D Object/Sphere" ),
				new Data( "3D Object/Capsule", "GameObject/3D Object/Capsule" ),
				new Data( "3D Object/Cylinder", "GameObject/3D Object/Cylinder" ),
				new Data( "3D Object/Plane", "GameObject/3D Object/Plane" ),
				new Data( "3D Object/Quad", "GameObject/3D Object/Quad" ),
				new Data( "3D Object/Text - TextMeshPro", "GameObject/3D Object/Text - TextMeshPro" ),
				new Data( "3D Object/Ragdoll...", "GameObject/3D Object/Ragdoll..." ),
				new Data( "3D Object/Terrain", "GameObject/3D Object/Terrain" ),
				new Data( "3D Object/Tree", "GameObject/3D Object/Tree" ),
				new Data( "3D Object/Wind Zone", "GameObject/3D Object/Wind Zone" ),
				new Data( "3D Object/3D Text", "GameObject/3D Object/3D Text" ),

				new Data( "2D Object/Sprite", "GameObject/2D Object/Sprite" ),
				new Data( "2D Object/Sprite Mask", "GameObject/2D Object/Sprite Mask" ),
				new Data( "2D Object/Tilemap", "GameObject/2D Object/Tilemap" ),
				new Data( "2D Object/Hexagonal Point Top Tilemap", "GameObject/2D Object/Hexagonal Point Top Tilemap" ),
				new Data( "2D Object/Hexagonal Flat Top Tilemap", "GameObject/2D Object/Hexagonal Flat Top Tilemap" ),
				new Data( "2D Object/Isometric Tilemap", "GameObject/2D Object/Isometric Tilemap" ),
				new Data( "2D Object/Isometric Z As Y Tilemap", "GameObject/2D Object/Isometric Z As Y Tilemap" ),

				new Data( "Effects/Particle System", "GameObject/Effects/Particle System" ),
				new Data( "Effects/Particle System Force Field", "GameObject/Effects/Particle System Force Field" ),
				new Data( "Effects/Trail", "GameObject/Effects/Trail" ),
				new Data( "Effects/Line", "GameObject/Effects/Line" ),

				new Data( "Light/Directional Light", "GameObject/Light/Directional Light" ),
				new Data( "Light/Point Light", "GameObject/Light/Point Light" ),
				new Data( "Light/Spotlight", "GameObject/Light/Spotlight" ),
				new Data( "Light/Area Light", "GameObject/Light/Area Light" ),
				new Data( "Light/Reflection Probe", "GameObject/Light/Reflection Probe" ),
				new Data( "Light/Light Probe Group", "GameObject/Light/Light Probe Group" ),

				new Data( "Audio/Audio Source", "GameObject/Audio/Audio Source" ),
				new Data( "Audio/Audio Reverb Zone", "GameObject/Audio/Audio Reverb Zone" ),

				new Data( "Video/Video Player", "GameObject/Video/Video Player" ),

				new Data( "UI/Text", "GameObject/UI/Text" ),
				new Data( "UI/Text - TextMeshPro", "GameObject/UI/Text - TextMeshPro" ),
				new Data( "UI/Image", "GameObject/UI/Image" ),
				new Data( "UI/Raw Image", "GameObject/UI/Raw Image" ),
				new Data( "UI/Button", "GameObject/UI/Button" ),
				new Data( "UI/Button - TextMeshPro", "GameObject/UI/Button - TextMeshPro" ),
				new Data( "UI/Toggle", "GameObject/UI/Toggle" ),
				new Data( "UI/Slider", "GameObject/UI/Slider" ),
				new Data( "UI/Scrollbar", "GameObject/UI/Scrollbar" ),
				new Data( "UI/Dropdown", "GameObject/UI/Dropdown" ),
				new Data( "UI/Dropdown - TextMeshPro", "GameObject/UI/Dropdown - TextMeshPro" ),
				new Data( "UI/Input Field", "GameObject/UI/Input Field" ),
				new Data( "UI/Input Field - TextMeshPro", "GameObject/UI/Input Field - TextMeshPro" ),
				new Data( "UI/Canvas", "GameObject/UI/Canvas" ),
				new Data( "UI/Panel", "GameObject/UI/Panel" ),
				new Data( "UI/Scroll View", "GameObject/UI/Scroll View" ),
				new Data( "UI/Event System", "GameObject/UI/Event System" ),

				new Data( "Camera", "GameObject/Camera" ),
			};
		}

		[Serializable]
		internal sealed class Data
		{
			[SerializeField] private string m_name         = string.Empty;
			[SerializeField] private string m_menuItemPath = string.Empty;

			public string Name         => m_name;
			public string MenuItemPath => m_menuItemPath;
			public bool   IsSeparator  => string.IsNullOrWhiteSpace( m_menuItemPath );

			public Data()
			{
			}

			public Data( string name )
			{
				m_name = name;
			}

			public Data( string name, string menuItemPath )
			{
				m_name         = name;
				m_menuItemPath = menuItemPath;
			}
		}
	}
}