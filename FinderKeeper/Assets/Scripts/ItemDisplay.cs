using UnityEngine;
using UnityEngine.UI;

//Display item in the list
public class ItemDisplay : MonoBehaviour {

    private ItemsDetails _item;
    [SerializeField] Image Image;

    private void Start()
    {
        Image.GetComponent<Image>().color = Color.gray;
    }

    public ItemsDetails Item
    {
        get { return _item; }
        set
        {
            _item = value;

            if (_item == null)
            {
                Image.enabled = false;
            } else
            {
                Image.sprite = _item.sprite;
                Image.enabled = true;
            }
        }
    }

	
    private void OnValidate()
    {
        if (Image == null)
            Image = GetComponent<Image>();
    }
}

