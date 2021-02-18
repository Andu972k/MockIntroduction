using System;
using System.Collections.Generic;
using System.Text;

namespace MockIntroduction
{
    public class NumberProvider
    {



        #region Methods

        public virtual int ProvideNumber()
        {
            Random random = new Random();

            return random.Next();
        }

        public virtual void ProvideException()
        {
            Console.WriteLine("Do Something");
        }

        #endregion

    }
}
