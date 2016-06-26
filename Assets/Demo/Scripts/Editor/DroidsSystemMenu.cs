using UnityEngine;
using UnityEditor;

public class DroidssSystemMenu : Editor {

	static byte count = 0;

	[MenuItem ("GameObject/Create Other/Droids System/Create on Selection")]
	static void CreateOnSelection ()
	{
		if (Selection.activeGameObject != null)
		{
			GameObject go = Selection.activeGameObject;
			go.AddComponent<DroidsSystem>();
			Selection.activeTransform = go.transform;
		}
	}
	[MenuItem ("GameObject/Create Other/Droids System/Create on new GameObject")]
	static void CreateOnNew ()
	{
		if (Selection.activeGameObject != null)
		{
			GameObject go = (GameObject)Instantiate(Resources.Load("DroidsSystem"));

			go.name = "Droids_System_" + count.ToString();
			go.transform.position = Selection.activeTransform.position;
			go.AddComponent<DroidsSystem>();
			Selection.activeTransform = go.transform;
			
			++count;
		}
	}
}
