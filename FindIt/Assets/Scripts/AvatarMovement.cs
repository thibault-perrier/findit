using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarMovement : MonoBehaviour
{
    public Vector3 direction = new Vector3(0, 0, 0);
    [SerializeField] private float avatarSpeed = 0.5f;
    private Camera mainCamera;
    private bool canBeDeleted = false;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

        //TODO
        //Do an avatar randomization on start
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction.normalized * Time.deltaTime * avatarSpeed);
        if (IsOutOfCameraView())
            Destroy(gameObject, 1.0f);
    }

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection;
    }

    bool IsOutOfCameraView()
    {
        // Calculate the object's position in viewport coordinates
        Vector3 viewportPos = mainCamera.WorldToViewportPoint(transform.position);

        // Check if the object is outside the camera viewport
        if (viewportPos.x < 0 || viewportPos.x > 1 || viewportPos.y < 0 || viewportPos.y > 1 || viewportPos.z < 0)
        {
            if (!canBeDeleted)
                return false;
            return true;
        }

        canBeDeleted = true;
        return false;
    }
}
