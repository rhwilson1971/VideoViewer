using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace RenderHeads.Media.AVProVideo.Editor
{
	[CustomPropertyDrawer(typeof(VideoResolveOptions))]
	public class VideoResolveOptionsDrawer : PropertyDrawer
	{
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) { return 0f; }

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginProperty(position, GUIContent.none, property);

			SerializedProperty propGenerateMipMaps = property.FindPropertyRelative("generateMipmaps");
			SerializedProperty propTint = property.FindPropertyRelative("tint");
			SerializedProperty propApplyHSBC = property.FindPropertyRelative("applyHSBC");
			SerializedProperty propHue = property.FindPropertyRelative("hue");
			SerializedProperty propSaturation = property.FindPropertyRelative("saturation");
			SerializedProperty propBrightness = property.FindPropertyRelative("brightness");
			SerializedProperty propContrast = property.FindPropertyRelative("contrast");

			EditorGUILayout.PropertyField(propGenerateMipMaps);
			EditorGUILayout.PropertyField(propTint);
			EditorGUILayout.PropertyField(propApplyHSBC);
			if (propApplyHSBC.boolValue)
			{
				EditorGUILayout.PropertyField(propHue);
				EditorGUILayout.PropertyField(propSaturation);
				EditorGUILayout.PropertyField(propBrightness);
				EditorGUILayout.PropertyField(propContrast);
			}

			EditorGUI.EndProperty();
		}
	}
}