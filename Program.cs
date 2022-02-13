using OrientLogic.models;

Typ[] arr = new Typ[35];
Typ fighter = new(100, 5, 2, 1, true, true);
Typ archer = new(100, 1.0, 2, 10, true, true);
Typ life = new(12, 0, 0, 1, false, false);
Hero player = new(136, " ", true, true, 100, 20, 3, 1, true, true);

void initialize()
{
    arr[0] = player;
    FillArray(arr, fighter, 2);
    FillArray(arr, life, 3);
    FillArray(arr, archer, 1);
}

void PlayGame()
{
    Console.WriteLine("Enter player name: ");
    string playername = Console.ReadLine();
    player.Name = playername;
    for (int i = 0; i < arr.Length; i++)
    {
        if (CurrentFighter(player, arr, i) == fighter)
        {
            var fighter1 = new Typ(100, 5, 2, 1, true, true);
            arr[i + 1] = fighter1;
            Console.WriteLine("fighting with fighter: ");
            FightingWithFighter(player, arr, i);
        }
        else if (CurrentFighter(player, arr, i) == archer)
        {
            Console.WriteLine("fighting with archer: ");
            FightingWithArcher(player, arr, i);
            MoveForward(player, arr, i);
        }
        else if (CurrentFighter(player, arr, i) == life)
        {
            Console.WriteLine("filling life: ");
            MoveForward(player, arr, i);
            Console.WriteLine("your current health: " + Math.Round(player.Health));
        }
        else
        {
            Console.WriteLine("the way is free: ");
        }
        if (player.Health > 0)
        {
            MoveForward(player, arr, i);
        }
        else
        {
            Console.WriteLine(player.Name + " You Lose! " + " try again");
            break;
        }
    }
    if (player.Health > 0)
    {
        Console.WriteLine("Congratulations " + player.Name + " You Win! :) ");
    }
}

initialize();
PlayGame();

void FightingWithFighter(Hero player, Typ[] array, int curindx)
{
    while (true)
    {
        player.Health -= GetRandomNumber(7, 10);
        Console.WriteLine("Your current health: " + Math.Round(player.Health));
        if (player.Health <= 0)
        {
            Console.WriteLine("You Lose! ");
            break;
        }
        array[curindx + 1].Health -= GetRandomNumber(20, 25);
        if (array[curindx + 1].Health <= 0)
        {
            Console.WriteLine("fighter is dead");
            break;
        }
    }
}

void FightingWithArcher(Hero player, Typ[] array, int curindx)
{
    int a = Array.IndexOf(arr, archer);
    while (true)
    {
        if (curindx < Array.IndexOf(array, archer))
        {
            if (array[curindx + 1] == archer)
            {
                archer.Health = 0;
                array[curindx + 1] = player;
                array[curindx] = null;
                Console.WriteLine("archer is dead! ");
                break;
            }
            player.Health -= GetRandomNumber(5.3, 6);
            Console.WriteLine("Your current health: " + Math.Round(player.Health));
            if (player.Health <= 0)
            {
                break;
            }
            MoveForward(player, array, curindx);
            curindx++;
        }
    }
}

double GetRandomNumber(double minimum, double maximum)
{
    Random random = new Random();
    return random.NextDouble() * (maximum - minimum) + minimum;
}

Typ CurrentFighter(Hero hero, Typ[] array, int currentindex)
{
    if (currentindex + 1 < array.Length)
    {
        if (array[currentindex + 1] == fighter)
        {
            return fighter;
        }
        else if (array[currentindex + 1] == life)
        {
            return life;
        }
        else if ((currentindex + 10 < array.Length) && (array[currentindex + 1] == archer || array[currentindex + 2] == archer || array[currentindex + 3] == archer || array[currentindex + 4] == archer
        || array[currentindex + 5] == archer || array[currentindex + 6] == archer || array[currentindex + 7] == archer || array[currentindex + 8] == archer
        || array[currentindex + 9] == archer || array[currentindex + 10] == archer))
        {
            return archer;
        }
    }
    return null;
}

void MoveForward(Hero hero, Typ[] array, int currentindex)
{
    //Console.ReadLine();
    if (currentindex + 1 < array.Length)
    {
        if (array[currentindex + 1] == null)
        {

            arr[currentindex] = null;
            arr[currentindex + 1] = hero;
        }
        else if (array[currentindex + 1] == life)
        {
            hero.Health += life.Health;
            arr[currentindex] = null;
            arr[currentindex + 1] = hero;
        }
    }
}

void FillArray(Typ[] arr, object obj, int n)
{
    int counter = 0;
    int startindx = 1;
    Random rand = new Random();
    if (n == 1)
    {
        startindx = 10;
    }
    for (int i = startindx; i < arr.Length; i++)
    {
        int rnd = rand.Next(0, 2);
        if (rnd == 0)
        {
            continue;
        }
        else
        {
            if (counter < n && arr[i] == null)
            {
                var archer = new Typ(100, 1.0, 2, 10, true, true);
                if (n == 1)
                {
                    if (CheckIfSomethingInRadius(arr, i)) { continue; }
                    else { arr[i] = (Typ)obj; }
                }
                arr[i] = (Typ)obj;
                counter++;
            }
            else if (counter == n)
            {
                break;
            }
        }
    }
}

bool CheckIfSomethingInRadius(Typ[] arr, int indx)
{
    for (int i = indx; i < indx + 10; i++)
    {
        if (i + indx <= arr.Length)
        {
            if (arr[i] != null)
            {
                return true;
            }
        }
    }
    for (int i = indx; i > indx - 10; i--)
    {
        if (arr[i] != null)
        {
            return true;
        }
    }
    return false;
}