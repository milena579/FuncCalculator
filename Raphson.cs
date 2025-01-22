namespace Raphson;
using Functions;

public static class NewtonRaphson{
    public static double Aproximation(Function f, int steps) {
        double result = 4; 

        var df = f.Derivada();
        for(int i = 0; i < steps; ++i)
        {
            result = result - f[result] / df[result];
        }

        return result;
    }
}