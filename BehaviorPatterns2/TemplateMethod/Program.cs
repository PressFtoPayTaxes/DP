using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    abstract class Weapon
    {
        public void UseWeapon() // Template method
        {
            TakeInHand();
            OpenStore();
            ChargeWeapon();
            Shoot();
        }

        public virtual void TakeInHand()
        {
            Console.WriteLine("Weapon is taken in hand");
        }
        
        public virtual void OpenStore()
        {
            Console.WriteLine("The store is opened");
        }

        public virtual void ChargeWeapon()
        {
            Console.WriteLine("Weapon charged with bullets");
        }

        public virtual void Shoot()
        {
            Console.WriteLine("Shooting");
        }
    }

    class Pistol : Weapon
    {
        public override void ChargeWeapon()
        {
            Console.WriteLine("Weapon charged with pistol bullets");
        }
    }

    class Shotgun : Weapon
    {
        public override void ChargeWeapon()
        {
            Console.WriteLine("Weapon charged with shotgun bullets");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Pistol pistol = new Pistol();
            Console.WriteLine("Shooting with pistol");
            pistol.UseWeapon();

            Console.WriteLine();

            Shotgun shotgun = new Shotgun();
            Console.WriteLine("Shooting with shotgun");
            shotgun.UseWeapon();
        }
    }
}
