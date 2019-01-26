using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public GameObject pickuplocation;
    public Rigidbody rb;
    public bool isPicked = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        pickuplocation = GameObject.FindGameObjectWithTag("PickUpLocation");
    }

    // Update is called once per frame
    void Update()
    {
        if (isPicked == true)
        {
            this.gameObject.transform.position = pickuplocation.transform.position;
        }
    }

    public void isPickedUp()
    {
        rb.useGravity = false;

        //isPicked = true;
        //this.gameObject.transform.position = pickuplocation.transform.position;

    }
    public IEnumerator pick()
    {
        yield return new WaitForSeconds(0.5f);

    }

}
