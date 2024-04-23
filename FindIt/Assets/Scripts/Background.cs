using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private GameObject avatarGO;
    [SerializeField] private List<Transform> spawnpoints = new List<Transform>();
    [SerializeField] private List<Transform> endpoints = new List<Transform>();

    private float timer = 0.0f;
    private float spawnTime = 5.0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTime)
        {
            timer = 0.0f;
            for (int index = 0; index < spawnpoints.Count; index++)
            {
                GameObject newAvatar = Instantiate(avatarGO, spawnpoints[index].position, Quaternion.identity);
                newAvatar.GetComponent<AvatarMovement>().SetDirection(endpoints[index].position - spawnpoints[index].position);
            }
        }
    }
}
