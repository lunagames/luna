using UnityEngine;
using System.Collections;

public class ObsticleRotation : MonoBehaviour
{

    [Header("Rotation Values")]
    public float rotationSpeed;

    private bool reverseRotation;
    public bool ReverseRotation
    {
        get { return reverseRotation; }
        set { reverseRotation = value; }
    }
	
	// Update is called once per frame
	void Update ()
    {

        RotateObject();
    }

    public void RotateObject()
    {
        if (reverseRotation == true)
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
        
    }


}
