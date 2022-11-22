using aejw.Network;


static string ReadPassword()
{
    string password = "";
    ConsoleKeyInfo info = Console.ReadKey(true);
    while (info.Key != ConsoleKey.Enter)
    {
        if (info.Key != ConsoleKey.Backspace)
        {
            Console.Write("*");
            password += info.KeyChar;
        }
        else if (info.Key == ConsoleKey.Backspace)
        {
            if (!string.IsNullOrEmpty(password))
            {
                // remove one character from the list of password characters
                password = password.Substring(0, password.Length - 1);
                // get the location of the cursor
                int pos = Console.CursorLeft;
                // move the cursor to the left by one character
                Console.SetCursorPosition(pos - 1, Console.CursorTop);
                // replace it with space
                Console.Write(" ");
                // move the cursor to the left by one character again
                Console.SetCursorPosition(pos - 1, Console.CursorTop);
            }
        }
        info = Console.ReadKey(true);
    }


    // add a new line because user pressed enter at the end of their password
    Console.WriteLine();
    return password;

}
Console.WriteLine("Welcome to the BDM, this tool maps network drives.");
Console.WriteLine("Enter your credentials to start mapping network drives");

Console.Write("\nSMB Server IP/Name (only the name, backslashes or anything are not needed): ");
string ip = Console.ReadLine();
Console.Write("Username: ");
string username = Console.ReadLine();
Console.Write("Password:");
string password = ReadPassword();
Console.WriteLine("");



bool keepAsking = true;
while (keepAsking)
{
    Console.Write("Enter a drive letter to start mounting on, type 'su' to enter new credentials or 'st' to exit: ");
    string letter = Console.ReadLine();

    if (letter == "st")
    {
        keepAsking = false;
    }
    if (letter == "su")
    {
        Console.Write("\nSMB Server IP/Name (only the name, backslashes or anything are not needed): ");
        ip = Console.ReadLine();
        Console.Write("Username: ");
        username = Console.ReadLine();
        Console.Write("Password: ");
        password = ReadPassword();
        Console.WriteLine("");
    }
    else
    {
        Console.Write("Enter the share name you want to mount:\n");
        string sharename = Console.ReadLine();

        try
        {
            NetworkDrive drive = new NetworkDrive();
            drive.LocalDrive = letter;
            drive.ShareName = @"\\" + ip + @"\" + sharename;
            drive.MapDrive(username, password);
        }
        catch (Exception err)
        {
            Console.WriteLine(err.Message);
        }







    }




}


