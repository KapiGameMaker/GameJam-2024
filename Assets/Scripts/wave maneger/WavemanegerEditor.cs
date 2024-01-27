using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomEditor(typeof(Wave_Maneger))]
public class WaveManagerEditor : Editor
{

    SerializedProperty wave;

    ReorderableList list;

    private void OnEnable()
    {
        wave = serializedObject.FindProperty("wave");
  
        list = new ReorderableList(serializedObject, wave, true, true, true, true);

        list.drawElementCallback = DrawListItems;
        list.drawHeaderCallback = DrawHeader;
    }

    void DrawListItems(Rect rect, int index, bool isActive, bool isFocused)
    {
        SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index);

        EditorGUI.PropertyField(
            new Rect(rect.x, rect.y, 100, EditorGUIUtility.singleLineHeight),
            element.FindPropertyRelative("enemy"),
            GUIContent.none
        );

        EditorGUI.PropertyField(
            new Rect(rect.x + 110, rect.y, 100, EditorGUIUtility.singleLineHeight),
            element.FindPropertyRelative("spawnPoint"),
            GUIContent.none
        );

        EditorGUI.LabelField(new Rect(rect.x + 210, rect.y, 100, EditorGUIUtility.singleLineHeight), "spawn_time");
        EditorGUI.PropertyField(
            new Rect(rect.x + 280, rect.y, 30, EditorGUIUtility.singleLineHeight),
            element.FindPropertyRelative("spawn_time"),
            GUIContent.none
        );


        EditorGUI.LabelField(new Rect(rect.x + 320, rect.y, 100, EditorGUIUtility.singleLineHeight), "speed");
        EditorGUI.PropertyField(
            new Rect(rect.x + 360, rect.y, 30, EditorGUIUtility.singleLineHeight),
            element.FindPropertyRelative("speed"),
            GUIContent.none
        );

        EditorGUI.LabelField(new Rect(rect.x + 400, rect.y, 100, EditorGUIUtility.singleLineHeight), "isRight");
        EditorGUI.PropertyField(
            new Rect(rect.x + 440, rect.y, 30, EditorGUIUtility.singleLineHeight),
            element.FindPropertyRelative("isRight"),
            GUIContent.none
        );

        EditorGUI.PropertyField(
            new Rect(rect.x + 480, rect.y, 50, EditorGUIUtility.singleLineHeight),
            element.FindPropertyRelative("weakness1"),
            GUIContent.none
        );

        EditorGUI.PropertyField(
            new Rect(rect.x + 530, rect.y, 50, EditorGUIUtility.singleLineHeight),
            element.FindPropertyRelative("weakness2"),
            GUIContent.none
        );
    }

    void DrawHeader(Rect rect)
    {
        string name = "Wave";
        EditorGUI.LabelField(rect, name);
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        list.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }
}