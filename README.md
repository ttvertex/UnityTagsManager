# TagsManager
Remove + add + rename tags in Unity made easy!

Unity engine users know how undesirable it is to work with Tags in the engine.
-The unity system does not allow modify or remove tags.
-When removing middle elements, the system shift the indexes in the prefabs.


This implementatin presents a simple yet efficient approach to a tag system:
-Create an object and add the TagsManager script;
-Add tags to it;
-Create your objects and add the Tagger script to them, selecting the tag it belongs;
-Use TagsManager.FindObjectsWithTag method to get elements.

**allows multiple tags per object
**edit, save, remove tags without having issues!!
