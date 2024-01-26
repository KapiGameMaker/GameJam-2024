using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

// Tells Unity to use this Editor class with the WaveManager script component.
[CustomEditor(typeof(Wave_Maneger))]
public class WaveManagerEditor : Editor
{

    // This will contain the <wave> array of the WaveManager. 
    SerializedProperty wave;

    // The Reorderable List we will be working with 
    ReorderableList list;

    private void OnEnable()
    {
        // Get the <wave> array from WaveManager, in SerializedProperty form.
        // Note that <serializedObject> is a property of the parent Editor class.
        wave = serializedObject.FindProperty("wave");

        // Set up the reorderable list       
        list = new ReorderableList(serializedObject, wave, true, true, true, true);

        list.drawElementCallback = DrawListItems; // Delegate to draw the elements on the list
        list.drawHeaderCallback = DrawHeader; // Skip this line if you set displayHeader to 'false' in your ReorderableList constructor.

    }

    // Draws the elements on the list
    void DrawListItems(Rect rect, int index, bool isActive, bool isFocused)
    {
        SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index); // The element in the list

        //Create a property field and label field for each property. 

        EditorGUI.PropertyField(
       new Rect(rect.x, rect.y, 75, EditorGUIUtility.singleLineHeight),
       element.FindPropertyRelative("enemy"),
       GUIContent.none
   );

        EditorGUI.LabelField(new Rect(rect.x + 75, rect.y, 100, EditorGUIUtility.singleLineHeight), "spawn_time");
        //The 'mobs' property. Since the enum is self-evident, I am not making a label field for it. 
        //The property field for mobs (width 100, height of a single line)
        EditorGUI.PropertyField(
            new Rect(rect.x + 145, rect.y, 30, EditorGUIUtility.singleLineHeight),
            element.FindPropertyRelative("spawn_time"),
            GUIContent.none
        );

        //The 'quantity' property
        //The label field for quantity (width 100, height of a single line)
        EditorGUI.LabelField(new Rect(rect.x + 185, rect.y, 100, EditorGUIUtility.singleLineHeight), "speed");

        //The property field for quantity (width 20, height of a single line)
        EditorGUI.PropertyField(
            new Rect(rect.x + 225, rect.y, 30, EditorGUIUtility.singleLineHeight),
            element.FindPropertyRelative("speed"),
            GUIContent.none
        );

        EditorGUI.LabelField(new Rect(rect.x + 265, rect.y, 100, EditorGUIUtility.singleLineHeight), "isLeft");

        //The property field for quantity (width 20, height of a single line)
        EditorGUI.PropertyField(
            new Rect(rect.x + 305, rect.y, 30, EditorGUIUtility.singleLineHeight),
            element.FindPropertyRelative("isLeft"),
            GUIContent.none
        );
    }

    //Draws the header
    void DrawHeader(Rect rect)
    {
        string name = "Wave";
        EditorGUI.LabelField(rect, name);
    }

    //This is the function that makes the custom editor work
    public override void OnInspectorGUI()
    {

        serializedObject.Update(); // Update the array property's representation in the inspector

        list.DoLayoutList(); // Have the ReorderableList do its work

        // We need to call this so that changes on the Inspector are saved by Unity.
        serializedObject.ApplyModifiedProperties();

        // Update the array property's representation in the inspector
        // Have the ReorderableList do its work
        // Apply any property modification
    }
}