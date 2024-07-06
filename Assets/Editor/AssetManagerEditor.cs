using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AssetManager))]
public class AssetManagerEditor : Editor
{
    SerializedProperty projectProp;
    SerializedProperty numberProp;

    void OnEnable()
    {
        // Mengambil referensi SerializedProperty untuk Project dan number
        projectProp = serializedObject.FindProperty("Project");
        numberProp = serializedObject.FindProperty("number");
    }

    public override void OnInspectorGUI()
    {
        // Update SerializedObject
        serializedObject.Update();

        // Menampilkan properti Project
        EditorGUILayout.PropertyField(projectProp);

        // Jika Project bernilai true, maka menampilkan properti number
        if (projectProp.boolValue)
        {
            EditorGUILayout.PropertyField(numberProp);
        }

        // Menampilkan properti Tittle dan Description secara default
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Tittle"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Description"));

        // Menyimpan semua perubahan SerializedProperty
        serializedObject.ApplyModifiedProperties();
    }
}
