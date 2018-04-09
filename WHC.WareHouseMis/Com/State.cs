using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WHC.WareHouseMis.Com
{
    public abstract class State
    {
        abstract public int GetStateId { get; }
        abstract public void Enter(StateEvent data);
        abstract public void Execute(StateEvent data);
        abstract public void Exit(StateEvent data);

    }
}
