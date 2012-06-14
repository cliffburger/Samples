using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace BowlingByContract.Game
{
    [ContractClass(typeof(FrameContract))]
    public interface IFrame
    {
        int Score { get; }
        int Rolls { get; }
        bool IsComplete { get; }
        void Roll(int pinsKnockedDown);
    }

    public class Frame:IFrame
    {
        public int Score { get; private set;  }
        public int Rolls { get; private set;  }

        public bool IsComplete 
        { 
            get { return Rolls >=2 ;  }
        }
        public void Roll(int pinsKnockedDown)
        {
            Score += pinsKnockedDown;
            Rolls++;
        }
    }

    [ContractClassFor(typeof(IFrame))]
    internal abstract class FrameContract : IFrame
    {
        public int Score 
        { 
            get { return default(int); }
        }

        public int Rolls 
        {
            get { return default(int); }
        }

        public bool IsComplete
        {
            get { return default(bool); }
        }

        public void Roll(int pinsKnockedDown)
        {
			Contract.Requires<ArgumentException>(pinsKnockedDown >= 0, "Too Low!") ;
			Contract.Requires<ArgumentException>(pinsKnockedDown <= 10, "Too High!");

            Contract.Ensures(this.Rolls <= 2, "Cheater, you can't bowl that many times!");
        }
    }
}
