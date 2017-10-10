using UnityEngine;

public class CameraController : MonoBehaviour {
	public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Boundary boundary;
    public float speed = 1;

    Rigidbody rb;
    Vector2 hotSpot = Vector2.zero;

    [System.Serializable]
	public class Boundary
	{
	    public float xMin, xMax, yMin, yMax, zMin, zMax;
	}

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

    void Awake ()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        float mouseWheel = Input.GetAxis ("Mouse ScrollWheel");

        Vector3 movement = new Vector3 (moveHorizontal, -mouseWheel * 10, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3 
        (
            Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 
            Mathf.Clamp (rb.position.y, boundary.yMin, boundary.yMax),
            Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
        );
    }
}