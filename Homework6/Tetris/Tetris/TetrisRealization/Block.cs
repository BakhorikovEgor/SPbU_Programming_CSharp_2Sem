namespace Tetris.Realization;
internal class Block
{
    public (int, int) [] Components { get; set; }

    private Block(params (int, int)[] components) => Components = components;

    private static readonly Block[] BLOCKS = new Block[]
    {
        new Block((0, 0), (0, 1), (0, 2)),
        new Block((0, 0), (0, 1), (1, 0), (1 ,1)),
        new Block((0, 0), (0, 1), (0, 2), (1 ,2)),
        new Block((0, 0), (0, 1), (1, 1), (2 ,1)),
    };

    private static readonly Random random = new();

    public static Block GenerateBlock()
        => BLOCKS[random.Next(0, BLOCKS.Length)];

    public Block UpdateComponents((int, int) shift)
        => new(Components.Select(component => ComponentSum(component, shift)).ToArray());

    public Block Rotate()
    {
        (int, int) shiftVector = (Components[0].Item1 - Components[0].Item2, Components[0].Item2 + Components[0].Item1);


        return new(Components.Select(component => ComponentSum((component.Item2, -component.Item1), shiftVector)).ToArray());
    }

    private static (int, int) ComponentSum((int,int) firstComponent, (int, int) secondComponent)
        => (firstComponent.Item1 + secondComponent.Item1, firstComponent.Item2 + secondComponent.Item2);
}

