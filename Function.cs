namespace Functions;

public abstract class Function
{
    public abstract Function Derivada();
    public static LinearFunction x = new LinearFunction();

    public abstract double this[double Value]{get;}
    
    public static Function operator + (Function F1, Function F2)
    {
        return new SumFunction(F1, F2);
    }
    
    public static Function operator + (Function F1, double d)
    {
        return F1 + new ConstantFunction(d);
    }
    public static Function operator - (Function F1, Function F2)
    {
        return new SumFunction(F1, F2 * -1);
    }
    
    public static Function operator - (Function F1, double d)
    {
        return F1 + new ConstantFunction(-d);
    }

    public static Function operator * (Function F1, Function F2)
    {
        return new MultFunction(F1, F2);
    }

    public static Function operator * (Function F1, double d)
    {
        return F1 * new ConstantFunction(d);
    }

    public static explicit operator double(Function CF) => CF[0];
    public static implicit operator Function(double d) => new ConstantFunction(d);
    public static implicit operator Function(int d) => new ConstantFunction(d);
}

public class ConstantFunction(double c) : Function
{
    public override double this[double Value] => c;

    public override Function Derivada()
    {
        return 0;
    }
}

public class LinearFunction() : Function
{
    public override double this[double Value] { 
        get 
        {
            return Value;
        }
    }

    public override Function Derivada()
    {
        return 1;
    }
}

public class SumFunction(Function F1, Function F2) : Function
{
    public override double this[double Value] => F1[Value] + F2[Value];
    public override Function Derivada()
    {
        return F1.Derivada() + F2.Derivada();
    }
}

public class MultFunction(Function F1, Function F2) : Function
{
    public override double this[double Value] => F1[Value] * F2[Value];

    public override Function Derivada()
    {
       return (F1.Derivada() * F2) + (F2.Derivada() * F1);
    }
}