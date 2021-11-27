using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    // Singleton design pattern
    private static LevelController _instance; // will hold the object of Level Controller
    public static LevelController Instance { get { return _instance; } }
    // Public variables
    [SerializeField] private Text itemUIText;
    // Private variables
    private int totalItemsQty = 0, itemsCollectedQty = 0;
    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        totalItemsQty = GameObject.FindGameObjectsWithTag("Item").Length;
        // Debug.Log("There are: " + totalItemsQty + " items in this level.");
        UpdateItemUI();
    }

    private void UpdateItemUI()
    {
        itemUIText.text = itemsCollectedQty + " / " + totalItemsQty;
    }

    public void PickedUpItem()
    {
        itemsCollectedQty++;
        // Debug.Log("Number of items collected: " + itemsCollectedQty);
        UpdateItemUI();
    }

    public void CheckLevelEnd()
    {
        if(itemsCollectedQty == totalItemsQty)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
