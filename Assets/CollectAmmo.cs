using UnityEngine;

public class CollectAmmo : MonoBehaviour
{
    public int PlayerAmmo = 0;
    public GameObject AmmoBox;
    public GameObject Target;
    public bool won = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && PlayerAmmo > 0)
        {
            Ray ray =  Camera.main.ViewportPointToRay(new Vector3(0.5f ,0.5f ,0.0f));
            PlayerAmmo--;
            Debug.Log("PlayerAmmo");
            RaycastHit result; 
            bool hit = Physics.Raycast(ray, out result);
            if (result.collider.gameObject.name == "Target")
            {
                GameObject g = result.collider.gameObject;
                Animation a = g.transform.parent.GetComponent<Animation>();
                a.Play("LowerBridge");
                won = true;
            }
        }

        if (PlayerAmmo < 1 && !won  )
        {
            AmmoBox.SetActive(true);
        }

    }

    public void AmmoUp(int num)
    {
        PlayerAmmo += num;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "AmmoBox")
        {
            AmmoUp(20);
            Debug.Log(PlayerAmmo);
            AmmoBox.SetActive(false);
        }
    }
}
