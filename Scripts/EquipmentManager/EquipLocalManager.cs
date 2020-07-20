// This script is used to identify the location of each certain item in correlation to the player.
using UnityEngine;
using UnityEngine.UI;
public class EquipLocalManager : MonoBehaviour {

    #region Singlton
    public static EquipLocalManager instance;
    private void Awake()
    {
        instance = this;
    }

    #endregion

    // Hands
    public GameObject[] Hands;

    // In game vars
    public SpriteRenderer riflePos;
    public SpriteRenderer armourPos;

    // Inventory vars
    public Image clothingA;
    public Image weaponRifle;

    public void SetLocalPos(Equipment _item, Sprite _newSprite)
    {
        switch (_item.equipmentSlot) {
            case EquipmentSlot.Gun:
                riflePos.sprite = _newSprite;
                weaponRifle.sprite = _newSprite;
                weaponRifle.enabled = true;
                Hands[0].transform.localPosition = new Vector3(-0.257f, -0.038f, 0f);
                Hands[1].transform.localPosition = new Vector3(0.218f, -0.142f, 0f);
                break;
            case EquipmentSlot.BodyArmor:
                armourPos.sprite = _newSprite;
                clothingA.sprite = _newSprite;
                clothingA.enabled = true;
                break;

            default:
                Debug.Log("This item has not be implemented");
                break;
        }

    }

}
