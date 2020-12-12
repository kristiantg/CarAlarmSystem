using System;
using System.Collections.Generic;
using System.Text;

namespace CAS
{
    interface ICarAlarmSystem
    {
        void lockcar();
        void unlock();
        void close();
        void open();
        void tick();
    }
}
