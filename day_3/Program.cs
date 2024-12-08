using System.Text.RegularExpressions;

var data = File.ReadAllText("input.txt");
char[] separators = new char[] { '(', ')', ',' };
var pattern = "mul[(][0-9]{1,3}[,][0-9]{1,3}[)]";
var sDo = "do()";
var sDont = "don't()";

var parse = new Func<string, double>(s => {
    var parts = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
    return double.Parse(parts[0]) * double.Parse(parts[1]);
});
int iDont = 0;
int iDo = 0;
while(iDont != -1 && iDo != -1) {
    iDont = data.IndexOf(sDont);
    if(iDont == -1) {
        break;
    }
    iDo = data.IndexOf(sDo, iDont);
    if(iDo == -1) {
        data = data.Remove(iDont, data.Length - iDont);
        break;
    }
    data = data.Remove(iDont, iDo - iDont + sDo.Length);
    System.Console.WriteLine($"iDont: {iDont}, iDo: {iDo}");
}
System.Console.WriteLine(data);
double sum = 0;
foreach(var match in Regex.Matches(data, pattern)) {
    var s = match.ToString().Remove(0, 4);
    sum += parse(s.ToString());
}
System.Console.WriteLine(sum);
