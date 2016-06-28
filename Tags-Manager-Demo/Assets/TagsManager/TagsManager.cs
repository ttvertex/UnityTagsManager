using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Tag manager class that handles a list of tags that are added via Inspector.
/// HOWTO use:
/// Add this script to ONE prefab and add the tags there. 
/// For each gameobject that needs to be tagged, add the script Tagger.cs, drag the TagManager prefab
/// and select which tag it belongs to.
/// </summary>
public class TagsManager : MonoBehaviour
{
    public List<string> tags = new List<string>();
    public Queue<int> freeSlots = new Queue<int>();

    private static Dictionary<string, List<GameObject>> objects = new Dictionary<string, List<GameObject>>();

	public static GameObject[] FindGameObjectsWithTag(string s)
    {
        if(objects.ContainsKey(s))
            return objects[s].ToArray();
        return new GameObject[0];
    }

	public static GameObject FindGameObjectWithTag(string s)
	{
		if (objects.ContainsKey(s))
		{
			GameObject[] gos = objects[s].ToArray();
			if (gos.Length > 0)
				return gos[0];
		}
		return null;
	}

	public void addMe(string tagName, GameObject g)
    {
        //Debug.Log("add " + tagName);
        if(!objects.ContainsKey(tagName))
            objects.Add(tagName, new List<GameObject>());
        objects[tagName].Add(g);
    }

    public void removeMe(string tagName, GameObject g)
    {
        //Debug.Log("remove "+ tagName);
        if (objects.ContainsKey(tagName))
            objects[tagName].Remove(g);
    }

    public void addTag(string s)
    {
        foreach (string i in tags)
        {
            if (i == s)
            {
                Debug.LogWarning("Tag name already exists!");
                return;
            }
        }
        tags.Add(s);
    }

    /// <summary>
    /// Tags can be edited via inspector. Therefore verification is needed 
    /// in case someone wants to rename a tag with an existing one.
    /// </summary>
    /// <param name="newTag"></param>
    /// <param name="index"></param>
    public void updateTag(string newTag, int index)
    {
        for (int i = 0; i < tags.Count; i++)
        {
            if (tags[i] == newTag && i != index)
            {
                Debug.LogWarning("Tag name already exists!");
                return;
            }
        }

        tags[index] = newTag;
    }

    /// <summary>
    /// Remove a tag. In case it is located at anywhere other than the last position, 
    /// set the tag as undefined.
    /// </summary>
    /// <param name="index"></param>
    public void removeTag(int index)
    {
        if (index == tags.Count - 1) // no final, so remove
        {
            tags.RemoveAt(index);
        }
        else // offset todo mundo
        {
            tags[index] = "undefined";
            freeSlots.Enqueue(index);
        }
    }
}
