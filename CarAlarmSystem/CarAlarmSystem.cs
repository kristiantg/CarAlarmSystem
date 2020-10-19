using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Text;
using System.Threading;

namespace CarAlarmSystem
{
    class CarAlarmSystem : ICarAlarmSystem
    {
        public bool IsOpen { get; set; }        //opened
        public bool IsLocked { get; set; }      //unlocked
        public bool IsFlashing { get; set; }    //flash
        public bool Sound { get; set; }         //sound
        public bool IsArmed { get; set; }       //armed

        public CarAlarmSystem(bool isOpen, bool isLocked, bool isFlashing, bool sound, bool isArmed)
        {
            IsOpen = isOpen;
            IsLocked = isLocked;
            IsFlashing = isFlashing;
            Sound = sound;
            IsArmed = isArmed;
        }

        public void ActiveCAS()
        {
            close();
            tick(2000);
            lockcar();
            tick(30000);
        }

        public void close()
        {
            this.IsOpen = false;
        }

        public void lockcar()
        {
            this.IsArmed = true;
            this.IsLocked = true;
        }

        public void unlock()
        {
            Console.WriteLine("Unlocking");
            this.IsArmed = false;
            this.IsFlashing = false;
            this.Sound = false;
            this.IsLocked = false;
        }

        public void open()
        {
            if (this.IsArmed == true)
            {
                this.Sound = true;
                Console.Out.WriteLine("**!!!**");
                tick(3000);
                this.Sound = false;
                this.IsFlashing = true;
                Console.Out.WriteLine("**Flashing!!!**");
                tick(30000);
                this.IsFlashing = false;
                this.IsOpen = true;
            }
            else
            {
                Console.Out.WriteLine("No alarm.");
                this.IsOpen = true;
            }
        }

        public void tick(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }
    }
}
