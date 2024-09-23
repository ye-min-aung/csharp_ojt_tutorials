
string email = "";
int id = 1;
string phone = "";
bool Continue = false;
string C = "";

while (!Continue) { 

Console.WriteLine("Enter Member Name");
string name = Console.ReadLine();

bool isEmail = false;
while (!isEmail)
{
    Console.WriteLine("Enter Member Email");
    email = Console.ReadLine();

    if (email.Contains("@") && email.Contains("."))
    {
        isEmail = true;
    }
    else
    {
        Console.WriteLine("Invalid Email");
    }
}

bool isPhone = false;
while (!isPhone)
{
    Console.WriteLine("Enter Member Phone");
    phone = Console.ReadLine();

    foreach (char c in phone)
    {
        if (!char.IsDigit(c))
        {
            Console.WriteLine("Invalid Phone ");
            isPhone = false;
            break;
        }
        else
        {
            isPhone = true;
        }
    }
}


string cardId = "MC-000" + id++;


Console.WriteLine("Member Name      " + name);
Console.WriteLine("Email            " + email);
Console.WriteLine("Phone            " + phone);
Console.WriteLine("Member Card Id   " + cardId);
Console.WriteLine("Enter C to continue ");

    C = Console.ReadLine();

    if (C.ToLower() == "c")
    {
        Continue = false;
    }
    else
    {
        Continue = true;
    }
}