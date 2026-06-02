using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattrens.Behavioral
{
    public class Command
    {
        public void Run()
        {
            Light light = new Light();
            ICommand lightOn = new LightOnCommand(light);
            ICommand lightOff = new LightOffCommand(light);
            RemoteControl remote = new RemoteControl();
            remote.SetCommand(lightOn);
            remote.PressButton(); // Output: Light is On
            remote.SetCommand(lightOff);
            remote.PressButton(); // Output: Light is Off
            remote.PressUndo(); // Output: Light is On
        }
    }
   
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
     public class Light 
    {
        public void On()
        {
            Console.WriteLine("Light is On");
        }
        public void Off()
        {
            Console.WriteLine("Light is Off");
        }
    }
     public class LightOnCommand : ICommand
    {
        private Light _light;
        public LightOnCommand(Light light)
        {
            _light = light;
        }
        public void Execute()
        {
            _light.On();
        }
        public void Undo()
        {
            _light.Off();
        }
    }
     public class LightOffCommand : ICommand
    {
        private Light _light;
        public LightOffCommand(Light light)
        {
            _light = light;
        }
        public void Execute()
        {
            _light.Off();
        }

        public void Undo()
        {
            _light.On();
        }
    }
     public class RemoteControl
    {
        private ICommand _command;
        public void SetCommand(ICommand command)
        {
            _command = command;
        }
        public void PressButton()
        {
            _command.Execute();
        }
        public void PressUndo()
        {
            _command.Undo();
        }
    }
}
