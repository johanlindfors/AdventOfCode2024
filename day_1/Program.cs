var data = File.ReadAllLines("input.txt");
double distance = 0;
var lefts = new List<double>();
var rights = new List<double>();
foreach(string line in data) {
    var ints = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    lefts.Add(double.Parse(ints[0]));
    rights.Add(double.Parse(ints[1]));
}
lefts.Sort();
rights.Sort();
for(int i = 0; i < lefts.Count; i++) {
    distance += Math.Abs(rights[i]-lefts[i]);
}
System.Console.WriteLine(distance);

double similarityScore = 0;
foreach(var left in lefts) {
    similarityScore += left * rights.Count(right => right == left);
}
System.Console.WriteLine(similarityScore);