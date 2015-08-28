using UnityEngine;
using System.Collections;

public class ObsticleMovement : MonoBehaviour
{
    [Header("Obsticle Movment Variables")]
    public Transform[] Waypoints;
    public float speed;
    private int Marker = 0;

    private ObsticleRotation reverseRotation;

    void Start()
    {
        reverseRotation = this.GetComponent<ObsticleRotation>();
    }

	// Update is called once per frame
	void Update ()
    {
        MoveObsticle();
    }

    void MoveObsticle()
    {

        transform.position = Vector3.MoveTowards(transform.position, Waypoints[Marker].transform.position, speed * Time.deltaTime);

        if (transform.position == Waypoints[Marker].transform.position)
        {
            Marker++;
            reverseRotation.ReverseRotation = false;
        }
        if (Marker == Waypoints.Length)
        {
            Marker = 0;
            reverseRotation.ReverseRotation = true;
        }
    }
}
