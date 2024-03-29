using System.Collections.Generic;
using System.Windows.Forms;

public class NavigationStack
{
    private Stack<Form> stack = new Stack<Form>();

    public void Push(Form form)
    {
        stack.Push(form);
    }

    public Form Pop()
    {
        if (stack.Count > 0)
        {
            return stack.Pop();
        }
        return null;
    }
}
