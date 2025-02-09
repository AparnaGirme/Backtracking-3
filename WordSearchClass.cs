public class Solution
{
    int[][] dirs;
    int m, n;
    public bool Exist(char[][] board, string word)
    {
        if (board == null || board.Length == 0)
        {
            return false;
        }

        dirs = [[-1, 0], [1, 0], [0, -1], [0, 1]];
        m = board.Length;
        n = board[0].Length;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (board[i][j] == word[0])
                {
                    if (Backtrack(board, i, j, word, 0))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public bool Backtrack(char[][] board, int row, int column, string word, int index)
    {
        //base
        if (index == word.Length)
        {
            return true;
        }
        if (row < 0 || row == m || column < 0 || column == n || board[row][column] == '#')
        {
            return false;
        }
        if (board[row][column] == word[index])
        {
            char temp = board[row][column];
            board[row][column] = '#';
            //logic
            foreach (var dir in dirs)
            {
                var nr = row + dir[0];
                var nc = column + dir[1];
                if (Backtrack(board, nr, nc, word, index + 1))
                {
                    return true;
                }
            }
            board[row][column] = temp;
        }
        return false;
    }
}