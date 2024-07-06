using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private float parallaxSpeed;

    private Transform cam;
    private Vector3 lastCameraPos;
    private float textureUnitSizeX;

    void Start()
    {
        cam = Camera.main.transform;
        lastCameraPos = cam.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }
    void LateUpdate()
    {
        Vector3 deltaMove = cam.position - lastCameraPos;
        transform.position += deltaMove * parallaxSpeed;
        lastCameraPos = cam.position;

        if (Mathf.Abs(cam.position.x - transform.position.x) >= textureUnitSizeX)
        {
            float offsetPositionX = (cam.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(cam.position.x + offsetPositionX, transform.position.y);
        }
    }
}