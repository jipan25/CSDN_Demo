using UnityEngine;
using System.Collections;

public class ShootBehaviour : MonoBehaviour {
    public Transform m_muzzle;
    public GameObject m_shotPrefab;
    //public SteamVR_TrackedController controller;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        SteamVR_TrackedController controller = GetComponent<SteamVR_TrackedController>();
        if (controller != null && controller.triggerPressed)
        {
			GameObject go = GameObject.Instantiate(m_shotPrefab, m_muzzle.position, m_muzzle.rotation) as GameObject;
			GameObject.Destroy(go, 3f);
        }
	
	}



}
