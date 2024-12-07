var data = File.ReadAllLines("input.txt");

var checkAllIncreasing = new Func<IList<int>, bool>(s => {
    for (int i = 0; i < s.Count - 1; i++) {
        if (s[i] > s[i + 1]) {
            return false;
        }
    }
    return true;
});

var checkAllDecreasing = new Func<IList<int>, bool>(s => {
    for (int i = 0; i < s.Count - 1; i++) {
        if (s[i] < s[i + 1]) {
            return false;
        }
    }
    return true;
});

var checkDistances = new Func<IList<int>, bool>(s => {
    for (int i = 0; i < s.Count - 1; i++) {
        var distance = Math.Abs(s[i] - s[i + 1]); 
        if (distance == 0 || distance > 3) {
            return false;
        }
    }
    return true;
});

var checkAll = new Func<IList<int>, bool>(s => {
    return (checkAllIncreasing(s) || checkAllDecreasing(s)) && checkDistances(s);
});

var checkWithDampener = new Func<string, bool>(line => {
    var s = line.Split(" ").Select(int.Parse).ToList();
    if(checkAll(s)) {
        return true;
    }
    for (int i = 0; i < s.Count; i++) {
        var t = s.ToList();
        t.RemoveAt(i);
        if(checkAll(t)) {
            return true;
        }
    }
    return false;
});

var safeCount = 0;
foreach(string line in data) {
    if (checkWithDampener(line)) {
        safeCount++;
    }
}
System.Console.WriteLine(safeCount);