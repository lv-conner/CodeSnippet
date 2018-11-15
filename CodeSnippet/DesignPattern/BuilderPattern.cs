using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippet.DesignPattern
{
    public class ToyCar
    {
        public ToyCar(string name,string vehicleShape)
        {
            Name = name;
            VehicleShape = vehicleShape;
        }
        public string VehicleShape { get;set;}
        public string Name { get; set; }
    }

    public interface IToyCarbuilder
    {
        ToyCar Build();
    }

    public class DefaultToyCarBuilder : IToyCarbuilder
    {

        public DefaultToyCarBuilder(string name)
        {
            Name = name;
        }
        public string VehicleShape { get; set; }
        public string Name { get; set; }
        public ToyCar Build()
        {
            return new ToyCar(Name, VehicleShape);
        }
    }

    public static class ToyCarBuilderExtension
    {
        public static IToyCarbuilder UseName(this IToyCarbuilder toyCarbuilder,string name)
        {
            return toyCarbuilder;
        }
    }
}
