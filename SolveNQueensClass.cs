public class Solution
{
    IList<IList<string>> result;
    bool[][] grid;
    public IList<IList<string>> SolveNQueens(int n)
    {
        result = new List<IList<string>>();
        if (n == 0)
        {
            return result;
        }

        grid = new bool[n][];
        for (int i = 0; i < n; i++)
        {
            grid[i] = new bool[n];
        }

        Backtrack(0, n);
        return result;
    }

    public void Backtrack(int row, int n)
    {
        //base
        if (row == n)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < n; i++)
            {
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j])
                    {
                        sb.Append("Q");
                        continue;
                    }
                    sb.Append(".");
                }
                list.Add(sb.ToString());
            }
            result.Add(list);
            return;
        }
        //logic
        for (int i = 0; i < n; i++)
        {
            if (IsSafe(row, i, n))
            {
                grid[row][i] = true;
                Backtrack(row + 1, n);
                grid[row][i] = false;
            }
        }
    }

    public bool IsSafe(int row, int column, int n)
    {
        for (int k = 0; k < row; k++)
        {
            if (grid[k][column])
            {
                return false;
            }
        }
        int i = row;
        int j = column;
        while (i >= 0 && j >= 0)
        {
            if (grid[i][j])
            {
                return false;
            }
            i--;
            j--;
        }

        i = row;
        j = column;
        while (i >= 0 && j < n)
        {
            if (grid[i][j])
            {
                return false;
            }
            i--;
            j++;
        }

        return true;
    }
}