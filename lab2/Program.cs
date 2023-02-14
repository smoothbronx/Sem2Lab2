using lab2;

var firstNumber = new LongLong(2390543879);
var secondNumber = new LongLong(1024);

Console.WriteLine(firstNumber != secondNumber);
Console.WriteLine(secondNumber >= new LongLong(2048));

var resultOfSum = firstNumber + secondNumber;
resultOfSum.Display();

var resultOfSub = resultOfSum - new LongLong(64);
resultOfSub.Display();