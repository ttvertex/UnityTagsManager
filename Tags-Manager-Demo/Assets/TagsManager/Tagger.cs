using UnityEngine;

/// <summary>
/// Add this script to all objects that need to be tagged. The TagsManager prefab contains
/// the tags that can be added.
/// </summary>
public class Tagger : MonoBehaviour {
    // must be a prefab so we can save it
    public TagsManager m_TagMgr; 

    [HideInInspector]
    public int index;

    void Awake()
    {
		if (m_TagMgr == null)
		{
			Debug.LogError("TagsManager not set for " + name + "!");
			return;
		}

        if(m_TagMgr.tags[index] == "undefined")
        {
            Debug.LogError("Tag undefined for " + name + "!");
			return;
        }

        m_TagMgr.addMe(m_TagMgr.tags[index], gameObject);
    }

    void OnDestroy()
    {
		if (m_TagMgr == null)
		{
			Debug.LogError("TagsManager not set for " + name + "!");
			return;
		}

		m_TagMgr.removeMe(m_TagMgr.tags[index], gameObject);
    }
}
