using UnityEngine;
using UnityEngine.UI;

namespace Level.FightGame
{
    [RequireComponent(typeof(AttackMenu))]
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(Image))]
    public class AttackButton : MonoBehaviour
    {
        [Tooltip("Is buttons active or not")]
        public static bool isActive;
        
        [Header("Links")]
        [Tooltip("Link to Attack Menu")]
        public AttackMenu attackMenu;
        [Tooltip("Link to Button script")]
        public Button button;
        [Tooltip("Link to button's Image")]
        public Image buttonImage;
        
        [Header("Button's settings")]
        [Tooltip("Color of button")]
        public bool isRed = true;
        [Tooltip("Button id")]
        public short id;
        

        private void Start()
        {
            CheckComponents();
            Deactivate();
        }

        //Функция проверки компонентов
        private void CheckComponents()
        {
            Debug.Log("AttackButton.CheckComponents()");
            if(button == null)
            {
                button = gameObject.GetComponent<Button>();
            }
            
            if (buttonImage == null)
            {
                buttonImage = gameObject.GetComponent<Image>();
            }

            if (attackMenu == null)
            {
                attackMenu = AttackMenu.instance;
            }
            
            if (!button|| !buttonImage|| !attackMenu)
            {
                Debug.LogError("Components are missing!");
            }
        }

        //Функция деактивирует кнопку
        public void Deactivate()
        {
            Debug.Log("AttackButton.Deactivate()");
            button.enabled = false;
            button.interactable = false;
            isActive = false;
        }
        
        //Событие при нажатии на кнопку
        public void OnClick()
        {
                Debug.Log("AttackButton.OnCLick()");
                var attack = isRed ? 1 : 0;
                attackMenu.ActivateAttackButtons(id, attack);
                Deactivate();
        }
        
        //Функция активирует кнопки
        public void Activate()
        {
            Debug.Log("AttackButton.Activate()");
            button.enabled = true;
            button.interactable = true;
            isActive = true;
        }
        
        //Функция меняет изображение кнопки
        public void EditImage(Sprite newImage)
        {
            Debug.Log("AttackButton.EditImage()");
            if (newImage)
            {
                buttonImage.sprite = newImage;
            }
        }
    }
}
