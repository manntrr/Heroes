namespace NUnit.Framework;

public class TestCaseDataDictionary : Dictionary<String, Object[]>
{
    public static readonly String TestCaseDataString = "TestCaseData";
    public static readonly String DescriptionString = "Description";
    public static readonly String CategoryString = "Category";
    public static readonly String ConstructorString = "Constructor";
    public static readonly String InitializorString = "Initializor";
    public static readonly String AccessorString = "Accessor";
    public static readonly String TestCaseIdString = "TestCaseId";
    public TestCaseDataDictionary() : base() { }
    public TestCaseDataDictionary(String TestCaseElement, Object[] TestCaseData) => Add(TestCaseElement, TestCaseData);
    public TestCaseDataDictionary(Tuple<String, Object[]> TestCase) => Add(TestCase.Item1, TestCase.Item2);
    public TestCaseDataDictionary(List<Tuple<String, Object[]>> TestCases)
    {
        for (int index = 0; index < TestCases.Count; index++)
        {
            Add(TestCases[index].Item1, TestCases[index].Item2);
        }
    }
    public TestCaseDataDictionary(String[] TestCaseDescriptions, String[] TestCaseCategories, String[] TestCaseIds, TestCaseData[] TestCaseData)
    {
        int max = int.Max(TestCaseData.Length, int.Max(TestCaseIds.Length, int.Max(TestCaseCategories.Length, TestCaseDescriptions.Length)));
        if (TestCaseData.Length != max || TestCaseIds.Length != max || (TestCaseCategories.Length != max && TestCaseCategories.Length != 1) || TestCaseDescriptions.Length != max) throw new InvalidArgumentException("invalid combination of argument array lengths!");
        List<String> descriptions = [];
        List<String> categories = [];
        List<String> caseIds = [];
        List<TestCaseData> data = [];
        for (int index = 0; index < max; index++)
        {
            descriptions.Add(TestCaseDescriptions[index]);
            if (TestCaseCategories.Length > 1)
            {
                categories.Add(TestCaseCategories[index]);
            }
            else if (index == 0)
            {
                categories.Add(TestCaseCategories[index]);
            }
            caseIds.Add(TestCaseIds[index]);
            data.Add(TestCaseData[index]);
        }
        Add(DescriptionString, descriptions.ToArray<String>());
        Add(CategoryString, categories.ToArray<String>());
        Add(TestCaseIdString, caseIds.ToArray<String>());
        Add(TestCaseDataString, data.ToArray<TestCaseData>());
    }
}
