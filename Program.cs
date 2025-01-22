using Functions;
using Raphson;

Function f = (Function.x * Function.x * Function.x) -4 *
(Function.x * Function.x) -6 * Function.x + 12;

Console.WriteLine("Digite o valor de x: ");
int value = int.Parse(Console.ReadLine());

Console.WriteLine($"Resultado normal: {f[value]}");
Console.WriteLine($"Derivada: {f.Derivada()[value]}");


Console.WriteLine("\nDigite a quantidade de iterações: ");
int passes = int.Parse(Console.ReadLine());

Console.WriteLine($"\nResultado aproximação método de Newton Raphson: {NewtonRaphson.Aproximation(f, passes)}");