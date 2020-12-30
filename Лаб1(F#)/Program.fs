//Для использования классов Math и Console
open System

//Тип решения биквадратного уравнения
type QuadRootResult =
 | NoRoots
 | OneRoot of double
 | TwoRoots of double * double //кортеж из двух double
 | ThreeRoots of double * double * double
 | FourRoots of double * double * double * double

let CalculateQuadRoots(a:double, b:double, c:double):QuadRootResult =
 let D = b*b - 4.0*a*c;
 if D < 0.0 then NoRoots
 else if D = 0.0 then
    let xx = -b / (2.0 * a);
    if xx > 0.0 then TwoRoots(Math.Sqrt(xx), Math.Sqrt(xx)) 
    else if xx = 0.0 then OneRoot(0.0)
    else NoRoots
 else
    let sqrtD = Math.Sqrt(D)
    let xx1 = (-b - sqrtD) / (2.0 * a);
    let xx2 = (-b + sqrtD) / (2.0 * a);
    if xx1 < 0.0 && xx2 < 0.0
        then NoRoots
    else if xx1 < 0.0 && xx2 > 0.0
        then TwoRoots(-Math.Sqrt(xx2), Math.Sqrt(xx2))
    else if xx2 < 0.0 && xx1 > 0.0
        then TwoRoots(-Math.Sqrt(xx1), Math.Sqrt(xx1))
    else if xx1 < 0.0 && xx2 = 0.0 || xx1 = 0.0 && xx2 < 0.0 || xx1 = 0.0 && xx2 = 0.0
        then OneRoot(0.0)
    else if xx1 > 0.0 && xx2 = 0.0
        then ThreeRoots(-Math.Sqrt(xx1), Math.Sqrt(xx1), 0.0)
    else if xx1 = 0.0 && xx2 > 0.0
        then ThreeRoots(-Math.Sqrt(xx2), Math.Sqrt(xx2), 0.0)
    else if xx1 > 0.0 && xx2 > 0.0
        then FourRoots(-Math.Sqrt(xx2), Math.Sqrt(xx2), -Math.Sqrt(xx1), Math.Sqrt(xx1))
    else NoRoots

///Вывод корней (тип unit - аналог void)
let PrintQuadRoots(a:double, b:double, c:double):unit =
 Console.WriteLine();
 printf "Коэффициенты: a=%A, b=%A, c=%A. " a b c
 Console.WriteLine();
 let root = CalculateQuadRoots(a,b,c)
 //Оператор сопоставления с образцом
 let textResult = match root with
    | NoRoots -> "Действительных корней нет"
    | OneRoot(rt) -> "Один корень: \n" + rt.ToString()
    | TwoRoots(rt1,rt2) -> "Два корня: \n" + rt1.ToString() + " и " + rt2.ToString()
    | ThreeRoots(rt1, rt2, rt3) -> "Три корня: \n" + rt1.ToString() + ", " + rt2.ToString() + ", " + rt3.ToString()
    | FourRoots(rt1, rt2, rt3, rt4) -> "Четыре корня: \n" + rt1.ToString() + ", " + rt2.ToString() + ", " + rt3.ToString() + ", " + rt4.ToString()
 printfn "%s" textResult

[<EntryPoint>]
let main argv =
 //Тестовые данные
 //0 корней
 let a0 = 1.0;
 let b0 = 0.0;
 let c0 = -4.0;
 //1 корень
 let a1 = 1.0;
 let b1 = 0.0;
 let c1 = 0.0;
 //2 корня
 let a2 = 1.0;
 let b2 = 0.0;
 let c2 = -7.0;
 //3 корня
 let a3 = 8.0;
 let b3 = -16.0;
 let c3 = 0.0;
 //4 корня
 let a4 = 27.0;
 let b4 = -19.0;
 let c4 = 1.0;

 PrintQuadRoots(a0, b0, c0)
 PrintQuadRoots(a1,b1,c1)
 PrintQuadRoots(a2,b2,c2)
 PrintQuadRoots(a3,b3,c3)
 PrintQuadRoots(a4,b4,c4)

 //|> ignore - перенаправление потока с игнорирование результата вычисления
 Console.ReadLine() |> ignore
 0 // возвращение целочисленного кода выхода