using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private Transform[] spikes;

    [SerializeField]
    private GameObject coin;

    private bool isFalling;

    void Start()
    {
        ActivatePlatform();
    }

    void ActivateSpike()
    {
        int index = Random.Range(0, spikes.Length);

        spikes[index].gameObject.SetActive(true);
        spikes[index].DOLocalMoveY(0.7f, 1.3f).SetLoops(-1, LoopType.Yoyo).SetDelay(Random.Range(3f, 5f));  // Moves the spikes up/down from the current pos to 0.7 in 1.3f - infinite loops
    }

    void AddCoin()
    {
        GameObject c = Instantiate(coin);

        c.transform.position = transform.position;
        c.transform.SetParent(transform);
        c.transform.DOLocalMoveY(0.7f, 0f);
    }

    void ActivatePlatform()
    {
        int chance = Random.Range(0, 100);

        if(chance > 50)
        {
            int type = Random.Range(0, 8);

            switch (type)
            {
                case 0:
                    ActivateSpike();
                    break;
                case 1:
                    AddCoin();
                    break;
                case 2:
                    isFalling = true;
                    break;
                case 3:
                case 4:
                     AddCoin();
                    break;
                case 5:
                    AddCoin();
                    break;
                case 6:
                case 7:
                    AddCoin();
                    break;
            }
        }
    }

    void InvokeFalling()
    {
        gameObject.AddComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag.Equals("Player"))
        {
            if (isFalling)
            {
                isFalling = false;
                Invoke("InvokeFalling", 2f);
            }
        }

    }
}
