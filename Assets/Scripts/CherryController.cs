using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    [SerializeField] private GameObject itemFeedback;

    private LevelController levelController;

    public void Start()
    {
        levelController = LevelController.Instance;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            // Play an "item pickup" animation
            GameObject.Instantiate(itemFeedback, this.transform.position, this.transform.rotation);

            // Increase player item pickup counter
            //LevelController.Instance.PickedUpItem(); // not good if you are calling the Instance a lot
            levelController.PickedUpItem();

            Destroy(this.gameObject);
        }
    }
}
