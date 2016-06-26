using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]
public class  DroidFly: MonoBehaviour {

	public bool debug;
	public float forwardSpeed;
	public float angularSpeed;
	public Vector3 targetPosition;
	private Transform thisTransform;
    public GameObject explosion;
    
	
	void Awake()
	{
		thisTransform = transform;
	}
	public void UpdateMove()
	{
        if (this==null || this.gameObject == null)
        {
            return;
        }
		thisTransform.rotation = Quaternion.Lerp(thisTransform.rotation, Quaternion.LookRotation(targetPosition - thisTransform.position),angularSpeed * Time.deltaTime);
		thisTransform.position += thisTransform.forward * forwardSpeed * Time.deltaTime;

		if(!debug) return;
		Debug.DrawLine(thisTransform.position, targetPosition,Color.white);
	}


    void OnTriggerEnter(Collider e)
    {
        Debug.Log("dddd  " +e.gameObject.tag);
        if (e.gameObject.tag.CompareTo("tagDestroyBall") == 0)
        {
            AudioSource audio = this.gameObject.GetComponent<AudioSource>();
            //audio.playOnAwake = true;
            //audio.Play();
            audio.PlayOneShot(audio.clip);
            GameObject go = GameObject.Instantiate(explosion) as GameObject;
            go.transform.position = this.transform.position;
            go.transform.rotation = this.transform.rotation;
            GameObject.Destroy(go, 0.5f);
            GameObject.Destroy(this.gameObject,0.5f);
            Destroy(e.gameObject);//Ïú»Ù¼ÓËÙÇò  
        }
    }  
}