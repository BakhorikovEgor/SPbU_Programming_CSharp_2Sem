using Lists;
using static System.Console;

UniqueList uniqueList = new UniqueList();

var processing = true;
while (processing)
{
    var actionChoosingText = """
        Choose action:
        0. Exit.
        1. Add the element to list.
        2. Remove the element from list.
        3. Replace the element at position to a new element.
        """ + "\n";

    WriteLine(actionChoosingText);

    int action;
    while (!int.TryParse(ReadLine(), out action) || action > 3 || action < 0)
    {
        WriteLine("Wrong input \n");
        WriteLine(actionChoosingText);
    };


    switch (action)
    {
        case 0:
            processing = false;
            break;

        case 1:

            Write("\nEnter the element value (integer): ");

            int value;
            while (!int.TryParse(ReadLine(), out value))
            {
                WriteLine("Wrong input \n");
                Write("Enter the element value (integer): ");
            }

            try
            {
                uniqueList.Add(value);
                WriteLine($"\n{value} now in list. \n");
            }
            catch (ElementAlreadyExistException ex)
            {
                WriteLine("\n" + ex.Message + "\n");
            }

            break;

        case 2:
            Write("\nEnter the element value (integer): ");

            while (!int.TryParse(ReadLine(), out value))
            {
                WriteLine("Wrong input \n");
                Write("Enter the element value (integer): ");
            }

            try
            {
                var removeResult = uniqueList.Remove(value);
                if (removeResult)
                {
                    WriteLine($"\n{value} removed from list. \n");
                }
                else
                {
                    WriteLine("\nCan`t remove non - existent element. \n");
                }

            }
            catch (MissingElementException ex)
            {
                WriteLine("\n" + ex.Message + "\n");
            }

            break;

        case 3:
            Write("\nEnter new element value (integer): ");

            while (!int.TryParse(ReadLine(), out value))
            {
                WriteLine("Wrong input \n");
                Write("Enter new element value (integer): ");
            }

            Write("\nEnter position of replacing element (first position = 0): ");

            int position;
            while (!int.TryParse(ReadLine(), out position))
            {
                WriteLine("Wrong input \n");
                Write("Enter position of replacing element (first position = 0): ");
            }

            var replaceResult = uniqueList.Replace(value, position);
            if (replaceResult)
            {
                WriteLine($"\nNow at position {position} element {value} \n");
            }
            else
            {
                WriteLine("\nCan not replace. \n");
            }

            break;

    }
}