using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CodeSnippet.DesignPattern
{

    public abstract class Vehicle
    {
        public string Material { get; set; }
        public abstract void Assembly();
    }
    public abstract class Chassis
    {
        public string Material { get; set; }
        public abstract void Build();
    }
    public class Car
    {
        public Car(ICarMaterialFactory carMaterialFactory)
        {
            Vehicle = carMaterialFactory.CreateVehicle();
            Chassis = carMaterialFactory.CreateChassis();
        }
        public void Build()
        {
            Vehicle.Assembly();
            Chassis.Build();
        }
        public Vehicle Vehicle { get; protected set; }
        public Chassis Chassis { get; protected set; }
    }
    /// <summary>
    /// 抽象工厂接口
    /// </summary>
    public interface ICarMaterialFactory
    {
        Vehicle CreateVehicle();
        Chassis CreateChassis();
    }

    /// <summary>
    /// 实际工厂
    /// </summary>
    public class SqureCarMatrialFactory : ICarMaterialFactory
    {
        public Chassis CreateChassis()
        {
            return new SqureChassis();
        }

        public Vehicle CreateVehicle()
        {
            return new SqureVehicle();
        }
    }
    /// <summary>
    /// 实际工厂。
    /// </summary>
    public class CircleMatrialFactory : ICarMaterialFactory
    {
        public Chassis CreateChassis()
        {
            return new CircleChassis();
        }

        public Vehicle CreateVehicle()
        {
            return new CircleVehicle();
        }
    }

    public class SqureVehicle : Vehicle
    {
        public override void Assembly()
        {
            Console.WriteLine("Squre");
        }
    }

    public class CircleVehicle : Vehicle
    {
        public override void Assembly()
        {
            Console.WriteLine("Circle");
        }
    }

    public class SqureChassis : Chassis
    {
        public override void Build()
        {
            Console.WriteLine("From top to bottom");
        }
    }
    public class CircleChassis : Chassis
    {
        public override void Build()
        {
            Console.WriteLine("From bottom to top");
        }
    }


    public class ClientAbstractFactory
    {
        static void Test()
        {
            //传入的具体工厂可以通过反射获取。
            var car = new Car(new SqureCarMatrialFactory());
            car.Build();
        }
    }

}









