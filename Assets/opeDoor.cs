using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    Transform doorTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorTransform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
        {
            GameObject parent = transform.parent.gameObject;       
            Animation animation = parent.GetComponent<Animation>();       
            animation.Play("OpenDoor");
        }

    void OnTriggerExit(Collider other)
        {
            GameObject parent = transform.parent.gameObject;       
            Animation animation = parent.GetComponent<Animation>();       
            animation.Play("Close");
        }
}
