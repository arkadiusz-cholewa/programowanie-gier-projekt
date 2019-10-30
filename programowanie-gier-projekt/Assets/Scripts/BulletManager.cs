using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class BulletManager : MonoBehaviour
    {
      
        public Texture pistolBullet;
        public Texture shotgunBullet;
        public Texture rifleBullet;
        private static int _amountOfBullets = 6;
        void Start()
        {
           
            _amountOfBullets = WeaponManager.numberOfBullets;
        }

        private IEnumerator ReloadDelay()
        {
          
            WeaponManager.Reloading();
            yield return new WaitForSeconds(2f);

            WeaponManager.Ready();
            _amountOfBullets = WeaponManager.numberOfBullets;
            GetComponent<Text>().text = "";
        }

        void OnGUI()
        {
            _amountOfBullets = WeaponManager.numberOfBullets;
            var bulletTypes = new Texture[] { rifleBullet, pistolBullet, shotgunBullet };
            for (var j = 1; j < _amountOfBullets + 1; j++)
            {
                GUI.DrawTexture(new Rect(Screen.width - (j * 30), Screen.height - 40, 30, 30), bulletTypes[(int)WeaponManager.weaponCategory]);
            }

            if (_amountOfBullets == 0)
            {
                GetComponent<Text>().text = "Reload!";
                StartCoroutine(ReloadDelay());
            }
        }
    }
}
