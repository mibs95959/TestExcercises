using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ByTestDataId : By
{
    private readonly string elementType;
    private readonly string testId;

    public ByTestDataId(string elementType, string testId)
    {
        this.elementType = elementType;
        this.testId = testId;
    }

    public override IWebElement FindElement(ISearchContext context)
    {
        return context.FindElement(By.CssSelector($"{elementType}[data-testid='{testId}']"));
    }

    public override ReadOnlyCollection<IWebElement> FindElements(ISearchContext context)
    {
        return context.FindElements(By.CssSelector($"{elementType}[data-testid='{testId}']"));
    }
}
