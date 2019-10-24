using System;
using UnityEditor;

public static class WeaponManager
{
    // Start is called before the first frame update
    public static int numberOfBullets = 6;
    public static bool isReloading = false;

    public enum WeaponCategory { Rifle, Pistol, Shotgun };

    public static WeaponCategory weaponCategory = WeaponCategory.Pistol;

    public static void Shot()
    {
        numberOfBullets--;
    }

    public static void RerollWeapon()
    {
        var values = Enum.GetValues(typeof(WeaponCategory));
        var random = new Random();
        var randomWeaponCategory = (WeaponCategory)values.GetValue(random.Next(values.Length));
        weaponCategory = randomWeaponCategory;
        numberOfBullets = GetAmountOfBullets(weaponCategory);
    }

    public static void UseShotgun()
    {
        weaponCategory = WeaponCategory.Shotgun;
    }

    public static void UsePistol()
    {
        weaponCategory = WeaponCategory.Pistol;
    }

    public static void UseRifle()
    {
        weaponCategory = WeaponCategory.Rifle;
    }


    public static void Reloading()
    {
        isReloading = true;
        UsePistol();
    }

    public static void Ready()
    {
        numberOfBullets = GetAmountOfBullets(weaponCategory);
        isReloading = false;
    }

    private static int GetAmountOfBullets(WeaponCategory weaponCategory)
    {
        switch (weaponCategory)
        {
            case WeaponCategory.Pistol: return 6;
            case WeaponCategory.Shotgun: return 2;
            case WeaponCategory.Rifle: return 18;
            default: return 6;
        }
    }
}
