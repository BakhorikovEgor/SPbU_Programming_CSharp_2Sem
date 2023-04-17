namespace TetrisTests;

public class Tests
{
    [Test]
    public void GenerateBlockMethod_ShouldReturnBlock()
        => Assert.That(Block.GenerateBlock() is Block, Is.True);


    [Test]
    public void UpdateComponents_ShouldReturnNewBlockWithExpectedComponents()
    {
        var block = Block.GenerateBlock();
        var vector = (10, 20);

        var expectedComponents = new (int, int)[block.Components.Length];
        Array.Copy(block.Components, expectedComponents, block.Components.Length);

        for (var i = 0; i < expectedComponents.Length; i++)
        {
            expectedComponents[i].Item1 += vector.Item1;
            expectedComponents[i].Item2 += vector.Item2;
        }

        var actualComponents = block.UpdateComponents(vector).Components;

        Assert.That(actualComponents.SequenceEqual(expectedComponents), Is.True);
    }

    [Test]
    public void Rotate_ShouldReturnBlockRotated90Degrees()
    {
        var expectedBlock = Block.GenerateBlock();

        var actualBlock = expectedBlock.Rotate().Rotate().Rotate().Rotate();

        Assert.That(actualBlock.Components.SequenceEqual(expectedBlock.Components), Is.True);
               
    }

}