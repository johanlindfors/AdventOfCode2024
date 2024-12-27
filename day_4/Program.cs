using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    /*
    S  S  S
     A A A
      MMM
    SAMXMAS
      MMM
     A A A
    S  S  S
    */

    void Run() {
        var data = File.ReadAllLines("test-data1.txt");
        var rows = data.Length;
        var cols = data[0].Length;
        var grid = new char[cols, rows];
        for(int y = 0; y < rows; y++) {
            for(int x = 0; x < cols; x++) {
                grid[x, y] = '.';
            }
        }
        var found = 0;
    
        var XMASTest = (int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4) => {
            if (x1 < 0 || x1 >= cols ||
                y1 < 0 || y1 >= rows ) {
                return 0;
            }
            var result = data[y1][x1] == 'S' &&
                         data[y2][x2] == 'A' &&
                         data[y3][x3] == 'M' &&
                         data[y4][x4] == 'X' ? 1 : 0;
            if(result == 1) {
                grid[x1, y1] = 'S';
                grid[x2, y2] = 'A';
                grid[x3, y3] = 'M';
                grid[x4, y4] = 'X';
            }
            return result;
        };

        // var X_MASTest = (int x1, int y1, int x2, int y2, int x3, int y3) => {
        //     if (x1 < 0 || x3 >= cols ||
        //         y1 < 0 || y3 >= rows ) {
        //         return false;
        //     }
        //     var result = grid[x1, y1] == 'M' && grid[x1, ]
        //                  grid[x2, y2] == 'A' &&
        //                  grid[x3, y3] == 'S';
    
        // };

        var Test2 = (int x, int y) => {
            if(x < 1 || x > cols - 2 ||
               y < 1 || y > rows - 2) {
                return;
            }
            var result = data[y-1][x-1] == 'M' &&
                         data[y+1][x-1] == 'M' &&
                         data[y][x] == 'A' &&
                         data[y-1][x+1] == 'S' &&
                         data[y+1][x+1] == 'S' ? 1 : 0;
            if(result == 1) {
                grid[x-1, y-1] = 'M';
                grid[x-1, y+1] = 'M';
                grid[x, y] = 'A';
                grid[x+1, y+1] = 'S';
                grid[x+1, y-1] = 'S';
                found += result;
            }
        };

        var Test1 = (int x, int y) => {
            found += XMASTest(x-3, y  , x-2, y  , x-1, y  , x, y);
            found += XMASTest(x-3, y-3, x-2, y-2, x-1, y-1, x, y);
            found += XMASTest(x-3, y+3, x-2, y+2, x-1, y+1, x, y);

            found += XMASTest(x, y-3, x, y-2, x, y-1, x, y);
            found += XMASTest(x, y+3, x, y+2, x, y+1, x, y);

            found += XMASTest(x+3, y-3, x+2, y-2, x+1, y-1, x, y);
            found += XMASTest(x+3, y, x+2, y, x+1, y, x, y);
            found += XMASTest(x+3, y+3, x+2, y+2, x+1, y+1, x, y);
        };

        for(int y = 0; y < rows; y++) {
            for(int x = 0; x < cols; x++) {
                Test2(x, y);
            }
        }

        for(int y = 0; y < rows; y++) {
            for(int x = 0; x < cols; x++) {
                Console.Write(grid[x, y]);
            }
            Console.WriteLine();
        }

        System.Console.WriteLine(found);
    }

    private static void Main(string[] args)
    {
        var program = new Program();
        program.Run();
    }
}