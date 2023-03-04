using _07.Military.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Military.Classes
{
    public class Mission : IMission
    {
        private string state;

        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            State = state;
        }

        public string CodeName { get; }
        public string State
        {
            get { return state; }
            private set
            {
                if(value != "inProgress" && value != "Finished")
                {
                    return;
                }
                state = value;
            }
        }

        public void CompleteMission()
        {
            State = "Finished";
        }

        public override string ToString()
            => $"Code Name: {CodeName} State: {State}";
    }
}
