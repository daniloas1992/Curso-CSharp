using InterfaceAbstrata.Model.Enums;

namespace InterfaceAbstrata.Model.Entities
{
    abstract class AbstractShape : IShape
    {
        public Color Color { get; set; }
        
        public abstract double Area();
    }
}