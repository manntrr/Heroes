namespace NUnit.Framework;

public class TestCasesDataDictionary : Dictionary<String, TestCaseDataDictionary>
{
    public TestCasesDataDictionary() : base() { }
    public TestCasesDataDictionary(String TestCaseName, TestCaseDataDictionary TestCaseData) => Add(TestCaseName, TestCaseData);
    public TestCasesDataDictionary(Tuple<String, TestCaseDataDictionary> TestCase) => Add(TestCase.Item1, TestCase.Item2);
    public TestCasesDataDictionary(List<Tuple<String, TestCaseDataDictionary>> TestCases)
    {
        for (int index = 0; index < TestCases.Count; index++)
        {
            Add(TestCases[index].Item1, TestCases[index].Item2);
        }
    }
    public static readonly Func<String, TestCasesDataDictionary, TestCaseData[]> TestCaseDataArray = (testName, testData) =>
        {
            List<TestCaseData> result = [];
            if (testData.ContainsKey(testName)) for (int i = 0; i < testData[testName][TestCaseDataDictionary.TestCaseDataString].Length; i++)
                {
                    TestCaseData data = (TestCaseData)testData[testName][TestCaseDataDictionary.TestCaseDataString][i];
                    data.SetName(testName).SetDescription((String)testData[testName][TestCaseDataDictionary.DescriptionString][testData[testName][TestCaseDataDictionary.DescriptionString].Length > 1 ? i : 0]).SetCategory((String)testData[testName][TestCaseDataDictionary.CategoryString][testData[testName][TestCaseDataDictionary.CategoryString].Length > 1 ? i : 0]).SetProperty(TestCaseDataDictionary.TestCaseIdString, (String)testData[testName][TestCaseDataDictionary.TestCaseIdString][testData[testName][TestCaseDataDictionary.TestCaseIdString].Length > 1 ? i : 0]);
                    result.Add(data);
                }
            return [.. result];
        };
}