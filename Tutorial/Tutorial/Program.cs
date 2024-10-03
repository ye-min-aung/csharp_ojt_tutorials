
string email = "";
int id = 1;
string phone = "";
bool Continue = false;
string C = "";

while (!Continue) { 

Console.WriteLine("Enter Member Name");
string name = Console.ReadLine();

    while (name.Length > 50) 
    {
        Console.WriteLine("Name too long. Enter name less than 50 character");
        name = Console.ReadLine();
    }

bool isEmail = false;
while (!isEmail)
{
    Console.WriteLine("Enter Member Email");
    email = Console.ReadLine();

     if (email.Length > 50)
     {
         Console.WriteLine("Email is too long.Enter email less than 100 characters");
         continue;
     }

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

    if(phone.Length > 15)
        {
            Console.WriteLine("Phone to long. No more than 15 character");
            continue;
        }

    foreach (char c in phone)
    {
        if (!(char.IsDigit(c) || c =='+' || c== '-'))
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