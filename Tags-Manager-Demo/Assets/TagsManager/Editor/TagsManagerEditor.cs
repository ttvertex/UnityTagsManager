#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(TagsManager))]
public class TagsManagerEditor : Editor
{
    private string addTagInputField = "";
    private int removeTagInputField = -1;

#if UNITY_EDITOR
	public override void OnInspectorGUI()
    {

		///base.OnInspectorGUI();
		TagsManager tagMgr = (TagsManager)target;

        //////////////////addd
        GUILayout.BeginHorizontal();

        addTagInputField = EditorGUILayout.TextField("Tag Name:", addTagInputField);
        if (GUILayout.Button("Add Tag"))
        {
            addTag(addTagInputField);
        }

        GUILayout.EndHorizontal();

        /////////////////////remove
        GUILayout.BeginHorizontal();

        removeTagInputField = EditorGUILayout.Popup("Tag Index:", removeTagInputField, tagMgr.tags.ToArray());
        if (GUILayout.Button("Remove Tag"))
        {
            tagMgr.removeTag(removeTagInputField);
        }

        GUILayout.EndHorizontal();

        GUIStyle g = new GUIStyle();
        g.alignment = TextAnchor.MiddleCenter;
        g.fontStyle = FontStyle.Bold;
        g.fontSize = 14;

        EditorGUILayout.LabelField("Tags", g);

        if (tagMgr.tags != null)
        {
            int j = 1;
            for (int i = 0; i < tagMgr.tags.Count; i++)
            {
                if (tagMgr.tags[i] != "undefined")
                {
                    string tmp = EditorGUILayout.TextField("Tag " + (j++) + ":", tagMgr.tags[i]);
                    tagMgr.updateTag(tmp, i);
                }
            }
        }

	}
#endif

	void addTag(string s)
    {
        TagsManager tagMgr = (TagsManager)target;

        foreach(string _s in tagMgr.tags)
        {
            if (s == _s)
            {
                Debug.LogError("Tag " + s + "already exists");
                return;
            }
        }

        if (tagMgr.freeSlots.Count > 0)
        {
            tagMgr.tags[tagMgr.freeSlots.Dequeue()] = s;
            return;
        }
            
        tagMgr.tags.Add(s);
    }
}