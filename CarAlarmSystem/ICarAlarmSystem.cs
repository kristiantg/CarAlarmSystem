using System;
using System.Collections.Generic;
using System.Text;

namespace CarAlarmSystem
{
    interface ICarAlarmSystem
    {
        void lockcar();
        void unlock();
        void close();
        void open();
    }
}
