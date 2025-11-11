using LeetCodeTasks.Helpers;

namespace LeetCodeTasks.Tests.Helpers;

[TestFixture]
public class ArraysHelperFixture
{
    [Test]
    public void Should_Find_Element_In_Middle()
    {
        int[] array = { 1, 3, 5, 7, 9 };
        int result = ArraysHelper.FindPosBinarySearch(array, 5);
        Assert.That(result, Is.EqualTo(2)); // index of 5
    }

    [Test]
    public void Should_Find_First_Element()
    {
        int[] array = { 2, 4, 6, 8 };
        int result = ArraysHelper.FindPosBinarySearch(array, 2);
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void Should_Find_Last_Element()
    {
        int[] array = { 10, 20, 30, 40, 50 };
        int result = ArraysHelper.FindPosBinarySearch(array, 50);
        Assert.That(result, Is.EqualTo(4));
    }

    [Test]
    public void BinarySearch_ShouldReturnPosWhereElementMightFit()
    {
        int[] array = { 1, 3, 5, 7, 9 };
        int result = ArraysHelper.FindPosBinarySearch(array, 6);
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void Should_Handle_Empty_Array()
    {
        int[] array = { };
        int result = ArraysHelper.FindPosBinarySearch(array, 42);
        Assert.That(result, Is.EqualTo(-1));
    }

    [Test]
    public void Should_Handle_Single_Element_Array_Found()
    {
        int[] array = { 99 };
        int result = ArraysHelper.FindPosBinarySearch(array, 99);
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void BinarySearch_SingleElement_ShouldFindCorrectPosition()
    {
        int[] array = { 99 };
        int result = ArraysHelper.FindPosBinarySearch(array, 100);
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void Should_Work_With_Negative_Numbers()
    {
        int[] array = { -10, -5, 0, 5, 10 };
        int result = ArraysHelper.FindPosBinarySearch(array, -5);
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void Should_Work_With_Duplicates_Return_Any_Valid_Index()
    {
        int[] array = { 1, 2, 2, 2, 3 };
        int result = ArraysHelper.FindPosBinarySearch(array, 2);
        Assert.That(result, Is.InRange(1, 3)); // any of the '2's is acceptable
    }

    [Test]
    public void Should_Handle_Large_Array_Correctly()
    {
        int[] array = new int[1000];
        for (int i = 0; i < array.Length; i++)
            array[i] = i * 2; // even numbers: 0, 2, 4, 6, ...

        int result = ArraysHelper.FindPosBinarySearch(array, 198); // should exist
        Assert.That(result, Is.EqualTo(99));
    }
}
