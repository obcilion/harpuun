using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UtopiaWorx.HardWater.HardWaterGenerator))]
public class HardWaterGenerator_Editor : Editor {


		public override void OnInspectorGUI()
		{

			serializedObject.Update();
			SerializedProperty sp_xSize = serializedObject.FindProperty("xSize");
			SerializedProperty sp_ySize = serializedObject.FindProperty ("ySize");
			SerializedProperty sp_Scale = serializedObject.FindProperty ("Scale");


			EditorGUI.BeginChangeCheck();


			sp_xSize.intValue = EditorGUILayout.IntSlider("Width",sp_xSize.intValue,1,254);
			sp_ySize.intValue = EditorGUILayout.IntSlider("Depth",sp_ySize.intValue,1,254);
			sp_Scale.floatValue = EditorGUILayout.Slider("Scale",sp_Scale.floatValue,1,1000);

			if(EditorGUI.EndChangeCheck())
			{
				serializedObject.ApplyModifiedProperties();
			}

		}

}
