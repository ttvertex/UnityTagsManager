#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Collections.Generic;


[CustomEditor(typeof(Tagger))]
public class TaggerEditor : Editor {

#if UNITY_EDITOR

	public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Tagger tagger = (Tagger)target;

        if(tagger.m_TagMgr != null)
            tagger.index = EditorGUILayout.Popup("Tag:", tagger.index, tagger.m_TagMgr.tags.ToArray());
    }
#endif
}
