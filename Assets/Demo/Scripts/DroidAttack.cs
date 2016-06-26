using UnityEngine;
using System.Collections;

public class DroidAttack : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    public float attackTime = 2f;
    public GameObject m_shotPrefab;
    public Transform hmd ;
    private float realDelta = 0f;
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.LookAt(hmd);
        realDelta += Time.deltaTime;
        if (realDelta > attackTime)
        {
            GameObject go = GameObject.Instantiate(m_shotPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation) as GameObject;
            GameObject.Destroy(go, 8f);
            realDelta = 0f;
        }
	
	}
    void OnTriggerEnter(Collider e)
    {
        Debug.Log("dddd  " + e.gameObject.tag);
        if (e.gameObject.tag.CompareTo("tagDestroyBall") == 0)
        {
            GameObject.Destroy(this.gameObject);
            Destroy(e.gameObject);  
        }
    }
}
