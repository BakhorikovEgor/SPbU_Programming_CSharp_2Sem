﻿using System.Drawing;

namespace Tetris.Realization;

public class Game
{
    public ConsoleColor[,] Field { get; private set; }

    public bool IsGameOver { get; private set; } = false;

    public int Score { get; private set; } = 0;

    private enum Moves
    {
        Down, 
        Left, 
        Right,
        Rotate
    }

    private readonly (int, int) _spawningPosition;
    private Block _currentBlock;

    public Game(int length, int width)
    {
        Field = new ConsoleColor[length, width];
        _spawningPosition = (0, width / 2);

        _currentBlock = GenerateCurrentBlock();

        InitializeField();
        UpdateCurrentBlockOnField();
    }
    
    public void MoveDown(object? sender, EventArgs args)
        => Move(Moves.Down);

    public void MoveLeft(object? sender, EventArgs args)
        => Move(Moves.Left);

    public void MoveRight(object? sender, EventArgs args)
        => Move(Moves.Right);

    public void Rotate(object? sender, EventArgs args)
        => Move(Moves.Rotate);

    public void Reset(object? sender, EventArgs args)
    {
        if (IsGameOver)
        {
            Field = new ConsoleColor[Field.GetLength(0), Field.GetLength(1)];
            _currentBlock = GenerateCurrentBlock();
            IsGameOver = false;

            InitializeField();
            UpdateCurrentBlockOnField();
        }
    }

    private void Move(Moves move)
    {
        if (IsGameOver) return;

        UpdateCurrentBlockOnField(true);

        var tempBlock = move switch
        {
            Moves.Down => _currentBlock.UpdateComponents((1, 0)),
            Moves.Left => _currentBlock.UpdateComponents((0, -1)),
            Moves.Right => _currentBlock.UpdateComponents((0, 1)),
            Moves.Rotate => _currentBlock.Rotate(),
        };

        if (IsBlockInside(tempBlock) && IsPlaceFree(tempBlock))
        {
            _currentBlock = tempBlock;
            UpdateCurrentBlockOnField();
        }
        else if (move == Moves.Down)
        {
            UpdateCurrentBlockOnField();
            if (IsBlockAbove(tempBlock))
            {
                IsGameOver = true;
            }
            else
            {
                DeleteFilledRows();
                _currentBlock = GenerateCurrentBlock();
                UpdateCurrentBlockOnField();
            }
        }
    }

    private bool IsBlockInside(Block block)
        => block.Components.All(component => component.Item2 >= 0 && component.Item2 < Field.GetLength(1) &&
                                             component.Item1 >= 0 && component.Item1 < Field.GetLength(0));

    private bool IsBlockAbove(Block block)
        => block.Components.Any(component => component.Item1 <= 1);

    private bool IsPlaceFree(Block block)
        => block.Components.All(component => Field[component.Item1, component.Item2] == ConsoleColor.White);

    private void UpdateCurrentBlockOnField(bool deleting = false)
    {
        var validParts = _currentBlock.Components.Where((component) => component.Item1 >= 0);
        foreach (var part in validParts)
        {
            if (!deleting && Field[part.Item1, part.Item2] == ConsoleColor.White)
            {
                Field[part.Item1, part.Item2] = _currentBlock.Color;
            }
            else if (deleting && Field[part.Item1, part.Item2] != ConsoleColor.White)
            {
                Field[part.Item1, part.Item2] = ConsoleColor.White;
            }
        }
    }

    private void DeleteFilledRows()
    {
        for (var row = Field.GetLength(0) - 1; row >= 0; --row)
        {
            var isFullRow = true;
            for (var column = Field.GetLength(1) - 1; column >= 0; --column)
            {
                if (Field[row, column] == ConsoleColor.White)
                {
                    isFullRow = false;
                    break; 
                }
            }

            if (isFullRow)
            {
                DeleteRow(row);
                Score++;
            }
        }
    }

    private void DeleteRow(int deletingRow)
    {
        for (var row = deletingRow; row > 0; --row)
        {
            for (var column = 0; column < Field.GetLength(1); ++column)
            {
                Field[row, column] = Field[row - 1, column];
            }
        }

        for (var column = 0; column < Field.GetLength(1); ++column)
        {
            Field[0, column] = ConsoleColor.White;
        }
    }

    private Block GenerateCurrentBlock()
        => Block.GenerateBlock().UpdateComponents(_spawningPosition);

    private void InitializeField()
    {
        for (var row = 0; row < Field.GetLength(0); ++row)
        {
            for (var column = 0; column < Field.GetLength(1); ++column)
            {
                Field[row, column] = ConsoleColor.White;
            }
        }
    }
}