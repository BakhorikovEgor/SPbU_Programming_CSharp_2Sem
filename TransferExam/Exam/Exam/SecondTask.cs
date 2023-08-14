namespace Exam;

/// <summary>
/// Methods for second task of transfer exam
/// </summary>
public static class SecondTask
{
    /// <summary>
    /// Check if given string brackets balanced.
    /// </summary>
    /// <param name="input"> Given string. </param>
    public static bool IsBalanced(string input)
    {
        var stack = new LinkedListStack();
        foreach (var item in input)
        {
            if (IsOpeningBracket(item))
            {
                stack.Push(item);
            }
            else if (IsClosingBracket(item))
            {
                if (stack.IsEmpty() || !CheckMatching(stack.Pop(), item))
                {
                    return false;
                }
            }
        }

        return stack.IsEmpty();
    }

    static bool IsOpeningBracket(char c)
        => c == '(' || c == '[' || c == '{';

    static bool IsClosingBracket(char c)
        => c == ')' || c == ']' || c == '}';

    static bool CheckMatching(char opening, char closing)
        => (opening == '(' && closing == ')') ||
           (opening == '[' && closing == ']') ||
           (opening == '{' && closing == '}');
}
