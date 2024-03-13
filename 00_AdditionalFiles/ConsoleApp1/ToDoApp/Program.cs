
// Driver code

// TODO Auto-generated method stub
int[] arr = { 2, 3, 1, 2, 3, 3 };
int m = 3;

Console.WriteLine(distinctIds(arr, arr.Length, m));

static int distinctIds(int[] arr, int n, int mi)
    {

        Dictionary<int, int> m = new Dictionary<int, int>();
        int count = 0;
        int size = 0;

        // Store the occurrence of ids
        for (int i = 0; i < n; i++)
        {

            // If the key is not add it to map
            if (m.ContainsKey(arr[i]) == false)
            {
                m[arr[i]] = 1;
                size++;
            }

            // If it is present then increase the value by 1
            else
            {
                m[arr[i]]++;
            }
        }

        // Start removing elements from the beginning
        foreach (KeyValuePair<int, int> mp in m)
        {

            // Remove if current value is less than
            // or equal to mi
            if (mp.Key <= mi)
            {
                mi -= mp.Key;
                count++;
            }
        }
        return size - count;
    }



//Console.WriteLine("Hello!");

//var todos = new List<string>();

//var exitTheApp = false;

//do
//{
//    PrintAllOptionToConsole();

//    var userInput = Console.ReadLine();

//    switch (userInput)
//    {
//        case "s":
//        case "S":
//            ShowAllTodos(todos);
//            break;
//        case "a":
//        case "A":
//            AddTodo(todos);
//            break;
//        case "r":
//        case "R":
//            RemoveTodo(todos);
//            break;
//        case "e":
//        case "E":
//            exitTheApp = true;
//            break;
//        default:
//            Console.WriteLine("Incorrect input");
//            break;
//    }
//} while (!exitTheApp);


//void PrintAllOptionToConsole()
//{
//    Console.WriteLine();
//    Console.WriteLine("What do you want to do?");
//    Console.WriteLine();
//    Console.WriteLine("[S]ee all TODOs");
//    Console.WriteLine("[A]dd a TODO");
//    Console.WriteLine("[R]emove a TODO");
//    Console.WriteLine("[E]xit");
//    Console.WriteLine();
//}

//void AddTodo(List<string> todos)
//{
//    string? todo;
//    var todoIsAdded = false;
//    do
//    {
//        Console.WriteLine("Enter the TODO description:");

//        todo = Console.ReadLine();

//        if (string.IsNullOrWhiteSpace(todo))
//        {
//            Console.WriteLine("The description cannot be empty.");
//            continue;
//        }

//        if (todos.Contains(todo))
//        {
//            Console.WriteLine("The description must be unique.");
//            continue;
//        }

//        todos.Add(todo);
//        todoIsAdded = true;

//    } while (!todoIsAdded);

//    Console.WriteLine($"TODO successfully added: {todo}");
//}

//void RemoveTodo(List<string> todos) 
//{
//    if (todos.Count == 0)
//    {
//        PrintNoTodosScript();
//        return;
//    }

//    do
//    {
//        Console.WriteLine("Select the index of the TODO you want to remove:");
//        ShowAllTodos(todos);

//        var userChoice = Console.ReadLine();

//        if (string.IsNullOrWhiteSpace (userChoice))
//        {
//            Console.WriteLine("Selected index cannot be empty.");
//            continue;
//        }

//        var indexIsParse = int.TryParse(userChoice, out  int indexToRemove);

//        if (!indexIsParse || indexToRemove < 0 || indexToRemove > todos.Count)
//        {
//            Console.WriteLine("The given index is not valid.");
//            continue;
//        }

//        var removedTodo = todos[indexToRemove - 1];
//        todos.RemoveAt(indexToRemove - 1);
//        Console.WriteLine($"TODO removed: {removedTodo}");
//        break;
//    } while (true);
//}

//void ShowAllTodos(List<string> todos)
//{
//    if (todos.Count == 0)
//    {
//        PrintNoTodosScript();
//        return;
//    }

//    for (var i = 0; i < todos.Count; i++)
//    {
//        Console.WriteLine($"{i + 1}. {todos[i]}");
//    }
//}

//void PrintNoTodosScript()
//{
//    Console.WriteLine("No TODOs have been added yet!");
//}


Console.ReadKey();