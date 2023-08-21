namespace MG.Application.AspnetBoilerPlate._8._1._0.PlaceHolders;

public static class MatchingBrackets
{
    private static Dictionary<char, char> _pairs = new Dictionary<char, char> 
    {
        { '(', ')' },
        { '[', ']' },
        { '{', '}' },
    };
    public static bool IsPaired(string input)
    {

        // If input is empty string then return true
        if (input.Count() == 0) { return true;}

        Stack<char> brackets = new Stack<char>();

        // Loop through each character
        foreach (char i in input)
        {
            // If it is an opening bracket, push it to the stack
            if(_pairs.ContainsKey(i)){
                brackets.Push(i);
            }
            // If it is an closing bracket, pop it
            else if(_pairs.Values.Contains(i))
            {
                if(brackets.Count == 0) return false;

                var openingBracket = brackets.Pop();
                // If it isn't pair of the last opening bracket return false
                if(_pairs[openingBracket] != i) 
                {
                    return false;
                }
            }
        }
        // The stack should be empty in case all brackets are closed
        return brackets.Count == 0;
    }
}