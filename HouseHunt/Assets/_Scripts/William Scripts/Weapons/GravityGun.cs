using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GravityGun : MonoBehaviour
{

    public float pickupRange = 100f;
    public Camera playerCam;
    public GameObject itemLocation;
    public GameObject item;
    public bool hasItem = false;
    public LayerMask itemMask;
    public GameObject prevItem;

    // Start is called before the first frame update
    void Start()
    {
        playerCam = this.GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && hasItem == false)
        {
            Vector3 rayOrigin = playerCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));

            RaycastHit hit;
            Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, pickupRange, itemMask))
            {

                Debug.Log(hit.collider.name);
                //                    hit.collider.GetComponent<PickupObject>().isPickedUp();
                if (hit.collider.GetComponent<Rigidbody>() != null)
                {
                    item = hit.collider.gameObject;
                    item.transform.SetParent(this.gameObject.transform);
                    item.GetComponent<Rigidbody>().isKinematic = true;
                    item.transform.position = itemLocation.transform.position;
                    item.GetComponent<NavMeshAgent>().enabled = false;
                    hasItem = true;

                }
            }
        }
        else if (Input.GetButtonDown("Fire1") && hasItem == true)
        {
            prevItem = item;
            item.transform.parent = null;
            item.GetComponent<Rigidbody>().isKinematic = false;
            hasItem = false;
            prevItem.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
        }
        else if (Input.GetButtonDown("Fire2") && hasItem == true)
        {
            prevItem = item;
            item.transform.parent = null;
            item.GetComponent<Rigidbody>().isKinematic = false;
            hasItem = false;
            //prevItem.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
        }
    }
}
