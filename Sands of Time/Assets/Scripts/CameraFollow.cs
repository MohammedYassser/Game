using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public float Cameraspeed;
    //determine the min and max vals in both directions where the camera can move. this is stop it 
    //from showing game edged or things u don't want to appear to the player 
    public float minX, maxX;
    public float minY, maxY;
    private float ClampX, ClampY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if (Target != null)
        {
            Vector2 newCamPosition = Vector2.Lerp(transform.position, Target.position, Time.deltaTime * Cameraspeed);
            float ClampX = Mathf.Clamp(newCamPosition.x, minX, maxX);
            float ClampY = Mathf.Clamp(newCamPosition.y, minY, maxY);
            transform.position = new Vector3(ClampX, ClampY, -10f);
        }
    }
}
