using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Rigidbody rb;

    private bool isDead;

    private CameraFollow cameraFollow;

    Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cameraFollow = Camera.main.GetComponent<CameraFollow>();
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isDead)
        {
            if (rb.velocity.sqrMagnitude > 60)
            {
                isDead = true;
                cameraFollow.CanFollow = false;
                SoundManager.instance.GameLoseSound();
                GameplayController.instance.RestartGame();
            }
        }
    }

    IEnumerator OnTriggerEnter(Collider target)
    {
        if (target.tag.Equals("Coin"))
        {
            target.gameObject.SetActive(false);
            SoundManager.instance.PickedUpCoin();
            GameplayController.instance.IncrementScore();
        }

        if (target.tag.Equals("Spike"))
        {
            cameraFollow.CanFollow = false;
            SoundManager.instance.GameLoseSound();
            anim.SetTrigger("deadTrigger");
            yield return new WaitForSeconds(1.7f);
            gameObject.SetActive(false);
            GameplayController.instance.RestartGame();
        }
    }

    IEnumerator OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag.Equals("EndPlatform"))
        {
            yield return new WaitForSeconds(0.2f);
            anim.SetTrigger("wonTrigger");
            SoundManager.instance.GameWinSound();
            yield return new WaitForSeconds(10f);
            GameplayController.instance.RestartGame();
        }
    }
}
