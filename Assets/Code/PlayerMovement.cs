using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private bool facingRight = true;

    private CharacterController controller;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Handle pergerakan horizontal dan vertikal
        float dirX = Input.GetAxis("Horizontal");
        float dirY = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(dirX * speed, dirY * speed, 0);
        controller.Move(moveDirection * Time.deltaTime);

        // Clamp posisi (jika diperlukan, sesuaikan clamping X dan Y sesuai kebutuhan)
        float clampX = Mathf.Clamp(transform.position.x, -10, 100);
        float clampY = Mathf.Clamp(transform.position.y, -4f, 0f);
        transform.position = new Vector2(clampX, clampY);

        if (dirX > 0 || dirX < 0 || dirY < 0 || dirY > 0)
        {
            animator.SetBool("Move", true);
        }
        else if (dirX == 0 || dirY == 0)
        {
            animator.SetBool("Move", false);
        }
        // Cek arah dan flip sprite jika perlu
        if (dirX > 0 && !facingRight)
        {
            Flip();
        }
        else if (dirX < 0 && facingRight)
        {
            Flip();
        }

        //Bacok anim
        if (dirX == 0 && dirY == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("Bacok");
            }
        }

        RaycastAsset();
    }

    void RaycastAsset()
    {
        // Arah raycast ke depan sesuai dengan arah karakter (kanan atau kiri)
        Vector2 raycastDirection = facingRight ? Vector2.right : Vector2.left;

        // Raycast untuk mendeteksi objek di depan
        RaycastHit2D hit = Physics2D.Raycast(transform.position, raycastDirection, 1f);

        // Menggambar raycast dengan warna
        Debug.DrawRay(transform.position, raycastDirection * 1f, Color.red);

        // Jika terdapat objek yang terkena raycast
        if (hit.collider != null)
        {
            Debug.Log("Ada objek di depan: " + hit.collider.name);

            AssetManager assetManager = hit.transform.GetComponent<AssetManager>();
            assetManager.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
               assetManager.SetAction(true);
               assetManager.SetProject(true);
            }
        }
        else
        {
            // Mengambil semua objek dengan komponen AssetManager
            AssetManager[] assetManagers = FindObjectsOfType<AssetManager>();

            // Nonaktifkan Tittle pada semua objek dengan AssetManager
            foreach (AssetManager assetManager in assetManagers)
            {
                assetManager.SetActive(false);
                assetManager.SetAction(false);
            }
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
