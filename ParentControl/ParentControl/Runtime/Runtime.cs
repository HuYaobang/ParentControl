using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParentControl.Runtime
{
    public class Runtime
    {
        private int _eyes;
        private int _eating;
        private int _exercise;
        private int _shutdown;
        private TimerMethods timerMethods;

        public Runtime(int eyes, int eating, int exercise, int shutdown)
        {
            _eyes = eyes;
            _eating = eating;
            _exercise = exercise;
            _shutdown = shutdown;
            timerMethods = new TimerMethods();
            timerMethods.InitializeTimer(_eyes, _eating, _exercise, _shutdown);
        }

        public void SaveRuntimeChanges(int eyes, int eating, int exercise, int shutdown)
        {
            _eyes = eyes;
            _eating = eating;
            _exercise = exercise;
            _shutdown = shutdown;
            timerMethods = null;
            timerMethods = new TimerMethods();
            timerMethods.InitializeTimer(_eyes, _eating, _exercise, _shutdown);
        }
    }
}
