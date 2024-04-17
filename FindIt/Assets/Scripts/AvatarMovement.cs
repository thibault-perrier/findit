using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarMovement : MonoBehaviour
{
    public Vector3 direction = new Vector3(0, 0, 0);
    private float avatarSpeed = 5.0f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * avatarSpeed);
    }

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection;
    }
}
